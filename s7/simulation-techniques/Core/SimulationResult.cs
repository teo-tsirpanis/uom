namespace Dai19090.SimulationTechniques;

/// <summary>
/// The results of a simulation.
/// </summary>
public sealed class SimulationResult
{
    /// <summary>
    /// The simulation's duration in time units.
    /// </summary>
    public int Duration { get; }

    /// <summary>
    /// The simulation's registered <see cref="ISimulationInstrument"/>s.
    /// </summary>
    public ISimulationInstrument[] Instruments { get; }

    /// <summary>
    /// Creates a <see cref="SimulationResult"/>.
    /// </summary>
    public SimulationResult(int duration, ISimulationInstrument[] instruments)
    {
        Duration = duration;
        Instruments = instruments;
    }
}
