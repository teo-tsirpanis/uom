namespace Dai19090.SimulationTechniques;

/// <summary>
/// Measures and reports statistics about a simulation.
/// </summary>
public interface ISimulationInstrument
{
    /// <summary>
    /// This function is called when the simulation's time changes.
    /// </summary>
    /// <param name="newTime">The simulation's new time.</param>
    /// <remarks>
    /// To prevent user code from calling this function,
    /// this method should be implemented explicitly.
    /// </remarks>
    void OnSimulationTimeChanged(Timestamp newTime) { }

    /// <summary>
    /// Outputs the results of the instrument.
    /// </summary>
    /// <param name="writer">The <see cref="TextWriter"/>
    /// to write the results to.</param>
    /// <remarks>
    /// This method is called after the simulation has completed.
    /// Implementations are recommended to end their output with a blank line.
    /// </remarks>
    void WriteResultsTo(TextWriter writer);
}
