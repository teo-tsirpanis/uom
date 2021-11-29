using Dai19090.DistributedSystems.SigmaBank;
using Dai19090.DistributedSystems.SigmaBank.Client;
using Dai19090.DistributedSystems.SigmaBank.Transport.Grpc;
using Grpc.Net.Client;
using System.Net;
using System.Net.Sockets;

var cts = new CancellationTokenSource();
ErrorHandling.RegisterErrorHandlers(cts.Cancel, registerCtrlC: false);

Console.Write("Select your protocol(1 - sockets, 2 - gRPC): ");
if (int.TryParse(Console.ReadLine(), out var response))
    switch (response)
    {
        case 1:
            return await SocketMain(cts.Token);
        case 2:
            return await GrpcMain(cts.Token);
    }

Console.WriteLine("Invalid response");
return 1;

static async Task<int> SocketMain(CancellationToken cancellationToken)
{
    var endpoint = TryParseEndpoint();
    if (endpoint == null)
    {
        Console.WriteLine("No server endpoint found.");
        return 1;
    }

    var bankClient = new BankClient(async ct =>
    {
        var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        await socket.ConnectAsync(endpoint);
        return new NetworkStream(socket, ownsSocket: true);
    });

    var interactiveBank = new InteractiveBank(bankClient);

    await interactiveBank.RunAsync(cancellationToken);

    return 0;

    EndPoint? TryParseEndpoint()
    {
        var endpointString = Environment.GetEnvironmentVariable("SOCKETS_ENDPOINT");
        if (endpointString == null)
            return null;
        IPEndPoint.TryParse(endpointString, out var endPoint);
        return endPoint;
    }
}

static async Task<int> GrpcMain(CancellationToken cancellationToken)
{
    var endpoint = Environment.GetEnvironmentVariable("GRPC_ENDPOINT");
    if (endpoint == null)
    {
        Console.WriteLine("No gRPC endpoint found.");
        return 1;
    }

    using var channel = GrpcChannel.ForAddress(endpoint);
    var bank = new BankGrpcSender(new Bank.BankClient(channel));
    var interactiveBank = new InteractiveBank(bank);

    await interactiveBank.RunAsync(cancellationToken);

    return 0;
}
