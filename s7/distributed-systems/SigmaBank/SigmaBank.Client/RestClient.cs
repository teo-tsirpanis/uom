using Impl = SwaggerImpl.SigmaBank;

namespace Dai19090.DistributedSystems.SigmaBank.Client;

/// <summary>
/// An implementation of <see cref="IBank"/> that communicates with a REST service.
/// </summary>
/// <remarks>
/// The client's actual implementation is automatically generated from OpenAPI definitions.
/// </remarks>
internal class RestClient : IBank
{
    private readonly Impl.RestClientImpl _impl;

    public RestClient(string baseUrl, HttpClient client)
    {
        _impl = new Impl.RestClientImpl(baseUrl, client);
    }

    public async Task<UserInfo> CreateUserAsync(string name, string surname, CancellationToken cancellationToken = default)
    {
        var userInfo = await _impl.Users2Async(name, surname, cancellationToken);

        return userInfo.ToSigmaUserInfo();
    }

    public async Task<UserInfo?> GetUserInfoAsync(UserId id, CancellationToken cancellationToken = default)
    {
        try
        {
            var userInfo = await _impl.UsersAsync(id.Id, cancellationToken);

            return userInfo.ToSigmaUserInfo();
        }
        catch (Impl.ApiException e) when (e.StatusCode == 404)
        {
            return null;
        }
        catch (Impl.ApiException<Impl.ProblemDetails> e)
        {
            throw new BankException(e.Result.Detail);
        }
    }

    public async Task<AccountInfo> CreateAccountAsync(UserId id, CancellationToken cancellationToken = default)
    {
        try
        {
            var userInfo = await _impl.Accounts2Async(id.Id, cancellationToken);

            return userInfo.ToSigmaAccountInfo();
        }
        catch (Impl.ApiException<Impl.ProblemDetails> e)
        {
            throw new BankException(e.Result.Detail);
        }
    }

    public async Task<AccountInfo?> GetAccountInfoAsync(AccountId id, CancellationToken cancellationToken = default)
    {
        try
        {
            var accountInfo = await _impl.AccountsAsync(id.Id, cancellationToken);

            return accountInfo.ToSigmaAccountInfo();
        }
        catch (Impl.ApiException e) when (e.StatusCode == 404)
        {
            return null;
        }
        catch (Impl.ApiException<Impl.ProblemDetails> e)
        {
            throw new BankException(e.Result.Detail);
        }
    }

    public async Task<AccountInfo> DepositAsync(AccountId id, decimal amount, CancellationToken cancellationToken = default)
    {
        try
        {
            var accountInfo = await _impl.DepositAsync(id.Id, (double)amount, cancellationToken);

            return accountInfo.ToSigmaAccountInfo();
        }
        catch (Impl.ApiException<Impl.ProblemDetails> e)
        {
            throw new BankException(e.Result.Detail);
        }
    }

    public async Task<AccountInfo> WithdrawAsync(AccountId id, decimal amount, CancellationToken cancellationToken = default)
    {
        try
        {
            var accountInfo = await _impl.WithdrawAsync(id.Id, (double)amount, cancellationToken);

            return accountInfo.ToSigmaAccountInfo();
        }
        catch (Impl.ApiException<Impl.ProblemDetails> e)
        {
            throw new BankException(e.Result.Detail);
        }
    }

    public async Task<TransferResult> TransferAsync(AccountId originAccountId, AccountId destinationAccountId, decimal amount, CancellationToken cancellationToken = default)
    {
        try
        {
            var transferResult = await _impl.TransferAsync(originAccountId.Id, destinationAccountId.Id, (double)amount, cancellationToken);

            return transferResult.ToSigmaTransferResult();
        }
        catch (Impl.ApiException<Impl.ProblemDetails> e)
        {
            throw new BankException(e.Result.Detail);
        }
    }
}
