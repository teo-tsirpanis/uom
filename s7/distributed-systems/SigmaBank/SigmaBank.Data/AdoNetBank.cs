using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace Dai19090.DistributedSystems.SigmaBank.Data;

/// <summary>
/// An implementation of <see cref="IBank"/> that is backed by an ADO.NET database connection.
/// </summary>
internal sealed class AdoNetBank : IBank
{
    private readonly Func<DbConnection> _connectionFactory;

    /// <summary>
    /// Creates an <see cref="AdoNetBank"/>.
    /// </summary>
    /// <param name="connectionFactory">A function that creates a database connection.</param>
    public AdoNetBank(Func<DbConnection> connectionFactory)
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

    public async Task<AccountInfo> CreateAccountAsync(UserId id, CancellationToken cancellationToken)
    {
        await using var connection = _connectionFactory();
        await connection.OpenAsync(cancellationToken);

        bool succeeded = false;
        await using var transaction = await connection.BeginTransactionAsync(cancellationToken);
        try
        {
            if (await GetUserInfoImpl(connection, transaction, id, cancellationToken) is null)
                throw new BankException("Specified account does not exist");

            await using var command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = "INSERT INTO accounts (owner_id) VALUES (@Owner); SELECT SCOPE_IDENTITY()";
            AddParameter(command, "Owner", id.Id);

            var result = await command.ExecuteScalarAsync(cancellationToken);
            // Yes, SQL Server returns a decimal.
            if (result is not decimal accountId)
                throw new InvalidOperationException("Database did not return account ID.");
            var newAccountId = new AccountId(Convert.ToInt32(accountId));

            var accountInfo = await GetAccountInfoImpl(connection, transaction, newAccountId, cancellationToken);
            if (accountInfo is null)
                throw new InvalidOperationException("Could not get account info.");

            succeeded = true;
            return accountInfo;
        }
        finally
        {
            if (succeeded)
                await transaction.CommitAsync(cancellationToken);
            else
                await transaction.RollbackAsync(cancellationToken);
        }
    }

    private static async Task<AccountInfo?> GetAccountInfoImpl(DbConnection connection, DbTransaction? transaction, AccountId id, CancellationToken cancellationToken)
    {
        await using var command = connection.CreateCommand();

        command.Transaction = transaction;
        command.CommandText = "SELECT * FROM accounts WHERE account_id = @Id";
        AddParameter(command, "Id", id.Id);

        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return DatabaseUtilities.GetAccountInfo(reader);
    }

    public async Task<AccountInfo?> GetAccountInfoAsync(AccountId id, CancellationToken cancellationToken)
    {
        await using var connection = _connectionFactory();
        await connection.OpenAsync(cancellationToken);

        return await GetAccountInfoImpl(connection, null, id, cancellationToken);
    }

    public async Task<UserInfo> CreateUserAsync(string name, string surname, CancellationToken cancellationToken)
    {
        await using var connection = _connectionFactory();
        await connection.OpenAsync(cancellationToken);

        bool succeeded = false;
        await using var transaction = await connection.BeginTransactionAsync(cancellationToken);
        try
        {
            await using var command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = "INSERT INTO users (name, surname) VALUES (@Name, @Surname); SELECT SCOPE_IDENTITY()";
            AddParameter(command, "Name", name);
            AddParameter(command, "Surname", surname);

            var result = await command.ExecuteScalarAsync(cancellationToken);
            if (result is not decimal userId)
                throw new InvalidOperationException("Database did not return user ID.");
            var newUserId = new UserId(Convert.ToInt32(userId));

            var accountInfo = await GetUserInfoImpl(connection, transaction, newUserId, cancellationToken);
            if (accountInfo is null)
                throw new InvalidOperationException("Could not get user info.");

            succeeded = true;
            return accountInfo;
        }
        finally
        {
            if (succeeded)
                await transaction.CommitAsync(cancellationToken);
            else
                await transaction.RollbackAsync(cancellationToken);
        }
    }

    private static async Task<UserInfo?> GetUserInfoImpl(DbConnection connection, DbTransaction? transaction, UserId id, CancellationToken cancellationToken)
    {
        await using var command = connection.CreateCommand();

        command.Transaction = transaction;
        command.CommandText = "SELECT * FROM users WHERE user_id = @Id";
        AddParameter(command, "Id", id.Id);

        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        return DatabaseUtilities.GetUserInfo(reader);
    }

