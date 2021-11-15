using Dai19090.DistributedSystems.SigmaBank;
using Dai19090.DistributedSystems.SigmaBank.Client;
using System.Net;
using System.Net.Sockets;

var endpoint = TryParseEndpoint();
if (endpoint == null)
{
    Console.WriteLine("No server endpoint found.");
    return 1;
}

var bankClient = new BankClient(async ct => {
    var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    await socket.ConnectAsync(endpoint);
    return new NetworkStream(socket, ownsSocket: true);
});

var interactiveBank = new InteractiveBank(bankClient);
var cts = new CancellationTokenSource();
ErrorHandling.RegisterErrorHandlers(cts.Cancel, registerCtrlC: false);

await interactiveBank.RunAsync(cts.Token);

return 0;

EndPoint? TryParseEndpoint()
{
    var endpointString = Environment.GetEnvironmentVariable("SERVER_ENDPOINT");
    if (endpointString == null)
        return null;
    IPEndPoint.TryParse(endpointString, out var endPoint);
    return endPoint;
}
