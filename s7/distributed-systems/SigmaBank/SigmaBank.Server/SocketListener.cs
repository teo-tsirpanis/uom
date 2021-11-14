using System.Net;
using System.Net.Sockets;

namespace Dai19090.DistributedSystems.SigmaBank.Server;

/// <summary>
/// Asynchronously listens for connections in an endpoint.
/// </summary>
public sealed class SocketListener : IDisposable
{
    private readonly EndPoint _endPoint;
    private readonly Socket _socket;
    private readonly Func<Stream, CancellationToken, Task> _requestHandler;

    /// <summary>
    /// Creates a <see cref="SocketListener"/>.
    /// </summary>
    /// <param name="ep">The <see cref="EndPoint"/> to listen at.</param>
    /// <param name="requestHandler">The function that handles the request.
    /// It accepts a standard .NET <see cref="Stream"/>.</param>
    public SocketListener(EndPoint ep, Func<Stream, CancellationToken, Task> requestHandler)
    {
        _endPoint = ep;
        _socket = new Socket(ep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        _requestHandler = requestHandler;
    }

    private async Task HandleRequest(Socket client, CancellationToken cancellationToken)
    {
        using (client)
        {
            await using var stream = new NetworkStream(client);
            await _requestHandler(stream, cancellationToken);
        }
    }

    /// <summary>
    /// Listens for incoming connections and processes them.
    /// </summary>
    /// <param name="cancellationToken">Used to control
    /// when the listening will stop.</param>
    /// <returns>A task that will not complete until listening completes.</returns>
    public async Task ListenAsync(CancellationToken cancellationToken)
    {
        _socket.Bind(_endPoint);
        _socket.Listen();

        while (true)
            try
            {
                var client = await _socket.AcceptAsync(cancellationToken);
                Console.WriteLine($"Client connected from {client.RemoteEndPoint}");
                // We do not await because we want to continue accepting new connections.
                _ = HandleRequest(client, cancellationToken);
            }
            catch (OperationCanceledException oce) when (oce.CancellationToken == cancellationToken)
            {
                Console.WriteLine("Socket listener cancelled.");
                break;
            }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Console.WriteLine("Disposing socket");
        _socket.Dispose();
    }
}
