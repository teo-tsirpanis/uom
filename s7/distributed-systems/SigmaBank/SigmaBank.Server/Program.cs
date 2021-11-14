using Dai19090.DistributedSystems.SigmaBank.Server;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Runtime.InteropServices;

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

    command.CommandText = DatabaseUtilities.Schema;

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
