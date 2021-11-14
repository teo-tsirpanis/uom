using System.Data.Common;

namespace Dai19090.DistributedSystems.SigmaBank.Server;

public static class DatabaseUtilities
{

    public static readonly string Schema = @"
CREATE TABLE users (
    user_id int NOT NULL IDENTITY,
    name varchar(64) NOT NULL,
    surname varchar(64) NOT NULL,
    PRIMARY KEY (user_id)
)

CREATE TABLE accounts (
    account_id int NOT NULL IDENTITY,
    owner_id int NOT NULL,
    balance decimal(15, 2) NOT NULL DEFAULT 0,
    PRIMARY KEY (account_id),
    FOREIGN KEY (owner_id) REFERENCES users(user_id)
)";

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
