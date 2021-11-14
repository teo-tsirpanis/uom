using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dai19090.DistributedSystems.SigmaBank;

/// <summary>
/// Ensures that <see cref="UserId"/> is serialized into a plain JSON number.
/// </summary>
internal sealed class UserIdConverter : JsonConverter<UserId>
{
    public override bool HandleNull => false;

    public override UserId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        new(reader.GetInt32());

    public override void Write(Utf8JsonWriter writer, UserId value, JsonSerializerOptions options) =>
        writer.WriteNumberValue(value.Id);
}

/// <summary>
/// Ensures that <see cref="AccountId"/> is serialized into a plain JSON number.
/// </summary>
internal sealed class AccountIdConverter : JsonConverter<AccountId>
{
    public override bool HandleNull => false;

    public override AccountId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        new(reader.GetInt32());

    public override void Write(Utf8JsonWriter writer, AccountId value, JsonSerializerOptions options) =>
        writer.WriteNumberValue(value.Id);
}

public static class JsonConstants
{
    /// <summary>
    /// The protocol's version.
    /// </summary>
    /// <remarks>
    /// It is communicated from the client to the server and
    /// if it is different than what the server expects, the
    /// request is aborted.
    /// </remarks>
    public static readonly int ProtocolVersionValue = 1;

    public static readonly string ProtocolVersion = nameof(ProtocolVersion);
    public static readonly string CommandName = nameof(CommandName);
    public static readonly string Arguments = nameof(Arguments);

    public static readonly string Successful = nameof(Successful);
    public static readonly string Message = nameof(Message);
    public static readonly string Result = nameof(Result);
}

public static class JsonEncodedTexts
{
    public static readonly JsonEncodedText ProtocolVersion = JsonEncodedText.Encode(JsonConstants.ProtocolVersion);
    public static readonly JsonEncodedText CommandName = JsonEncodedText.Encode(JsonConstants.CommandName);
    public static readonly JsonEncodedText Arguments = JsonEncodedText.Encode(JsonConstants.Arguments);

    public static readonly JsonEncodedText Successful = JsonEncodedText.Encode(JsonConstants.Successful);
    public static readonly JsonEncodedText Message = JsonEncodedText.Encode(JsonConstants.Message);
    public static readonly JsonEncodedText Result = JsonEncodedText.Encode(JsonConstants.Result);
}
