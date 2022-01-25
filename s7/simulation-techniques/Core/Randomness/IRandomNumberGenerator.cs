using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Dai19090.SimulationTechniques.Randomness;

/// <summary>
/// Abstracts a random number generator.
/// </summary>
public interface IRandomNumberGenerator
{
    /// <summary>
    /// Gets a random 32-bit unsigned integer.
    /// </summary>
    uint NextUInt32();

    /// <summary>
    /// Gets a random non-reproducible 64-bit seed.
    /// </summary>
    public static ulong GetRandomSeed()
    {
        Span<byte> buffer = stackalloc byte[sizeof(ulong)];
        RandomNumberGenerator.Fill(buffer);
        return MemoryMarshal.Read<ulong>(buffer);
    }
}
