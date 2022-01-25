namespace Dai19090.SimulationTechniques.Instruments;

/// <summary>
/// Measures statistics about the simulation's own work item queue.
/// </summary>
/// <remarks>
/// Such instrument is automatically added when a simulation starts.
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

    public double SimulationTimeInIdle => 1 - (double)TotalFruitfulTimeUnits / SimulationDuration;

    public double AverageWorkItemsPerTimeUnit => (double)TotalWorkItems / SimulationDuration;

    public double AverageWorkItemsPerFruitfulTimeUnit => (double)TotalWorkItems / TotalFruitfulTimeUnits;

    internal WorkItemQueueInstrument() { }

    internal void WorkItemRan()
    {
        TotalWorkItems++;
    }

    void ISimulationInstrument.OnSimulationTimeChanged(Timestamp newTime)
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
        writer.WriteLine($"Idle simulation time: {SimulationTimeInIdle:P2}");
        writer.WriteLine($"Average work items per time unit: {AverageWorkItemsPerTimeUnit:G2}");
        writer.WriteLine($"Average work items per fruitful time unit: {AverageWorkItemsPerFruitfulTimeUnit:G2}");
        writer.WriteLine();
    }
}
