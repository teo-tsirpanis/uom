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
}
