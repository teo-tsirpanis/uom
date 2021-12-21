using Dai19090.SimulationTechniques.Infrastructure;
using Dai19090.SimulationTechniques.Randomness;

namespace Dai19090.SimulationTechniques;

/// <summary>
/// Controls an ongoing simulation.
/// </summary>
public interface ISimulationState
{
    /// <summary>
    /// The current time the simulation is at, measured in arbitrary time units.
    /// </summary>
    /// <remarks>
    /// This value is updated only by queueing work items to run in the future, and
    /// may skip some values. For example, if we are at time 10 and queue a work item
    /// to run after 4 time units, the simulation will jump to time 14.
    /// </remarks>
    Timestamp CurrentTime { get; }

    /// <summary>
    /// A source of random numbers used by the simulation.
    /// </summary>
    /// <remarks>
    /// To ensure reproducibility, simulation code should not use any other random
    /// number generators like <see cref="System.Random"/>.
    /// </remarks>
    IRandomNumberGenerator Random { get; }

    /// <summary>
    /// Queues a work item to be run at a later time. User code should not call this method.
    /// </summary>
    /// <param name="workItem">The work item to run.</param>
    /// <param name="delay">The time units after which the work item will run.</param>
    /// <remarks>
    /// The <see cref="ExecutionContext"/> is not propagated.
    /// </remarks>
    /// <seealso cref="ISimulationWorkItem"/>
    void UnsafeQueueWorkItemLater(ISimulationWorkItem workItem, int delay);

    /// <summary>
    /// Queues a work item to be run at this time. User code should not call this method.
    /// </summary>
    /// <param name="workItem">The work item to run.</param>
    /// <remarks>
    /// The <see cref="ExecutionContext"/> is not propagated.
    /// </remarks>
    /// <seealso cref="ISimulationWorkItem"/>
    void UnsafeQueueWorkItemNow(ISimulationWorkItem workItem);

    /// <summary>
    /// Adds a <see cref="ISimulationInstrument"/> to display results when the simulation ends.
    /// </summary>
    /// <remarks>
    /// Each instrument is responsible for gathering its data.
    /// A default instrument that measures statistics about the simulation's work item queue
    /// is already registered.
    /// </remarks>
    void RegisterInstrument(ISimulationInstrument instrument);
}
