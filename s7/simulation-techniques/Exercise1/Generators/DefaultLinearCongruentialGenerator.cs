namespace Dai19090.SimulationTechniques.RandomNumbers.Generators;

public sealed class DefaultLinearCongruentialGenerator : IRandomNumberGenerator
{
    private int _x;

    private const int a = 1103515245;
    private const int c = 12345;
    // We want to apply mod 2^31 to the result, which means that we will bitwise
    // and with 2^31 - 1, which is the maximum value a signed 32-bit integer can take.
    private const int m_mask = int.MaxValue;

    private static int Step(int x) => ((a * x) + c) & m_mask;

    private static double ToFraction(int x) => x * (1.0 / (1UL << 31));

    public DefaultLinearCongruentialGenerator(int seed)
    {
        // Force it to be positive.
        _x = seed & m_mask;
    }

    public double NextDouble() => ToFraction(_x = Step(_x));
}
