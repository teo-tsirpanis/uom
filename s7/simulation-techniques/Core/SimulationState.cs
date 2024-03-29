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

    private readonly HashSet<Exception> _unhandledExceptions = new();

    private readonly LogMessageHandler? _fLog;

    private Timestamp _currentTime;

    public Timestamp CurrentTime
    {
        get
        {
            return _currentTime;
        }
        private set
        {
            if (_currentTime != value)
            {
                _currentTime = value;
                CallOnSimulationTimeChanged(value);
            }
        }
    }

    public IRandomNumberGenerator Random { get; }

    public ISimulationInstrument[] GetInstruments() => _instruments.ToArray();

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
        workItem.Run();
        _workItemQueueInstrument.WorkItemRan();
        return true;
    }

    internal void ThrowUnhandledExceptions()
    {
        if (_unhandledExceptions.Count > 0)
            throw new AggregateException("There were unhandled exceptions in the simulation.", _unhandledExceptions);
    }

    public SimulationState(SimulationOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        Random = options.RandomNumberGenerator;
        _workItems = new();
        _workItemQueueInstrument = new();
        _instruments = new() { _workItemQueueInstrument };
        _fLog = options.GetOnLogMessage();
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
        _instruments.Add(instrument);
    }

    public void LogMessage(string message, CorrelationId correlationId)
    {
        ArgumentNullException.ThrowIfNull(message);
        _fLog?.Invoke(CurrentTime, correlationId, message);
    }

    public void ExceptionThrown(Exception ex)
    {
        _unhandledExceptions.Add(ex);
    }

    public void ExceptionHandled(Exception ex)
    {
        _unhandledExceptions.Remove(ex);
    }
}
