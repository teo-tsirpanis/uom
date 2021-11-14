using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Dai19090.DistributedSystems.SigmaBank;

/// <summary>
/// Implements the client side of SigmaBank's RPC protocol.
/// </summary>
/// <seealso cref="AbstractRpcReceiver"/>
public static class RpcSender
{
    private static bool DecomposeResponseMessage(JsonElement json, out JsonElement result, [NotNullWhen(false)] out string? message)
    {
        var successful = json.GetProperty(JsonConstants.Successful).GetBoolean();
        if (successful)
        {
            result = json.GetProperty(JsonConstants.Result);
            message = null;
        }
        else
        {
            result = default;
            message = json.GetProperty(JsonConstants.Message).GetString();
        }
        return successful;
    }

    /// <summary>
    /// Sends an RPC request and asynchronously waits for a reply.
    /// </summary>
    /// <typeparam name="T">The reply's type. It must be deserializable from JSON.</typeparam>
    /// <param name="stream">A bidirectional stream that represents the
    /// communication channel between the server and the client.</param>
    /// <param name="fSetArguments">Used to write the request's arguments to a <see cref="Utf8JsonWriter"/>.</param>
    /// <param name="state">A parameter to <paramref name="fSetArguments"/>.</param>
    /// <param name="cancellationToken">Used to cancel the operation.</param>
    /// <param name="commandName">The command's name. The compiler will automatically set it.</param>
    public static async Task<T> SendAsync<T, TParameters>(Stream stream, Action<Utf8JsonWriter, TParameters> fSetArguments, TParameters state,
        CancellationToken cancellationToken = default, [CallerMemberName] string commandName = "")
    {
        await using (var writer = new Utf8JsonWriter(stream))
        {
            writer.WriteStartObject();
            writer.WriteNumber(JsonEncodedTexts.ProtocolVersion, JsonConstants.ProtocolVersionValue);
            writer.WriteString(JsonEncodedTexts.CommandName, commandName);
            writer.WritePropertyName(JsonEncodedTexts.Arguments);
            writer.WriteStartArray();
            fSetArguments(writer, state);
            writer.WriteEndArray();
            writer.WriteEndObject();

            await writer.FlushAsync(cancellationToken);
        }

        using var response = await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken);
        if (DecomposeResponseMessage(response.RootElement, out var result, out var message))
            return JsonSerializer.Deserialize<T>(result)!;
        else
            throw new BankException(message);
    }
}
