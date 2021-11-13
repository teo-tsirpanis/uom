using Dai19090.DistributedSystems.SigmaBank.Server;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Runtime.InteropServices;

const string DatabaseSchema = @"
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

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

if (connectionString == null)
{
    Console.WriteLine("No connection string found.");
    return 1;
}

var connectionFactory = () => new SqlConnection(connectionString);

try
{
    await InitializeDatabaseSchema();
    Console.WriteLine("Database schema initialized.");
}
catch (Exception e)
{
    Console.WriteLine($"Initializing database schema failed: {e}");
}

var endpoint = new IPEndPoint(IPAddress.Any, 5959);
var bank = new BankImplementation(connectionFactory);
var rpcReceiver = new RpcReceiver(bank);
using var listener = new SocketListener(endpoint, rpcReceiver.ProcessRequestAsync);

var cts = new CancellationTokenSource();
RegisterErrorHandlers(cts.Cancel);

Console.WriteLine($"Listening on {endpoint}");
await listener.ListenAsync(cts.Token);
Console.WriteLine("Shutting down");

return 0;

async Task InitializeDatabaseSchema()
{
    await using var connection = connectionFactory();

    await connection.OpenAsync();

    using var command = connection.CreateCommand();

    command.CommandText = DatabaseSchema;

    var o = await command.ExecuteScalarAsync();
}

static void RegisterErrorHandlers(Action doCancel)
{
    Console.CancelKeyPress += (sender, e) =>
    {
        e.Cancel = true;
        Console.WriteLine("Received console signal, shutting down...");
        doCancel();
    };

    PosixSignalRegistration.Create(PosixSignal.SIGTERM, _ =>
    {
        Console.WriteLine("Received SIGTERM, shutting down...");
        doCancel();
    });

    TaskScheduler.UnobservedTaskException += (sender, e) =>
    {
        Console.WriteLine($"Unobserved task exception: {e.Exception}");
    };
}
