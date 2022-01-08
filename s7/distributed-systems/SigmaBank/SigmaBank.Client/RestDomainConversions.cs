using Impl = SwaggerImpl.SigmaBank;

namespace Dai19090.DistributedSystems.SigmaBank.Client;

internal static class RestDomainConversions
{
    public static UserInfo ToSigmaUserInfo(this Impl.UserInfo x) => new(new(x.Id.Id), x.Name, x.Surname);
    public static AccountInfo ToSigmaAccountInfo(this Impl.AccountInfo x) => new(new(x.AccountId.Id), new(x.Owner.Id), (decimal) x.Balance);
    public static TransferResult ToSigmaTransferResult(this Impl.TransferResult x) =>
        new(x.OriginAccountInfo.ToSigmaAccountInfo(), x.DestinationAccountInfo.ToSigmaAccountInfo());
}
