using Dai19090.DistributedSystems.SigmaBank;
using Dai19090.DistributedSystems.SigmaBank.Data;
using Dai19090.DistributedSystems.SigmaBank.Server;
using System.Net;

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

if (connectionString == null)
{
    Console.WriteLine("No connection string found.");
    return 1;
}

var endpoint = new IPEndPoint(IPAddress.Any, 5959);
var bank = await DatabaseUtilities.InitializeSqlServerDatabaseBankAsync(connectionString);
var rpcReceiver = new BankRpcReceiver(bank);
using var listener = new SocketListener(endpoint, rpcReceiver.ProcessRequestAsync);

var cts = new CancellationTokenSource();
ErrorHandling.RegisterErrorHandlers(cts.Cancel);

Console.WriteLine($"Listening on {endpoint}");
await listener.ListenAsync(cts.Token);
Console.WriteLine("Shutting down");

return 0;
