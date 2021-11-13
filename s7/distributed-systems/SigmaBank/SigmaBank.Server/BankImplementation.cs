using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace Dai19090.DistributedSystems.SigmaBank.Server;

/// <summary>
/// An implementation of <see cref="IBank"/> that is backed by an ADO.NET database connection.
/// </summary>
public sealed class BankImplementation : IBank
{
    private readonly Func<DbConnection> _connectionFactory;

    public BankImplementation(Func<DbConnection> connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    private static void AddParameter(DbCommand command, string name, object value)
    {
        var parameter = command.CreateParameter();
        parameter.ParameterName = name;
        parameter.Value = value;
        command.Parameters.Add(parameter);
    }

    public async Task<AccountInfo> CreateAccountAsync(UserId id)
    {
        await using var connection = _connectionFactory();
        await connection.OpenAsync();

        bool succeeded = false;
        await using var transaction = await connection.BeginTransactionAsync();
        try
        {
            if (await GetUserInfoImpl(connection, transaction, id) is null)
                throw new BankException("Specified account does not exist");

            await using var command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = "INSERT INTO accounts (owner_id) VALUES (@Owner); SELECT SCOPE_IDENTITY()";
            AddParameter(command, "Owner", id.Id);

            var result = await command.ExecuteScalarAsync();
            if (result is not int accountId)
                throw new InvalidOperationException("Database did not return account ID.");
            var newAccountId = new AccountId(accountId);

            var accountInfo = await GetAccountInfoImpl(connection, transaction, newAccountId);
            if (accountInfo is null)
                throw new InvalidOperationException("Could not get account info.");

            succeeded = true;
            return accountInfo;
        }
        finally
        {
            if (succeeded)
                await transaction.CommitAsync();
            else
                await transaction.RollbackAsync();
        }
    }

    private static async Task<AccountInfo?> GetAccountInfoImpl(DbConnection connection, DbTransaction? transaction, AccountId id)
    {
        await using var command = connection.CreateCommand();

        command.Transaction = transaction;
        command.CommandText = "SELECT * FROM accounts WHERE account_id = @Id";
        AddParameter(command, "Id", id.Id);

        await using var reader = await command.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
            return null;

        return DbDeserializer.GetAccountInfo(reader);
    }

    public async Task<AccountInfo?> GetAccountInfoAsync(AccountId id)
    {
        await using var connection = _connectionFactory();
        await connection.OpenAsync();

        return await GetAccountInfoImpl(connection, null, id);
    }

    public async Task<UserInfo> CreateUserAsync(string name, string surname)
    {
        await using var connection = _connectionFactory();
        await connection.OpenAsync();

        bool succeeded = false;
        await using var transaction = await connection.BeginTransactionAsync();
        try
        {
            await using var command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = "INSERT INTO users (name, surname) VALUES (@Name, @Surname); SELECT SCOPE_IDENTITY()";
            AddParameter(command, "Name", name);
            AddParameter(command, "Surname", surname);

            var result = await command.ExecuteScalarAsync();
            if (result is not int userId)
                throw new InvalidOperationException("Database did not return user ID.");
            var newUserId = new UserId(userId);

            var accountInfo = await GetUserInfoImpl(connection, transaction, newUserId);
            if (accountInfo is null)
                throw new InvalidOperationException("Could not get user info.");

            succeeded = true;
            return accountInfo;
        }
        finally
        {
            if (succeeded)
                await transaction.CommitAsync();
            else
                await transaction.RollbackAsync();
        }
    }

    private static async Task<UserInfo?> GetUserInfoImpl(DbConnection connection, DbTransaction? transaction, UserId id)
    {
        await using var command = connection.CreateCommand();

        command.Transaction = transaction;
        command.CommandText = "SELECT * FROM users WHERE user_id = @Id";
        AddParameter(command, "Id", id.Id);

        await using var reader = await command.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
            return null;

        return DbDeserializer.GetUserInfo(reader);
    }

    public async Task<UserInfo?> GetUserInfoAsync(UserId id)
    {
        await using var connection = _connectionFactory();
        await connection.OpenAsync();

        return await GetUserInfoImpl(connection, null, id);
    }

    private static async Task<bool> DepositImpl(DbConnection connection, DbTransaction transaction, AccountId id, decimal amount)
    {
        await using var command = connection.CreateCommand();

        command.Transaction = transaction;
        command.CommandText = "UPDATE accounts SET balance = balance + @Amount WHERE account_id = @Id";
        AddParameter(command, "Amount", amount);
        AddParameter(command, "Id", id.Id);

        return await command.ExecuteNonQueryAsync() == 1;
    }

    public async Task<AccountInfo> DepositAsync(AccountId id, decimal amount)
    {
        await using var connection = _connectionFactory();
        await connection.OpenAsync();

        await using var transaction = await connection.BeginTransactionAsync();
        bool succeeded = false;
        try
        {
            if (!await DepositImpl(connection, transaction, id, amount))
                throw new BankException("Account does not exist.");

            var accountInfo = await GetAccountInfoImpl(connection, transaction, id);
            if (accountInfo is null)
                throw new InvalidOperationException("Could not get account info.");

            succeeded = true;
            return accountInfo;
        }
        finally
        {
            if (succeeded)
                await transaction.CommitAsync();
            else
                await transaction.RollbackAsync();
        }
    }

    private static async Task<bool> WithdrawImpl(DbConnection connection, DbTransaction transaction, AccountId id, decimal amount)
    {
        await using var command = connection.CreateCommand();

        command.Transaction = transaction;
        command.CommandText = "UPDATE accounts SET balance = balance - @Amount WHERE account_id = @Id";
        AddParameter(command, "Amount", amount);
        AddParameter(command, "Id", id.Id);

        return await command.ExecuteNonQueryAsync() == 1;
    }

    private static void ValidateWithdrawnAccount([NotNull] AccountInfo? accountInfo)
    {
        if (accountInfo is null)
            throw new InvalidOperationException("Could not get account info.");
        if (accountInfo.Balance < 0.0m)
            throw new BankException("Insufficient funds.");
    }

    public async Task<AccountInfo> WithdrawAsync(AccountId id, decimal amount)
    {
        await using var connection = _connectionFactory();
        await connection.OpenAsync();

        await using var transaction = await connection.BeginTransactionAsync();
        bool succeeded = false;
        try
        {
            if (!await WithdrawImpl(connection, transaction, id, amount))
                throw new BankException("Account does not exist.");

            var accountInfo = await GetAccountInfoImpl(connection, transaction, id);
            ValidateWithdrawnAccount(accountInfo);

            succeeded = true;
            return accountInfo;
        }
        finally
        {
            if (succeeded)
                await transaction.CommitAsync();
            else
                await transaction.RollbackAsync();
        }
    }

    public async Task<TransferResult> TransferAsync(AccountId originAccountId, AccountId destinationAccountId, decimal amount)
    {
        await using var connection = _connectionFactory();
        await connection.OpenAsync();

        await using var transaction = await connection.BeginTransactionAsync();
        bool succeeded = false;
        try
        {
            if (!await WithdrawImpl(connection, transaction, originAccountId, amount))
                throw new BankException("Origin account does not exist.");

            if (!await DepositImpl(connection, transaction, destinationAccountId, amount))
                throw new BankException("Destination account does not exist.");

            var originAccountInfo = await GetAccountInfoImpl(connection, transaction, originAccountId);
            ValidateWithdrawnAccount(originAccountInfo);
            var destinationAccountInfo = await GetAccountInfoImpl(connection, transaction, destinationAccountId);
            if (destinationAccountInfo is null)
                throw new InvalidOperationException("Could not get destination account info.");

            succeeded = true;
            return new(originAccountInfo, destinationAccountInfo);
        }
        finally
        {
            if (succeeded)
                await transaction.CommitAsync();
            else
                await transaction.RollbackAsync();
        }
    }
}
