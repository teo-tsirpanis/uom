using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace Dai19090.DistributedSystems.SigmaBank.Data;

public static class DatabaseUtilities
{

    private static readonly string Schema = @"
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

    internal static UserInfo GetUserInfo(DbDataReader reader)
    {
        var id = reader.GetInt32(0);
        var name = reader.GetString(1);
        var surname = reader.GetString(2);
        return new(new(id), name, surname);
    }

    internal static AccountInfo GetAccountInfo(DbDataReader reader)
    {
        var id = reader.GetInt32(0);
        var owner = reader.GetInt32(1);
        var balance = reader.GetDecimal(2);
        return new(new(id), new(owner), balance);
    }

    static async Task InitializeDatabaseSchema(DbConnection connection)
    {
        await connection.OpenAsync();
        using var command = connection.CreateCommand();
        command.CommandText = Schema;
        var o = await command.ExecuteScalarAsync();
    }

    /// <summary>
    /// Connects to an SQL Server database, initializes its schema and
    /// returns an object implementing <see cref="IBank"/> that works with it.
    /// </summary>
    /// <param name="connectionString">The database's connection string.</param>
    public static async Task<IBank> InitializeSqlServerDatabaseBankAsync(string connectionString)
    {
        var connectionFactory = () => new SqlConnection(connectionString);

        try
        {
            await using (var connection = connectionFactory())
                await InitializeDatabaseSchema(connection);
            Console.WriteLine("Database schema initialized.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Initializing database schema failed: {e}");
        }

        return new AdoNetBank(connectionFactory);
    }
}
