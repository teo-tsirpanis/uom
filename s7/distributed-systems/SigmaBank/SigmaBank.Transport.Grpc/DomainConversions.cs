using SigmaAccountInfo = Dai19090.DistributedSystems.SigmaBank.AccountInfo;
using SigmaUserInfo = Dai19090.DistributedSystems.SigmaBank.UserInfo;

namespace Dai19090.DistributedSystems.SigmaBank.Transport.Grpc;

internal static class DomainConversions
{
    public static UserInfo ToGrpcUserInfo(this SigmaUserInfo info) =>
        new() { UserId = info.Id.Id, Name = info.Name, Surname = info.Surname };

    public static SigmaUserInfo ToSigmaUserInfo(this UserInfo info) =>
        new(new(info.UserId), info.Name, info.Surname);

    public static AccountInfo ToGrpcAccountInfo(this SigmaAccountInfo info) =>
        new() { AccountId = info.AccountId.Id, OwnerId = info.Owner.Id, Balance = (double)info.Balance };

    public static SigmaAccountInfo ToSigmaAccountInfo(this AccountInfo info) =>
        new(new AccountId(info.AccountId), new UserId(info.OwnerId), (decimal)info.Balance);

    public static TransferResponse ToGrpcTransferResponse(this TransferResult result) =>
        new()
        {
            FromAccount = result.OriginAccountInfo.ToGrpcAccountInfo(),
            ToAccount = result.DestinationAccountInfo.ToGrpcAccountInfo()
        };

    public static TransferResult ToSigmaTransferResult(this TransferResponse response) =>
        new(response.FromAccount.ToSigmaAccountInfo(), response.ToAccount.ToSigmaAccountInfo());
}
