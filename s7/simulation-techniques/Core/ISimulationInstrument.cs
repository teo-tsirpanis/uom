namespace Dai19090.SimulationTechniques;

/// <summary>
/// Measures and reports statistics about a simulation.
/// </summary>
public interface ISimulationInstrument
{
    /// <summary>
    /// Outputs the results of the simulation.
    /// </summary>
    /// <param name="simulation">The <see cref="TextWriter"/>
    /// to write the results to.</param>
    /// <remarks>
    /// This method is called after the simulation has completed.
    /// </remarks>
    void WriteResultsTo(TextWriter writer);
}
