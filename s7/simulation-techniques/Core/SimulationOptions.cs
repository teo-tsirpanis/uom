using Dai19090.SimulationTechniques.Randomness;

namespace Dai19090.SimulationTechniques;

/// <summary>
/// Contains system options for a simulation.
/// </summary>
/// <remarks>
/// This class can be subclassed to provide application-specific options.
/// </remarks>
public class SimulationOptions
{
    /// <summary>
    /// The <see cref="IRandomNumberGenerator"/> that will be used.
    /// </summary>
    public IRandomNumberGenerator RandomNumberGenerator { get; set; }

    /// <summary>
    /// The action that will be called when a message needs to be logged.
    /// </summary>
    public event Action<string>? OnLogMessage;

    /// <summary>
    /// Creates a <see cref="SimulationOptions"/>.
    /// </summary>
    /// <param name="randomNumberGenerator">The initial value of <see cref="RandomNumberGenerator"/>.</param>
    public SimulationOptions(IRandomNumberGenerator randomNumberGenerator)
    {
        ArgumentNullException.ThrowIfNull(randomNumberGenerator);
        RandomNumberGenerator = randomNumberGenerator;
    }

    internal Action<string>? GetOnLogMessage() => OnLogMessage;
}
