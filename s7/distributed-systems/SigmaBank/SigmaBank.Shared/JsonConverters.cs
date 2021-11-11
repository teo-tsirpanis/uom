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