    public async Task<UserInfo?> GetUserInfoAsync(UserId id, CancellationToken cancellationToken)
    {
        await using var connection = _connectionFactory();
        await connection.OpenAsync(cancellationToken);

        return await GetUserInfoImpl(connection, null, id, cancellationToken);
    }

    private static async Task<bool> DepositImpl(DbConnection connection, DbTransaction transaction, AccountId id, decimal amount, CancellationToken cancellationToken)
    {
        await using var command = connection.CreateCommand();

        command.Transaction = transaction;
        command.CommandText = "UPDATE accounts SET balance = balance + @Amount WHERE account_id = @Id";
        AddParameter(command, "Amount", amount);
        AddParameter(command, "Id", id.Id);

        return await command.ExecuteNonQueryAsync(cancellationToken) == 1;
    }

    public async Task<AccountInfo> DepositAsync(AccountId id, decimal amount, CancellationToken cancellationToken)
    {
        await using var connection = _connectionFactory();
        await connection.OpenAsync(cancellationToken);

        await using var transaction = await connection.BeginTransactionAsync(cancellationToken);
        bool succeeded = false;
        try
        {
            if (!await DepositImpl(connection, transaction, id, amount, cancellationToken))
                throw new BankException("Account does not exist.");

            var accountInfo = await GetAccountInfoImpl(connection, transaction, id, cancellationToken);
            if (accountInfo is null)
                throw new InvalidOperationException("Could not get account info.");

            succeeded = true;
            return accountInfo;
        }
        finally
        {
            if (succeeded)
                await transaction.CommitAsync(cancellationToken);
            else
                await transaction.RollbackAsync(cancellationToken);
        }
    }

    private static async Task<bool> WithdrawImpl(DbConnection connection, DbTransaction transaction, AccountId id, decimal amount, CancellationToken cancellationToken)
    {
        await using var command = connection.CreateCommand();

        command.Transaction = transaction;
        command.CommandText = "UPDATE accounts SET balance = balance - @Amount WHERE account_id = @Id";
        AddParameter(command, "Amount", amount);
        AddParameter(command, "Id", id.Id);

        return await command.ExecuteNonQueryAsync(cancellationToken) == 1;
    }

    private static void ValidateWithdrawnAccount([NotNull] AccountInfo? accountInfo)
    {
        if (accountInfo is null)
            throw new InvalidOperationException("Could not get account info.");
        if (accountInfo.Balance < 0.0m)
            throw new BankException("Insufficient funds.");
    }

    public async Task<AccountInfo> WithdrawAsync(AccountId id, decimal amount, CancellationToken cancellationToken)
    {
        await using var connection = _connectionFactory();
        await connection.OpenAsync(cancellationToken);

        await using var transaction = await connection.BeginTransactionAsync(cancellationToken);
        bool succeeded = false;
        try
        {
            if (!await WithdrawImpl(connection, transaction, id, amount, cancellationToken))
                throw new BankException("Account does not exist.");

            var accountInfo = await GetAccountInfoImpl(connection, transaction, id, cancellationToken);
            ValidateWithdrawnAccount(accountInfo);

            succeeded = true;
            return accountInfo;
        }
        finally
        {
            if (succeeded)
                await transaction.CommitAsync(cancellationToken);
            else
                await transaction.RollbackAsync(cancellationToken);
        }
    }

    public async Task<TransferResult> TransferAsync(AccountId originAccountId, AccountId destinationAccountId, decimal amount, CancellationToken cancellationToken)
    {
        await using var connection = _connectionFactory();
        await connection.OpenAsync(cancellationToken);

        await using var transaction = await connection.BeginTransactionAsync(cancellationToken);
        bool succeeded = false;
        try
        {
            if (!await WithdrawImpl(connection, transaction, originAccountId, amount, cancellationToken))
                throw new BankException("Origin account does not exist.");

            if (!await DepositImpl(connection, transaction, destinationAccountId, amount, cancellationToken))
                throw new BankException("Destination account does not exist.");

            var originAccountInfo = await GetAccountInfoImpl(connection, transaction, originAccountId, cancellationToken);
            ValidateWithdrawnAccount(originAccountInfo);
            var destinationAccountInfo = await GetAccountInfoImpl(connection, transaction, destinationAccountId, cancellationToken);
            if (destinationAccountInfo is null)
                throw new InvalidOperationException("Could not get destination account info.");

            succeeded = true;
            return new(originAccountInfo, destinationAccountInfo);
        }
        finally
        {
            if (succeeded)
                await transaction.CommitAsync(cancellationToken);
            else
                await transaction.RollbackAsync(cancellationToken);
        }
    }
}
