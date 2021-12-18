namespace Dai19090.SimulationTechniques;

/// <summary>
/// Represents a standalone action that is run by a simulation and is scheduled at a specific time.
/// </summary>
/// <remarks>
/// Work items are scheduled to run at a specific time measured in simulation time units, in such order
/// that work items scheduled for a prior time are run before work items scheduled for a later time.
/// All work items run sequentially in the same thread.
/// </remarks>
public interface ISimulationWorkItem
{
    /// <summary>
    /// Runs the work item.
    /// </summary>
    void Run();
}
