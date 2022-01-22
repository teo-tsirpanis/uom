namespace Dai19090.SimulationTechniques;

/// <summary>
/// Helps with logging actions by the same entity.
/// </summary>
public readonly struct CorrelationId : IEquatable<CorrelationId>
{
    /// <summary>
    /// The default correlation ID. Its value is zero.
    /// </summary>
    public static CorrelationId Default => new();

    /// <summary>
    /// The value of the correlation ID.
    /// </summary>
    public string? Value { get; }

    /// <summary>
    /// Whether the correlation ID is the default one.
    /// </summary>
    public bool IsDefault => Value is null;

    /// <inheritdoc />
    public bool Equals(CorrelationId other) => Value == other.Value;

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is CorrelationId id && Value == id.Value;

    /// <inheritdoc />
    public override int GetHashCode() => Value?.GetHashCode() ?? 0;

    /// <returns>
    /// <see cref="Value"/> or an empty string if it is <see langword="null"/>.
    /// </returns>
    public override string ToString() => Value?.ToString() ?? "<null>";

    public static bool operator ==(CorrelationId left, CorrelationId right) => left.Equals(right);

    public static bool operator !=(CorrelationId left, CorrelationId right) => !(left == right);

    /// <summary>
    /// Creates a <see cref="CorrelationId"/>
    /// </summary>
    /// <param name="value">The correlation ID's value.</param>
    public CorrelationId(string value)
    {
        Value = value;
    }
}
