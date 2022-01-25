using System.Numerics;
using System.Runtime.CompilerServices;

namespace Dai19090.SimulationTechniques.Randomness;

/// <summary>
/// Describes a normal distribution.
/// </summary>
/// <param name="Mean">The distribution's mean.</param>
/// <param name="Stdev">The distribution's standard deviation.</param>
public record struct NormalDistribution(float Mean, float Stdev)
{
    public NormalDistribution(double mean, double stdev) : this((float) mean, (float) stdev) { }
}

/// <summary>
/// Extension methods for <see cref="IRandomNumberGenerator"/>s.
/// </summary>
public static class RandomNumberGeneratorExtensions
{
    // Code adapted from the .NET Base Class Library.
    // https://github.com/dotnet/runtime/blob/ae755ab3c7f838f7dccd2a4c2d5934a9d7d82c69/src/libraries/System.Private.CoreLib/src/System/Random.Xoshiro256StarStarImpl.cs#L113-L134
    public static int NextInt32UniformClosedOpen(this IRandomNumberGenerator random, int minValue, int maxValue)
    {
        uint exclusiveRange = (uint)((long)maxValue - minValue);

        if (exclusiveRange > 1)
        {
            // Narrow down to the smallest range [0, 2^bits] that contains maxValue.
            // Then repeatedly generate a value in that outer range until we get one within the inner range.
            int bits = Log2Ceiling(exclusiveRange);
            while (true)
            {
                ulong result = random.NextUInt32() >> (sizeof(uint) * 8 - bits);
                if (result < exclusiveRange)
                {
                    return (int)result + minValue;
                }
            }
        }

        return minValue;

        // Code adapted from the .NET Base Class Library.
        // https://github.com/dotnet/runtime/blob/ae755ab3c7f838f7dccd2a4c2d5934a9d7d82c69/src/libraries/System.Private.CoreLib/src/System/Numerics/BitOperations.cs#L374-L385
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int Log2Ceiling(uint value)
        {
            int result = BitOperations.Log2(value);
            if (BitOperations.PopCount(value) != 1)
            {
                result++;
            }
            return result;
        }
    }

    /// <summary>
    /// Returns a uniformly distrubited random 32-bit floating-point
    /// number bigger or equal to zero and smaller than one.
    /// </summary>
    /// <param name="random">The <see cref="IRandomNumberGenerator"/> to use.</param>
    public static float NextSingleUniform01ClosedOpen(this IRandomNumberGenerator random) =>
        // Code adapted from the .NET Base Class Library.
        // https://github.com/dotnet/runtime/blob/ae755ab3c7f838f7dccd2a4c2d5934a9d7d82c69/src/libraries/System.Private.CoreLib/src/System/Random.Xoshiro256StarStarImpl.cs#L254-L256
        (random.NextUInt32() >> 8) * (1.0f / (1u << 24));

    /// <summary>
    /// Returns a uniformly distributed random 32-bit floating-point
    /// number between zero and one, exclusive.
    /// </summary>
    /// <param name="random">The <see cref="IRandomNumberGenerator"/> to use.</param>
    public static float NextSingleUniform01Open(this IRandomNumberGenerator random) =>
        // Code adapted from FsRandom.
        // https://github.com/fsprojects/FsRandom/blob/0c43ba5caa2ebd0b9e2e2d16cb99f88284136470/src/FsRandom/Statistics.fs
        ((random.NextUInt32() >> 9) + 0.5f) * (1.0f / (2 << 23));

    /// <summary>
    /// Returns a random 32-bit floating-point number that follows the exponential distribution
    /// with the given <paramref name="rate"/>.
    /// </summary>
    /// <param name="random">The <see cref="IRandomNumberGenerator"/> to use.</param>
    /// <param name="rate">The exponential distribution's rate parameter.</param>
    public static float NextSingleExponential(this IRandomNumberGenerator random, float rate) =>
        -MathF.Log(random.NextSingleUniform01Open()) / rate;

    /// <summary>
    /// Returns a random 32-bit floating-point number that follows the standard normal distribution.
    /// </summary>
    /// <param name="random">The <see cref="IRandomNumberGenerator"/> to use.</param>
    public static float NextSingleStandardNormal(this IRandomNumberGenerator random)
    {
        float x;

        while (!PolarTransform(random.NextSingleUniform01ClosedOpen(), random.NextSingleUniform01ClosedOpen(), out x, out _)) ;

        return x;

        // Code adapted from Math.NET Numerics
        // https://github.com/mathnet/mathnet-numerics/blob/3f43fa9d8d92c7e72466dabcab75bf1ffceec285/src/Numerics/Distributions/Normal.cs
        static bool PolarTransform(float a, float b, out float x, out float y)
        {
            var v1 = (2.0f*a) - 1.0f;
            var v2 = (2.0f*b) - 1.0f;
            var r = (v1*v1) + (v2*v2);
            if (r >= 1.0f || r == 0.0f)
            {
                x = 0;
                y = 0;
                return false;
            }

            var fac = MathF.Sqrt(-2.0f*MathF.Log(r)/r);
            x = v1*fac;
            y = v2*fac;
            return true;
        }
    }

    /// <summary>
    /// Returns a random 32-bit floating-point number that follows the specified normal distribution.
    /// </summary>
    /// <param name="random">The <see cref="IRandomNumberGenerator"/> to use.</param>
    /// <param name="distribution">The distribution the returned number will use.</param>
    public static float NextSingleNormal(this IRandomNumberGenerator random, NormalDistribution distribution) =>
        distribution.Mean + random.NextSingleStandardNormal() * distribution.Stdev;
}
