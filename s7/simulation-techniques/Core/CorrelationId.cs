namespace Dai19090.SimulationTechniques;

/// <summary>
/// Helps with logging actions by the same entity.
/// </summary>
/// <seealso cref="ISimulationState.NewCorrelationId" />
public readonly struct CorrelationId : IEquatable<CorrelationId>
{
    /// <summary>
    /// The default correlation ID. Its value is zero.
    /// </summary>
    public static CorrelationId Default => new(0);

    /// <summary>
    /// The value of the correlation ID.
    /// </summary>
    public int Value { get; }

    /// <summary>
    /// Whether the correlation ID is the default one.
    /// </summary>
    public bool IsDefault => Value == 0;

    /// <inheritdoc />
    public bool Equals(CorrelationId other) => Value == other.Value;

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is CorrelationId id && Value == id.Value;

    /// <inheritdoc />
    public override int GetHashCode() => Value;

    public static bool operator ==(CorrelationId left, CorrelationId right) => left.Equals(right);

    public static bool operator !=(CorrelationId left, CorrelationId right) => !(left == right);

    internal CorrelationId(int value)
    {
        Value = value;
    }

    internal CorrelationId Next() => new(Value + 1);
}
