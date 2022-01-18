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

    public ISimulationInstrument [] GetInstruments() => _instruments.ToArray();

    private void CallOnSimulationTimeChanged(Timestamp newTime)
    {
        foreach (var instrument in _instruments)
            instrument.OnSimulationTimeChanged(newTime);
    }

    internal bool RunNextWorkItem()
    {
        if (!_workItems.TryDequeue(out var workItem, out var timestamp))
            return false;

        CurrentTime = timestamp;
        if (timestamp != CurrentTime)
            CallOnSimulationTimeChanged(timestamp);
        workItem.Run();
        _workItemQueueInstrument.WorkItemRan();
        return true;
    }

    public SimulationState(IRandomNumberGenerator random)
    {
        ArgumentNullException.ThrowIfNull(random);
        Random = random;
        _workItems = new();
        _workItemQueueInstrument = new();
        _instruments = new() { _workItemQueueInstrument };
    }

    public void UnsafeQueueWorkItemLater(ISimulationWorkItem workItem, int delay)
    {
        ArgumentNullException.ThrowIfNull(workItem);
        if (delay < 0)
            ThrowHelpers.ThrowNegativeNumber(nameof(delay), delay);
        _workItems.Enqueue(workItem, CurrentTime + delay);
    }

    public void UnsafeQueueWorkItemNow(ISimulationWorkItem workItem)
    {
        ArgumentNullException.ThrowIfNull(workItem);
        _workItems.Enqueue(workItem, CurrentTime);
    }

    public void RegisterInstrument(ISimulationInstrument instrument)
    {
        ArgumentNullException.ThrowIfNull(instrument);
        if (instrument is WorkItemQueueInstrument)
            throw new InvalidOperationException($"Cannot register a {nameof(WorkItemQueueInstrument)} again; it is already registered.");
        _instruments.Add(instrument);
    }
}
