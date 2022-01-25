using Dai19090.SimulationTechniques.Infrastructure;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Dai19090.SimulationTechniques.ElevatorSim;

/// <summary>
/// A simulated elevator cabin.
/// </summary>
[DebuggerDisplay("{DebugInfo,nq}")]
public sealed class Elevator
{
    private record PassengerEntry(IElevatorPassenger Passenger, int DestinationFloor);

    private struct DoorEventAwaitable : ISimulationCompletion
    {
        private readonly List<ISimulationWorkItem>? _workItems;

        public DoorEventAwaitable(List<ISimulationWorkItem> workItems) => _workItems = workItems;

        public DoorEventAwaitable GetAwaiter() => this;

        public bool IsCompleted => _workItems is null;

        public void GetResult() { }

        public void UnsafeOnCompleted(ISimulationState simulationState, ISimulationWorkItem workItem)
        {
            if (_workItems is List<ISimulationWorkItem> workItems)
                workItems.Add(workItem);
            else
                simulationState.UnsafeQueueWorkItemNow(workItem);
        }
    }

    private enum DoorState { Closed, Closing, Opening, Open }

    private enum ActivationState { Inactive, Activating, Active }

    private readonly CorrelationId _id;

    private readonly ElevatorInstrument _instrument;

    private readonly PassengerEntry?[] _passengers;

    private readonly ISimulationState _simulationState;

    private readonly ElevatorSimOptions _simulationOptions;

    private readonly SimulationOpCompletionSource?[] _floorsToStop;

    private readonly List<ISimulationWorkItem> _doorOpenedEvents = new(), _doorClosedEvents = new();

    private ActivationState _activationState = ActivationState.Inactive;

    private int _currentFloor;

    private DoorState _doorState = DoorState.Closed;

    private bool _isMoving;

    public int CurrentFloor
    {
        get => _currentFloor;
        private set
        {
            if (value == _currentFloor) return;
            if (Math.Abs(value - CurrentFloor) > 1)
                throw new InvalidOperationException($"Cannot directly jump from floor {CurrentFloor} to {value}.");

            _simulationState.LogMessage($"At floor {value}", _id);
            _instrument.OnOneFloorTraveled();
            _currentFloor = value;
            foreach (var x in _passengers)
                if (x is not null)
                    x.Passenger.CurrentFloor = value;
        }
    }

    public ElevatorDirection Direction { get; private set; }

    public bool IsDoorOpen => _doorState == DoorState.Open;

    public bool IsDoorClosed => _doorState == DoorState.Closed;

    private string DebugInfo
    {
        get
        {
            var calledFloors = _floorsToStop.Select((x, idx) => (x, idx)).Where(x => x.x is not null).Select(x => x.idx);
            return $"{_activationState} at floor {CurrentFloor}, Moving: {_isMoving}, Direction: {Direction}, Doors are {_doorState}, " +
                $"{_passengers.Count(x => x is not null)} passengers inside, " +
                $"Called by floors [{string.Join(',', calledFloors)}]";
        }
    }

    public Elevator(ISimulationState simulationState, ElevatorSimOptions options, int id)
    {
        var capacity = options.ElevatorCapacity;
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Capacity must be a positive number.");

        _simulationState = simulationState;
        _simulationOptions = options;
        _id = new($"elevator_{id}");
        _instrument = new(options, _id);
        simulationState.RegisterInstrument(_instrument);
        _passengers = new PassengerEntry?[capacity];
        _floorsToStop = new SimulationOpCompletionSource?[options.NumberOfFloors + 1];
    }

    private bool ShouldContinue()
    {
        var nextRequestedFloor = FindRequestedFloorTowards(Direction);
        if (nextRequestedFloor != -1)
            return true;

        var nextRequestedFloorOppositeDirection = FindRequestedFloorTowards(Direction.Opposite());
        if (nextRequestedFloorOppositeDirection != -1)
        {
            Direction = Direction.Opposite();
            _simulationState.LogMessage($"Changing direction to {Direction}", _id);
            return true;
        }

        _simulationState.LogMessage($"Resting at floor {CurrentFloor}", _id);
        return false;

        int FindRequestedFloorTowards(ElevatorDirection direction)
        {
            for (int i = CurrentFloor; i >= 0 && i < _floorsToStop.Length; i += (int)direction)
                if (_floorsToStop[i] is not null)
                    return i;
            return -1;
        }
    }

    private void ReleasePassengersWhoArrived()
    {
        var changed = false;
        var span = _passengers.AsSpan();

        foreach (ref var x in span)
            if (x is not null && x.DestinationFloor == CurrentFloor)
            {
                _simulationState.LogMessage($"Left {_id}, arrived at floor {CurrentFloor}", x.Passenger.CorrelationId);
                _instrument.OnPassengerLeft();
                changed = true;
                x = null;
            }

        if (changed)
            span.MoveNullsToTheEnd();
    }

    private async SimulationOp OpenDoorAsync()
    {
        if (!IsDoorClosed)
        {
            if (_doorState == DoorState.Closing)
                _doorState = DoorState.Opening;
            await WaitForDoorToOpenAsync();
            return;
        }

        _simulationState.LogMessage("Opening doors", _id);
        _doorState = DoorState.Opening;
        await Simulation.Delay(_simulationOptions.ElevatorDoorOpeningDelay);
        _simulationState.LogMessage("Opened doors", _id);
        _doorState = DoorState.Open;
        TriggerDoorEvents();

        _ = WaitAndCloseDoorsAsync();
    }

