using Dai19090.DistributedSystems.SigmaBank;
using Dai19090.DistributedSystems.SigmaBank.Client;
using System.Net;
using System.Net.Sockets;

var endpoint = GetEndpoint();
if (endpoint == null)
{
    Console.WriteLine("You have to specify the server's remote endpoint in the command line (like 127.0.0.1:5959).");
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

EndPoint? GetEndpoint()
{
    if (args.Length != 1)
        return null;
    IPEndPoint.TryParse(args[0], out var endPoint);
    return endPoint;
}
