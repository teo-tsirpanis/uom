using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;

namespace Dai19090.DistributedSystems.SigmaBank.Server;

/// <summary>
/// Implements the server side of SigmaBank's RPC protocol.
/// </summary>
public sealed class BankRpcReceiver : AbstractRpcReceiver
{
    private readonly IBank _bank;

    public BankRpcReceiver(IBank bank)
    {
        _bank = bank;
    }

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

    private static string DisplayJsonToString(JsonElement json)
    {
        var bw = new ArrayBufferWriter<byte>();
        using var writer = new Utf8JsonWriter(bw);
        json.WriteTo(writer);
        writer.Flush();
        return Encoding.UTF8.GetString(bw.WrittenSpan);
    }

    protected override async Task<object?> ProcessCommandAsync(string commandName, JsonElement args, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Received command {commandName} with arguments {DisplayJsonToString(args)}");

        switch (commandName)
        {
            case nameof(IBank.CreateUserAsync):
                AssertIsArray(args, 2);
                var name = args[0].GetString();
                var surname = args[1].GetString();
                ArgumentValidation.ValidateAcountCreation(name, surname);
                return await _bank.CreateUserAsync(name, surname, cancellationToken);

            case nameof(IBank.GetUserInfoAsync):
                AssertIsArray(args, 1);
                var userId = args[0].Deserialize<UserId>();
                AssertNotNull(userId);
                return await _bank.GetUserInfoAsync(userId, cancellationToken);

            case nameof(IBank.CreateAccountAsync):
                AssertIsArray(args, 1);
                var ownerId = args[0].Deserialize<UserId>();
                AssertNotNull(ownerId);
                return await _bank.CreateAccountAsync(ownerId, cancellationToken);

            case nameof(IBank.GetAccountInfoAsync):
                AssertIsArray(args, 1);
                var accountId = args[0].Deserialize<AccountId>();
                AssertNotNull(accountId);
                return await _bank.GetAccountInfoAsync(accountId, cancellationToken);

            case nameof(IBank.DepositAsync):
                AssertIsArray(args, 2);
                accountId = args[0].Deserialize<AccountId>();
                var amount = args[1].GetDecimal();
                AssertNotNull(accountId);
                ArgumentValidation.ValidateCurrencyAmount(amount);
                return await _bank.DepositAsync(accountId, amount, cancellationToken);

            case nameof(IBank.WithdrawAsync):
                AssertIsArray(args, 2);
                accountId = args[0].Deserialize<AccountId>();
                amount = args[1].GetDecimal();
                AssertNotNull(accountId);
                ArgumentValidation.ValidateCurrencyAmount(amount);
                return await _bank.WithdrawAsync(accountId, amount, cancellationToken);

            case nameof(IBank.TransferAsync):
                AssertIsArray(args, 3);
                var originAccountId = args[0].Deserialize<AccountId>();
                var destinationAccountId = args[1].Deserialize<AccountId>();
                amount = args[2].GetDecimal();
                AssertNotNull(originAccountId);
                AssertNotNull(destinationAccountId);
                ArgumentValidation.ValidateCurrencyAmount(amount);
                return await _bank.TransferAsync(originAccountId, destinationAccountId, amount, cancellationToken);

            default:
                ThrowInvalidOperationException($"Unknown command name: {commandName}");
                return null!;
        }
    }
}
