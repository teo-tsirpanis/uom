using System.Numerics;

namespace Dai19090.SimulationTechniques.ElevatorSim.Randomness;

/// <summary>
/// An implementation of <see cref="IRandomNumberGenerator"/> that
/// is powered by the PCG-XSH-RR generator. It has 64 bits of state.
/// </summary>
internal sealed class Pcg32Generator : IRandomNumberGenerator
{
    private const ulong Multiplier = 6364136223846793005;
    private const ulong Increment = 1442695040888963407;

    private ulong _state;

    private void Step()
    {
        _state = _state * Multiplier + Increment;
    }

    private static uint Output(ulong x)
    {
        return BitOperations.RotateRight((uint)((x ^ (x >> 18)) >> 27), (int)(x >> 59));
    }

    /// <summary>
    /// Creates a <see cref="Pcg32Generator"/>.
    /// </summary>
    /// <param name="seed">The generator's seed.</param>
    public Pcg32Generator(ulong seed)
    {
        _state = 0;
        Step();
        _state += seed;
        Step();
    }

    /// <inheritdoc/>
    public uint NextUInt32()
    {
        ulong oldState = _state;
        Step();
        return Output(oldState);
    }
}
