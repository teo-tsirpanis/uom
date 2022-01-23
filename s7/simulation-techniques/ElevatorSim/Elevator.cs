namespace Dai19090.SimulationTechniques.ElevatorSim;

/// <summary>
/// A simulated elevator cabin.
/// </summary>
public sealed class Elevator
{
    private record PassengerEntry(IElevatorPassenger Passenger, int DestinationFloor);

    private readonly CorrelationId _id;

    private readonly PassengerEntry?[] _passengers;

    private readonly ISimulationState _simulationState;

    private readonly ElevatorSimOptions _simulationOptions;

    private readonly SimulationOpCompletionSource<bool>?[] _floorsToStop;

    private int _currentFloor;

    private bool _isActive;

    public int CurrentFloor
    {
        get => _currentFloor;
        private set
        {
            if (value == _currentFloor) return;
            if (Math.Abs(value - CurrentFloor) > 1)
                throw new InvalidOperationException($"Cannot directly jump from floor {CurrentFloor} to {value}.");

            _simulationState.LogMessage($"At floor {value}", _id);
            _currentFloor = value;
            foreach (var x in _passengers)
                if (x is not null)
                    x.Passenger.CurrentFloor = value;
        }
    }

    internal ElevatorDirection Direction { get; private set; }

    public bool IsDoorOpen { get; private set; }

    public Elevator(ISimulationState simulationState, ElevatorSimOptions options, int id)
    {
        var capacity = options.ElevatorCapacity;
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Capacity must be a positive number.");

        _simulationState = simulationState;
        _simulationOptions = options;
        _id = new($"elevator_{id}");
        _passengers = new PassengerEntry?[capacity];
        _floorsToStop = new SimulationOpCompletionSource<bool>?[options.NumberOfFloors];
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
                changed = true;
                x = null;
            }

        if (changed)
            span.MoveNullsToTheEnd();
    }

    private async SimulationOp MovingLoop()
    {
        while (ShouldContinue())
        {
            await Simulation.Delay(_simulationOptions.ElevatorMovingDelay);
            CurrentFloor += (int)Direction;

            var arrivedCs = _floorsToStop[CurrentFloor];

            if (arrivedCs is not null)
            {
                _simulationState.LogMessage($"Stopped at floor {CurrentFloor}, opening doors", _id);
                await Simulation.Delay(_simulationOptions.ElevatorDoorOpeningDelay);
                _simulationState.LogMessage($"Opened doors", _id);
                IsDoorOpen = true;
                ReleasePassengersWhoArrived();
                arrivedCs.SetResult(true);
                _simulationState.LogMessage($"Closing doors", _id);
                IsDoorOpen = false;
                await Simulation.Delay(_simulationOptions.ElevatorDoorOpeningDelay);
                _simulationState.LogMessage($"Closed doors", _id);

                _floorsToStop[CurrentFloor] = null;
            }
        }

        _isActive = false;
    }

    private void Activate(ElevatorDirection direction)
    {
        if (_isActive)
            return;
        _isActive = true;
        Direction = direction;
        _ = MovingLoop();
    }

    private SimulationOp<bool> GoToFloor(int floor)
    {
        if (floor == CurrentFloor) return SimulationOp.FromResult(true);
        var completionSource = _floorsToStop[floor] ??= new();
        Activate(DirectionExtensions.Create(CurrentFloor, floor));
        return completionSource.Op;
    }

    public SimulationOp Summon(int floor)
    {
        _simulationState.LogMessage($"Summoned to floor {floor}", _id);
        return GoToFloor(floor);
    }

    public SimulationOp<bool> TryEnter(IElevatorPassenger passenger, int destinationFloor)
    {
        if (passenger.CurrentFloor != CurrentFloor || !IsDoorOpen)
            return SimulationOp.FromResult(false);

        if (CurrentFloor == destinationFloor)
            return SimulationOp.FromResult(true);

        var freeSpotIndex = Array.IndexOf(_passengers, null);
        if (freeSpotIndex < 0)
        {
            _simulationState.LogMessage($"Cannot enter {_id}, it is full", passenger.CorrelationId);
            return SimulationOp.FromResult(false);
        }

        _passengers[freeSpotIndex] = new(passenger, destinationFloor);
        _simulationState.LogMessage($"Entered {_id}, going to floor {destinationFloor}", passenger.CorrelationId);
        return GoToFloor(destinationFloor);
    }
}
