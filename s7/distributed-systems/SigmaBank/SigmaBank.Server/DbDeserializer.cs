using System.Data.Common;

namespace Dai19090.DistributedSystems.SigmaBank.Server;

public static class DbDeserializer
{
    public static UserInfo GetUserInfo(DbDataReader reader)
    {
        var id = reader.GetInt32(0);
        var name = reader.GetString(1);
        var surname = reader.GetString(2);
        return new (new(id), name, surname);
    }

    public static AccountInfo GetAccountInfo(DbDataReader reader)
    {
        var id = reader.GetInt32(0);
        var owner = reader.GetInt32(1);
        var balance = reader.GetDecimal(2);
        return new(new(id), new(owner), balance);
    }
}
