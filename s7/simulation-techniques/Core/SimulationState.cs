using Dai19090.SimulationTechniques.Randomness;

namespace Dai19090.SimulationTechniques;

/// <summary>
/// The default implementation of <see cref="ISimulationState"/>.
/// </summary>
internal sealed class SimulationState : ISimulationState
{
    public Timestamp CurrentTime { get; private set; }

    public IRandomNumberGenerator Random { get; }

    private readonly PriorityQueue<ISimulationWorkItem, Timestamp> _workItems = new();

    internal bool RunNextWorkItem()
    {
        if (!_workItems.TryDequeue(out var workItem, out var timestamp))
            return false;

        CurrentTime = timestamp;
        workItem.Run();
        return true;
    }

    public SimulationState(IRandomNumberGenerator random)
    {
        Random = random;
    }

    public void QueueWorkItemLater(ISimulationWorkItem workItem, int delay)
    {
        if (delay < 0)
            ThrowHelpers.ThrowNegativeNumber(nameof(delay), delay);
        _workItems.Enqueue(workItem, CurrentTime + delay);
    }

    public void QueueWorkItemNow(ISimulationWorkItem workItem)
    {
        _workItems.Enqueue(workItem, CurrentTime);
    }
}
