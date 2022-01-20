using Dai19090.SimulationTechniques.Instruments;

namespace Dai19090.SimulationTechniques;

/// <summary>
/// An asynchronous waiting queue for simulation work items.
/// </summary>
public sealed class WaitingQueue
{
    /// <summary>
    /// Must be disposed to exit the waiting queue.
    /// </summary>
    public readonly struct QueueTicket : IDisposable
    {
        private readonly WaitingQueue _queue;

        private readonly CorrelationId _id;

        internal QueueTicket(WaitingQueue queue, CorrelationId id)
        {
            _queue = queue;
            _id = id;
        }

        /// <summary>
        /// Signals that the waiting queue can process the next arrival.
        /// </summary>
        public void Dispose() => _queue.Exit(_id);
    }

    private readonly record struct Arrival(CorrelationId Id, Timestamp ArrivalTime, SimulationOpCompletionSource<QueueTicket> CompletionSource);

    private bool _isOccupied;

    private readonly Queue<Arrival> _queue = new();

    private readonly ISimulationState _simulationState;

    /// <summary>
    /// The waiting queue's name. Totally informative.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The waiting queue's associated <see cref="WaitingQueueInstrument"/>.
    /// </summary>
    public WaitingQueueInstrument Instrument { get; }

    /// <summary>
    /// Creates a <see cref="WaitingQueue"/>.
    /// </summary>
    /// <param name="name">The waiting queue's name.</param>
    /// <remarks>
    /// A waiting queue must be created only inside a simulation.
    /// </remarks>
    public WaitingQueue(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        var simulationState = Simulation.GetCurrentState();

        Name = name;
        Instrument = new WaitingQueueInstrument(name);
        _simulationState = simulationState;
        simulationState.RegisterInstrument(Instrument);
    }

    private QueueTicket CreateTicket(CorrelationId id) => new(this, id);

    /// <summary>
    /// Asynchronously waits for the turn to come to enter the queue.
    /// </summary>
    /// <returns>
    /// A simulation operation that must be awaited to οbtain the
    /// <see cref="QueueTicket"> to be used to exit the queue.
    /// </returns>
    public SimulationOp<QueueTicket> EnterAsync(CorrelationId correlationId)
    {
        var currentSimulationTime = _simulationState.CurrentTime;
        _simulationState.LogMessage($"{Name}: entered", correlationId);
        Instrument.ArrivalCame();

        // If the queue is empty, the arrival is immediately fulfilled.
        // The instrument receives both events in quick succession, and
        // we return an already completed operation.
        if (_isOccupied)
        {
            _isOccupied = true;
            Instrument.ArrivalFulfilled(currentSimulationTime, currentSimulationTime);
            _simulationState.LogMessage($"{Name}: found an empty queue and will be served immediately", correlationId);
            return SimulationOp.FromResult(CreateTicket(correlationId));
        }

        var ticket = new SimulationOpCompletionSource<QueueTicket>();
        _queue.Enqueue(new(correlationId, currentSimulationTime, ticket));
        _simulationState.LogMessage($"{Name}: queued along with {_queue.Count - 1} other arrivals in front of it", correlationId);
        return ticket.Op;
    }

    internal void Exit(CorrelationId exitingArrivalId)
    {
        if (!_isOccupied)
            throw new InvalidOperationException("Trying to exit an unoccupied queue.");

        _simulationState.LogMessage($"{Name}: leaving", exitingArrivalId);

        ProcessNextInLine();
    }

    private void ProcessNextInLine()
    {
        if (_queue.TryDequeue(out var arrival))
        {
            _isOccupied = true;
            Instrument.ArrivalFulfilled(arrival.ArrivalTime, _simulationState.CurrentTime);
            _simulationState.LogMessage($"{Name}: served", arrival.Id);
            arrival.CompletionSource.SetResult(CreateTicket(arrival.Id));
        }
        else
        {
            _simulationState.LogMessage($"{Name}: the queue is now empty");
            _isOccupied = false;
        }
    }
}
