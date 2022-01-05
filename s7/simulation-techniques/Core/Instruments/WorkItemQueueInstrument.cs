namespace Dai19090.SimulationTechniques.Instruments;

/// <summary>
/// Measures statistics about the simulation's own work item queue.
/// </summary>
/// <remarks>
/// Such instrument is automatically added when a simulation starts.
/// Adding it again will cause an error.
/// </remarks>
public sealed class WorkItemQueueInstrument : ISimulationInstrument
{
    /// <summary>
    /// The simulation's duration in time units.
    /// </summary>
    public int SimulationDuration { get; private set; }

    /// <summary>
    /// The simulation's time units where work items were executed.
    /// </summary>
    public int TotalFruitfulTimeUnits { get; private set; }

    /// <summary>
    /// The total number of work items that were executed in this simulation.
    /// </summary>
    public int TotalWorkItems { get; private set; }

    internal void WorkItemRan()
    {
        TotalWorkItems++;
    }

    internal void SimulationTimeChanged(Timestamp newTime)
    {
        SimulationDuration = newTime.Value;
        TotalFruitfulTimeUnits++;
    }

    public void WriteResultsTo(TextWriter writer)
    {
        writer.WriteLine($"------------------WORK ITEM QUEUE STATISTICS------------------");
        writer.WriteLine($"Total work items executed: {TotalWorkItems}");
        writer.WriteLine($"Total time units passed: {SimulationDuration}");
        writer.WriteLine($"Total fruitful time units (with scheduled work items): {TotalFruitfulTimeUnits}");
        writer.WriteLine($"Idle simulation time: {1 - (double)TotalFruitfulTimeUnits / SimulationDuration:P2}");
        writer.WriteLine($"Average work items per time unit: {TotalWorkItems / (double)SimulationDuration:G2}");
        writer.WriteLine($"Average work items per fruitful time unit: {TotalWorkItems / (double)TotalFruitfulTimeUnits:G2}");
        writer.WriteLine();
    }
}
