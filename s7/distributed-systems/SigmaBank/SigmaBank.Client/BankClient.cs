using System.Text.Json;

namespace Dai19090.DistributedSystems.SigmaBank.Client;

/// <summary>
/// An implementation of <see cref="IBank"/> that communicates with a remote RPC client.
/// </summary>
public sealed class BankClient : IBank
{
    private readonly Func<CancellationToken, Task<Stream>> _connectionFactory;

    /// <summary>
    /// Creates a <see cref="BankClient"/>.
    /// </summary>
    /// <param name="connectionFactory">A function that creates a communication stream.</param>
    public BankClient(Func<CancellationToken, Task<Stream>> connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<UserInfo> CreateUserAsync(string name, string surname, CancellationToken cancellationToken = default)
    {
        await using var connection = await _connectionFactory(cancellationToken);
        return await RpcSender.SendAsync<UserInfo, (string, string)>(connection, static (writer, x) => {
            writer.WriteStringValue(x.Item1);
            writer.WriteStringValue(x.Item2);
        }, (name, surname), cancellationToken);
    }

    public async Task<UserInfo?> GetUserInfoAsync(UserId id, CancellationToken cancellationToken = default)
    {
        await using var connection = await _connectionFactory(cancellationToken);
        return await RpcSender.SendAsync<UserInfo?, UserId>(connection, static (writer, x) => {
            JsonSerializer.Serialize(writer, x);
        }, id, cancellationToken);
    }

    public async Task<AccountInfo> CreateAccountAsync(UserId id, CancellationToken cancellationToken = default)
    {
        await using var connection = await _connectionFactory(cancellationToken);
        return await RpcSender.SendAsync<AccountInfo, UserId>(connection, static (writer, x) => {
            JsonSerializer.Serialize(writer, x);
        }, id, cancellationToken);
    }

    public async Task<AccountInfo?> GetAccountInfoAsync(AccountId id, CancellationToken cancellationToken = default)
    {
        await using var connection = await _connectionFactory(cancellationToken);
        return await RpcSender.SendAsync<AccountInfo?, AccountId>(connection, static (writer, x) => {
            JsonSerializer.Serialize(writer, x);
        }, id, cancellationToken);
    }

    public async Task<AccountInfo> DepositAsync(AccountId id, decimal amount, CancellationToken cancellationToken = default)
    {
        ArgumentValidation.ValidateCurrencyAmount(amount);
        await using var connection = await _connectionFactory(cancellationToken);
        return await RpcSender.SendAsync<AccountInfo, (AccountId, decimal)>(connection, static (writer, x) => {
            JsonSerializer.Serialize(writer, x.Item1);
            writer.WriteNumberValue(x.Item2);
        }, (id, amount), cancellationToken);
    }

    public async Task<AccountInfo> WithdrawAsync(AccountId id, decimal amount, CancellationToken cancellationToken = default)
    {
        ArgumentValidation.ValidateCurrencyAmount(amount);
        await using var connection = await _connectionFactory(cancellationToken);
        return await RpcSender.SendAsync<AccountInfo, (AccountId, decimal)>(connection, static (writer, x) => {
            JsonSerializer.Serialize(writer, x.Item1);
            writer.WriteNumberValue(x.Item2);
        }, (id, amount), cancellationToken);
    }

    public async Task<TransferResult> TransferAsync(AccountId originAccountId, AccountId destinationAccountId, decimal amount, CancellationToken cancellationToken = default)
    {
        ArgumentValidation.ValidateTransfer(originAccountId, destinationAccountId, amount);
        await using var connection = await _connectionFactory(cancellationToken);
        return await RpcSender.SendAsync<TransferResult, (AccountId, AccountId, decimal)>(connection, static (writer, x) => {
            JsonSerializer.Serialize(writer, x.Item1);
            JsonSerializer.Serialize(writer, x.Item2);
            writer.WriteNumberValue(x.Item3);
        }, (originAccountId, destinationAccountId, amount), cancellationToken);
    }
}
