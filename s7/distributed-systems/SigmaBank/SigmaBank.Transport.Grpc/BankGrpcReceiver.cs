using Grpc.Core;

namespace Dai19090.DistributedSystems.SigmaBank.Transport.Grpc;

public sealed class BankGrpcReceiver : Bank.BankBase
{
    private readonly IBank _bank;

    public BankGrpcReceiver(IBank bank)
    {
        _bank = bank;
    }

    public override async Task<CreateUserResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
    {
        var name = request.Name;
        var surname = request.Surname;
        ArgumentValidation.ValidateAcountCreation(name, surname);
        var response = await _bank.CreateUserAsync(name, surname, context.CancellationToken);
        return new() { User = response.ToGrpcUserInfo() };
    }

    public override async Task<GetUserInfoResponse> GetUserInfo(GetUserInfoRequest request, ServerCallContext context)
    {
        var response = await _bank.GetUserInfoAsync(new(request.UserId), context.CancellationToken);
        if (response is null)
            return new() { UserNull = true };
        else
            return new() { UserValue = response.ToGrpcUserInfo() };
    }

    public override async Task<CreateAccountResponse> CreateAccount(CreateAccountRequest request, ServerCallContext context)
    {
        var response = await _bank.CreateAccountAsync(new(request.Owner), context.CancellationToken);
        return new() { Account = response.ToGrpcAccountInfo() };
    }

    public override async Task<GetAccountInfoResponse> GetAccountInfo(GetAccountInfoRequest request, ServerCallContext context)
    {
        var response = await _bank.GetAccountInfoAsync(new(request.AccountId), context.CancellationToken);
        if (response is null)
            return new() { AccountNull = true };
        else
            return new() { AccountValue = response.ToGrpcAccountInfo() };
    }

    public override async Task<DepositResponse> Deposit(DepositRequest request, ServerCallContext context)
    {
        var account = new AccountId(request.AccountId);
        var amount = (decimal)request.Amount;
        ArgumentValidation.ValidateCurrencyAmount(amount);
        var response = await _bank.DepositAsync(account, amount, context.CancellationToken);
        return new() { Account = response.ToGrpcAccountInfo() };
    }

    public override async Task<WithdrawResponse> Withdraw(WithdrawRequest request, ServerCallContext context)
    {
        var account = new AccountId(request.AccountId);
        var amount = (decimal)request.Amount;
        ArgumentValidation.ValidateCurrencyAmount(amount);
        var response = await _bank.WithdrawAsync(account, amount, context.CancellationToken);
        return new() { Account = response.ToGrpcAccountInfo() };
    }

    public override async Task<TransferResponse> Transfer(TransferRequest request, ServerCallContext context)
    {
        var originAccount = new AccountId(request.FromAccountId);
        var destinationAccount = new AccountId(request.ToAccountId);
        var amount = (decimal)request.Amount;
        ArgumentValidation.ValidateTransfer(originAccount, destinationAccount, amount);
        var response = await _bank.TransferAsync(originAccount, destinationAccount, amount, context.CancellationToken);
        return response.ToGrpcTransferResponse();
    }
}
