namespace Dai19090.SimulationTechniques;

public readonly struct Timestamp : IEquatable<Timestamp>, IComparable<Timestamp>
{
    public readonly int Value;

    public Timestamp(int value)
    {
        if (value < 0)
            ThrowHelpers.ThrowNegativeNumber(nameof(value), value);
        Value = value;
    }

    public int CompareTo(Timestamp other) => Value.CompareTo(other.Value);

    public bool Equals(Timestamp other) => Value == other.Value;

    public override bool Equals(object? obj) => obj is Timestamp x && x.Value == Value;

    public override int GetHashCode() => Value;

    public override string ToString() => Value.ToString();

    public static Timestamp operator +(Timestamp ts, int offset)
    {
        if (offset < 0)
            ThrowHelpers.ThrowNegativeNumber(nameof(offset), offset);
        return new(ts.Value + offset);
    }

    public static int operator -(Timestamp x1, Timestamp x2) =>
        x1.Value - x2.Value;

    public static bool operator ==(Timestamp left, Timestamp right) => left.Equals(right);

    public static bool operator !=(Timestamp left, Timestamp right) => !(left == right);
}