    private async SimulationOp WaitAndCloseDoorsAsync()
    {
        while (!IsDoorClosed)
        {
            await Simulation.Delay(_simulationOptions.ElevatorDoorOpeningDuration);
            _simulationState.LogMessage("Closing doors", _id);
            _doorState = DoorState.Closing;
            await Simulation.Delay(_simulationOptions.ElevatorDoorOpeningDelay);
            if (_doorState == DoorState.Closing)
            {
                _simulationState.LogMessage("Closed doors", _id);
                _doorState = DoorState.Closed;
            }
            else
            {
                Debug.Assert(_doorState == DoorState.Opening);
                _simulationState.LogMessage($"Reopening doors", _id);
                _doorState = DoorState.Open;
            }
            TriggerDoorEvents();
        }
    }

    private void TriggerDoorEvents()
    {
        List<ISimulationWorkItem> workItems;
        switch (_doorState)
        {
            case DoorState.Open:
                workItems = _doorOpenedEvents;
                break;
            case DoorState.Closed:
                workItems = _doorClosedEvents;
                break;
            default:
                return;
        }
        foreach (var workItem in workItems)
            _simulationState.UnsafeQueueWorkItemNow(workItem);
        workItems.Clear();
    }

    private DoorEventAwaitable WaitForDoorToOpenAsync() =>
        _doorState == DoorState.Open ? default : new(_doorOpenedEvents);

    private DoorEventAwaitable WaitForDoorToCloseAsync() =>
        _doorState == DoorState.Closed ? default : new(_doorClosedEvents);

    private async SimulationOp MovingLoop()
    {
        await WaitForDoorToCloseAsync();
        _activationState = ActivationState.Active;
        _simulationState.LogMessage($"Sprung into motion, heading {Direction}", _id);

        while (ShouldContinue())
        {
            _isMoving = true;
            await Simulation.Delay(_simulationOptions.ElevatorMovingDelay);
            CurrentFloor += (int)Direction;

            var arrivedCs = _floorsToStop[CurrentFloor];

            if (arrivedCs is not null)
            {
                _isMoving = false;
                _simulationState.LogMessage($"Stopped at floor {CurrentFloor}", _id);
                await OpenDoorAsync();
                ReleasePassengersWhoArrived();
                arrivedCs.SetResult();

                _floorsToStop[CurrentFloor] = null;

                await WaitForDoorToCloseAsync();
            }
        }

        _isMoving = false;
        _activationState = ActivationState.Inactive;
    }

    private void Activate(ElevatorDirection direction)
    {
        if (_activationState != ActivationState.Inactive)
            return;
        _activationState = ActivationState.Activating;
        Direction = direction;
        _instrument.OnActivated();
        _ = MovingLoop();
    }

    private SimulationOp GoToFloor(int floor)
    {
        if (floor == CurrentFloor) return SimulationOp.CompletedOp;
        var completionSource = _floorsToStop[floor] ??= new();
        Activate(DirectionExtensions.Create(CurrentFloor, floor));
        return completionSource.Op;
    }

    internal async SimulationOp Summon(int floor)
    {
        _simulationState.LogMessage($"Summoned to floor {floor}", _id);
        if (floor == CurrentFloor && !_isMoving)
        {
            await OpenDoorAsync();
            return;
        }
        await GoToFloor(floor);
    }

    private bool TryEmbarkPassenger(IElevatorPassenger passenger, int destinationFloor)
    {
        if (!IsDoorOpen)
            throw new InvalidOperationException("A passenger cannot embark if the elevator's door is not open.");

        var freeSpotIndex = Array.IndexOf(_passengers, null);
        if (freeSpotIndex < 0)
        {
            _simulationState.LogMessage($"Cannot enter {_id}, it is full", passenger.CorrelationId);
            return false;
        }

        _passengers[freeSpotIndex] = new(passenger, destinationFloor);
        _simulationState.LogMessage($"Entered {_id}, going to floor {destinationFloor}", passenger.CorrelationId);
        _instrument.OnPassengerEntered();

        return true;
    }

    [DoesNotReturn]
    private void ThrowInvalidOperationException(CorrelationId id, string message) =>
        throw new InvalidOperationException($"{Utilities.FormatLogItem(_simulationState.CurrentTime, id)} {message}");

    internal async SimulationOp<SimulationOp?> TryEnterAsync(IElevatorPassenger passenger, int destinationFloor)
    {
        if (destinationFloor < 0 || destinationFloor >= _floorsToStop.Length)
            throw new ArgumentOutOfRangeException(nameof(destinationFloor), $"The building has only {_floorsToStop.Length} floors");

        if (passenger.CurrentFloor != CurrentFloor)
        {
            ThrowInvalidOperationException(passenger.CorrelationId, $"Cannot enter {_id}, it is not in the correct floor.");
            return null;
        }

        await WaitForDoorToOpenAsync();

        if (CurrentFloor == destinationFloor)
            return SimulationOp.CompletedOp;

        if (!TryEmbarkPassenger(passenger, destinationFloor))
            return null;

        return GoToFloor(destinationFloor);
    }
}
