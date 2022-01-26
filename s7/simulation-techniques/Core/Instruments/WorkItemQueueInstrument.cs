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
    public int TotalProductiveTimeUnits { get; private set; }

    /// <summary>
    /// The total number of work items that were executed in this simulation.
    /// </summary>
    public int TotalWorkItems { get; private set; }

    public double SimulationPercentageInIdle => 1 - (double)TotalProductiveTimeUnits / SimulationDuration;

    public double AverageWorkItemsPerTimeUnit => (double)TotalWorkItems / SimulationDuration;

    public double AverageWorkItemsPerProductiveTimeUnit => (double)TotalWorkItems / TotalProductiveTimeUnits;

    internal WorkItemQueueInstrument() { }

    internal void WorkItemRan()
    {
        TotalWorkItems++;
    }

    void ISimulationInstrument.OnSimulationTimeChanged(Timestamp newTime)
    {
        SimulationDuration = newTime.Value;
        TotalProductiveTimeUnits++;
    }

    public void WriteResultsTo(TextWriter writer)
    {
        writer.WriteLine($"------------------WORK ITEM QUEUE STATISTICS------------------");
        writer.WriteLine($"Total work items executed: {TotalWorkItems}");
        writer.WriteLine($"Total time units passed: {SimulationDuration}");
        writer.WriteLine($"Total productive time units (with scheduled work items): {TotalProductiveTimeUnits}");
        writer.WriteLine($"Idle simulation time: {SimulationPercentageInIdle:P2}");
        writer.WriteLine($"Average work items per time unit: {AverageWorkItemsPerTimeUnit:G2}");
        writer.WriteLine($"Average work items per productive time unit: {AverageWorkItemsPerProductiveTimeUnit:G2}");
        writer.WriteLine();
    }
}
