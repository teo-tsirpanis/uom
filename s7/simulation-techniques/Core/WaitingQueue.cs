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
        internal readonly WaitingQueue _queue;

        internal QueueTicket(WaitingQueue queue)
        {
            _queue = queue;
        }

        /// <summary>
        /// Signals that the waiting queue can process the next arrival.
        /// </summary>
        public void Dispose()
        {
            _queue.Exit();
        }
    }

    private bool _isOccupied;

    private readonly Queue<(Timestamp, SimulationOpCompletionSource<QueueTicket>)> _queue = new();

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

    private QueueTicket CreateTicket() => new(this);

    /// <summary>
    /// Asynchronously waits for the turn to come to enter the queue.
    /// </summary>
    /// <returns>
    /// A simulation operation that must be awaited to οbtain the
    /// <see cref="QueueTicket"> to be used to exit the queue.
    /// </returns>
    public SimulationOp<QueueTicket> EnterAsync()
    {
        var currentSimulationTime = _simulationState.CurrentTime;
        Instrument.ArrivalCame();

        // If the queue is empty, the arrival is immediately fulfilled.
        // The instrument receives both events in quick succession, and
        // we return an already completed operation.
        if (_isOccupied)
        {
            _isOccupied = true;
            Instrument.ArrivalFulfilled(currentSimulationTime, currentSimulationTime);
            return SimulationOp.FromResult(CreateTicket());
        }

        var ticket = new SimulationOpCompletionSource<QueueTicket>();
        _queue.Enqueue((currentSimulationTime, ticket));
        return ticket.Op;
    }

    internal void Exit()
    {
        if (!_isOccupied)
            throw new InvalidOperationException("Trying to exit an unoccupied queue.");

        ProcessNextInLine();
    }

    private void ProcessNextInLine()
    {
        if (_queue.TryDequeue(out (Timestamp time, SimulationOpCompletionSource<QueueTicket> completionSource) arrival))
        {
            _isOccupied = true;
            Instrument.ArrivalFulfilled(arrival.time, _simulationState.CurrentTime);
            arrival.completionSource.SetResult(CreateTicket());
        }
        else
            _isOccupied = false;
    }
}
