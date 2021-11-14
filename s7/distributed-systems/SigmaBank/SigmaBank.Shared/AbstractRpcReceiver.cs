using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Dai19090.DistributedSystems.SigmaBank;

/// <summary>
/// Τhe server side of a simple JSON-based RPC protocol.
/// </summary>
public abstract class AbstractRpcReceiver
{
    [DoesNotReturn]
    protected static void ThrowInvalidOperationException(string? message = null) =>
        throw new InvalidOperationException(message);

    private static void DecomposeRequestMessage(JsonElement json, out string commandName, out JsonElement arguments)
    {
        var protocolVersion = json.GetProperty(JsonConstants.ProtocolVersion).GetInt32();
        if (protocolVersion != JsonConstants.ProtocolVersionValue)
            ThrowInvalidOperationException($"Invalid protocol version.");

        var name = json.GetProperty(JsonConstants.CommandName).GetString();
        if (name == null)
            ThrowInvalidOperationException("Missing command name.");
        commandName = name;
        arguments = json.GetProperty(JsonConstants.Arguments);
    }

    /// <summary>
    /// Asynchronously processes an RPC command.
    /// </summary>
    /// <param name="commandName"></param>
    /// <param name="commandArguments"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected abstract Task<object?> ProcessCommandAsync(string commandName, JsonElement commandArguments, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously receives and replies to an RPC request.
    /// </summary>
    /// <param name="stream">A bidirectional stream that represents the
    /// communication channel between the server and the client.</param>
    /// <param name="cancellationToken">Used to cancel the operation.</param>
    /// <remarks>
    /// This method tries to decode the incoming JSON message, extracts the
    /// command name and arguments, calls <see cref="ProcessCommandAsync"/>
    /// to get the response, and serializes it back to the client.
    /// </remarks>
    public async Task ProcessRequestAsync(Stream stream, CancellationToken cancellationToken)
    {
        object? response = null;
        var succeeded = false;
        var errorMessage = "";

        try
        {
            using var doc = await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken);
            DecomposeRequestMessage(doc.RootElement, out var commandName, out var commandArguments);
            response = await ProcessCommandAsync(commandName, commandArguments, cancellationToken);
            succeeded = true;
        }
        catch (BankException e)
        {
            Console.WriteLine($"Operation failed in a user-visible way: {e}");
            errorMessage = e.Message;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Operation failed: {e}");
            errorMessage = "Operation failed.";
        }

        await using var responseWriter = new Utf8JsonWriter(stream);
        responseWriter.WriteStartObject();
        responseWriter.WriteBoolean(JsonEncodedTexts.Successful, succeeded);
        if (succeeded)
        {
            responseWriter.WritePropertyName(JsonEncodedTexts.Result);
            JsonSerializer.Serialize(responseWriter, response, response?.GetType() ?? typeof(object));
        }
        else
        {
            responseWriter.WriteString(JsonEncodedTexts.Message, errorMessage);
        }
        responseWriter.WriteEndObject();
        await responseWriter.FlushAsync(cancellationToken);
    }
}
