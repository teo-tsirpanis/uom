namespace Dai19090.DistributedSystems.SigmaBank.Transport.Grpc;

public class BankGrpcSender : IBank
{
    private readonly Bank.BankClient _client;

    public BankGrpcSender(Bank.BankClient client)
    {
        _client = client;
    }

    public async Task<SigmaBank.UserInfo> CreateUserAsync(string name, string surname, CancellationToken cancellationToken = default)
    {
        var request = new CreateUserRequest() { Name = name, Surname = surname };
        var response = await _client.CreateUserAsync(request, cancellationToken: cancellationToken);
        return response.User.ToSigmaUserInfo();
    }

    public async Task<SigmaBank.UserInfo?> GetUserInfoAsync(UserId id, CancellationToken cancellationToken = default)
    {
        var request = new GetUserInfoRequest() { UserId = id.Id };
        var response = await _client.GetUserInfoAsync(request, cancellationToken: cancellationToken);
        if (response.UserMaybeCase == GetUserInfoResponse.UserMaybeOneofCase.UserValue)
            return response.UserValue.ToSigmaUserInfo();
        else
            return null;
    }

    public async Task<SigmaBank.AccountInfo> CreateAccountAsync(UserId id, CancellationToken cancellationToken = default)
    {
        var request = new CreateAccountRequest() { Owner = id.Id };
        var response = await _client.CreateAccountAsync(request, cancellationToken: cancellationToken);
        return response.Account.ToSigmaAccountInfo();
    }

    public async Task<SigmaBank.AccountInfo?> GetAccountInfoAsync(AccountId id, CancellationToken cancellationToken = default)
    {
        var request = new GetAccountInfoRequest() { AccountId = id.Id };
        var response = await _client.GetAccountInfoAsync(request, cancellationToken: cancellationToken);
        if (response.AccountMaybeCase == GetAccountInfoResponse.AccountMaybeOneofCase.AccountValue)
            return response.AccountValue.ToSigmaAccountInfo();
        else
            return null;
    }

    public async Task<SigmaBank.AccountInfo> DepositAsync(AccountId id, decimal amount, CancellationToken cancellationToken = default)
    {
        var request = new DepositRequest() { AccountId = id.Id, Amount = (double)amount };
        var response = await _client.DepositAsync(request, cancellationToken: cancellationToken);
        return response.Account.ToSigmaAccountInfo();
    }

    public async Task<SigmaBank.AccountInfo> WithdrawAsync(AccountId id, decimal amount, CancellationToken cancellationToken = default)
    {
        var request = new WithdrawRequest() { AccountId = id.Id, Amount = (double)amount };
        var response = await _client.WithdrawAsync(request, cancellationToken: cancellationToken);
        return response.Account.ToSigmaAccountInfo();
    }

    public async Task<TransferResult> TransferAsync(AccountId originAccountId, AccountId destinationAccountId, decimal amount, CancellationToken cancellationToken = default)
    {
        var request = new TransferRequest() { FromAccountId = originAccountId.Id, ToAccountId = destinationAccountId.Id, Amount = (double)amount };
        var response = await _client.TransferAsync(request, cancellationToken: cancellationToken);
        return response.ToSigmaTransferResult();
        throw new NotImplementedException();
    }
}
