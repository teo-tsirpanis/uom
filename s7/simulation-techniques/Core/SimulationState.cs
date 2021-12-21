using Dai19090.SimulationTechniques.Infrastructure;
using Dai19090.SimulationTechniques.Instruments;
using Dai19090.SimulationTechniques.Randomness;

namespace Dai19090.SimulationTechniques;

/// <summary>
/// The default implementation of <see cref="ISimulationState"/>.
/// </summary>
internal sealed class SimulationState : ISimulationState
{
    private readonly PriorityQueue<ISimulationWorkItem, Timestamp> _workItems;

    private readonly WorkItemQueueInstrument _workItemQueueInstrument;

    private readonly List<ISimulationInstrument> _instruments;

    public Timestamp CurrentTime { get; private set; }

    public IRandomNumberGenerator Random { get; }

    public IEnumerable<ISimulationInstrument> Instruments => _instruments;

    internal bool RunNextWorkItem()
    {
        if (!_workItems.TryDequeue(out var workItem, out var timestamp))
            return false;

        if (timestamp != CurrentTime)
            _workItemQueueInstrument.SimulationTimeChanged(timestamp);
        CurrentTime = timestamp;
        workItem.Run();
        _workItemQueueInstrument.WorkItemRan();
        return true;
    }

    public SimulationState(IRandomNumberGenerator random)
    {
        if (random is null)
            ThrowHelpers.ThrowArgumentNull(nameof(random));
        Random = random;
        _workItems = new();
        _workItemQueueInstrument = new();
        _instruments = new() { _workItemQueueInstrument };
    }

    public void UnsafeQueueWorkItemLater(ISimulationWorkItem workItem, int delay)
    {
        if (workItem is null)
            ThrowHelpers.ThrowArgumentNull(nameof(workItem));
        if (delay < 0)
            ThrowHelpers.ThrowNegativeNumber(nameof(delay), delay);
        _workItems.Enqueue(workItem, CurrentTime + delay);
    }

    public void UnsafeQueueWorkItemNow(ISimulationWorkItem workItem)
    {
        if (workItem is null)
            ThrowHelpers.ThrowArgumentNull(nameof(workItem));
        _workItems.Enqueue(workItem, CurrentTime);
    }

    public void RegisterInstrument(ISimulationInstrument instrument)
    {
        if (instrument is null)
            ThrowHelpers.ThrowArgumentNull(nameof(instrument));
        _instruments.Add(instrument);
    }
}
