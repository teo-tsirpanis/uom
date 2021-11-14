using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;

namespace Dai19090.DistributedSystems.SigmaBank.Server;

/// <summary>
/// Implements the server side of SigmaBank's RPC protocol.
/// </summary>
public sealed class RpcReceiver
{
    private readonly IBank _bank;

    public RpcReceiver(IBank bank)
    {
        _bank = bank;
    }

    [DoesNotReturn]
    private static void ThrowInvalidOperationException(string? message = null) =>
        throw new InvalidOperationException(message);

    private static void AssertNotNull<T>([NotNull] T? x) where T : class
    {
        if (x == null)
            ThrowInvalidOperationException();
    }

    private static void AssertIsArray(JsonElement json, int expectedLength)
    {
        if (json.ValueKind != JsonValueKind.Array || json.GetArrayLength() != expectedLength)
            ThrowInvalidOperationException("Incorrect number of arguments expected");
    }

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

    private static string DisplayJsonToString(JsonElement json)
    {
        var bw = new ArrayBufferWriter<byte>();
        using var writer = new Utf8JsonWriter(bw);
        json.WriteTo(writer);
        writer.Flush();
        return Encoding.UTF8.GetString(bw.WrittenSpan);
    }

    private async Task<object?> ProcessJsonRequest(JsonElement json, CancellationToken cancellationToken)
    {
        DecomposeRequestMessage(json, out var commandName, out var commandArguments);

        Console.WriteLine($"Received command {commandName} with arguments {DisplayJsonToString(commandArguments)}");

        switch (commandName)
        {
            case nameof(IBank.CreateUserAsync):
                AssertIsArray(json, 2);
                var name = json[0].GetString();
                var surname = json[1].GetString();
                ArgumentValidation.ValidateAcountCreation(name, surname);
                return await _bank.CreateUserAsync(name, surname, cancellationToken);

            case nameof(IBank.GetUserInfoAsync):
                AssertIsArray(json, 1);
                var userId = json[0].Deserialize<UserId>();
                AssertNotNull(userId);
                return await _bank.GetUserInfoAsync(userId, cancellationToken);

            case nameof(IBank.CreateAccountAsync):
                AssertIsArray(json, 1);
                var ownerId = json[0].Deserialize<UserId>();
                AssertNotNull(ownerId);
                return await _bank.CreateAccountAsync(ownerId, cancellationToken);

            case nameof(IBank.GetAccountInfoAsync):
                AssertIsArray(json, 1);
                var accountId = json[0].Deserialize<AccountId>();
                AssertNotNull(accountId);
                return await _bank.GetAccountInfoAsync(accountId, cancellationToken);

            case nameof(IBank.DepositAsync):
                AssertIsArray(json, 2);
                accountId = json[0].Deserialize<AccountId>();
                var amount = json[1].GetDecimal();
                AssertNotNull(accountId);
                ArgumentValidation.ValidateCurrencyAmount(amount);
                return await _bank.DepositAsync(accountId, amount, cancellationToken);

            case nameof(IBank.WithdrawAsync):
                AssertIsArray(json, 2);
                accountId = json[0].Deserialize<AccountId>();
                amount = json[1].GetDecimal();
                AssertNotNull(accountId);
                ArgumentValidation.ValidateCurrencyAmount(amount);
                return await _bank.WithdrawAsync(accountId, amount, cancellationToken);

            case nameof(IBank.TransferAsync):
                AssertIsArray(json, 3);
                var originAccountId = json[0].Deserialize<AccountId>();
                var destinationAccountId = json[1].Deserialize<AccountId>();
                amount = json[2].GetDecimal();
                AssertNotNull(originAccountId);
                AssertNotNull(destinationAccountId);
                ArgumentValidation.ValidateCurrencyAmount(amount);
                return await _bank.TransferAsync(originAccountId, destinationAccountId, amount, cancellationToken);

            default:
                ThrowInvalidOperationException($"Unknown command name: {commandName}");
                return null!;
        }
    }

    /// <summary>
    /// Asynchronously processes an RPC request.
    /// </summary>
    /// <param name="stream">A bidirectional stream that represents the connection.</param>
    /// <param name="cancellationToken">Used to cancel the operation.</param>
    public async Task ProcessRequestAsync(Stream stream, CancellationToken cancellationToken)
    {
        object? response = null;
        var succeeded = false;
        var errorMessage = "";

        try
        {
            using var doc = await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken);
            response = await ProcessJsonRequest(doc.RootElement, cancellationToken);
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
