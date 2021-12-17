namespace Dai19090.SimulationTechniques.ElevatorSim.Randomness;

/// <summary>
/// Extension methods for <see cref="IRandomNumberGenerator"/>s.
/// </summary>
internal static class RandomNumberGeneratorExtensions
{
    /// <summary>
    /// Returns a random 32-bit floating-point number between zero and one, exclusive.
    /// </summary>
    /// <param name="random">The <see cref="IRandomNumberGenerator"/> to use.</param>
    public static float NextSingleUniform01Open(this IRandomNumberGenerator random)
    {
        return ((random.NextUInt32() >> 9) + 0.5f) * (1 / (2 << 23));
    }

    /// <summary>
    /// Returns a random 32-bit floating-point number that follows the exponential distribution
    /// with the given <paramref name="rate"/>.
    /// </summary>
    /// <param name="random">The <see cref="IRandomNumberGenerator"/> to use.</param>
    /// <param name="rate">The exponential distribution's rate parameter.</param>
    public static float NextSingleExponential(this IRandomNumberGenerator random, float rate)
    {
        return -MathF.Log(random.NextSingleUniform01Open()) / rate;
    }
}
