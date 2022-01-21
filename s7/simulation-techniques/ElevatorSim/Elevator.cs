namespace Dai19090.SimulationTechniques.ElevatorSim;

public sealed class Elevator
{
    private record PassengerEntry(IElevatorPassenger Passenger, int DestinationFloor);

    private readonly ElevatorSimOptions _simulationOptions;

    private readonly PassengerEntry?[] _passengers;

    private readonly SimulationOpCompletionSource<bool>?[] _floorsToStop;

    private int _currentFloor;

    private bool _isActive;

    public int CurrentFloor
    {
        get => _currentFloor;
        private set
        {
            _currentFloor = value;
            foreach (var x in _passengers)
                if (x is not null)
                    x.Passenger.CurrentFloor = value;
        }
    }

    internal ElevatorDirection Direction { get; private set; }

    public bool IsDoorOpen { get; private set; }

    public Elevator(ElevatorSimOptions options, int id)
    {
        _simulationOptions = options;
        var capacity = options.ElevatorCapacity;
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Capacity must be a positive number.");
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
            return true;
        }

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
                await Simulation.Delay(_simulationOptions.ElevatorDoorOpeningDelay);
                IsDoorOpen = true;
                ReleasePassengersWhoArrived();
                arrivedCs.SetResult(true);
                await Simulation.Delay(_simulationOptions.ElevatorDoorOpeningDelay);
                IsDoorOpen = false;

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

    public SimulationOp Summon(int floor) => GoToFloor(floor);

    public SimulationOp<bool> TryEnter(IElevatorPassenger passenger, int destinationFloor)
    {
        if (passenger.CurrentFloor != CurrentFloor || !IsDoorOpen)
            return SimulationOp.FromResult(false);

        if (CurrentFloor == destinationFloor)
            return SimulationOp.FromResult(true);

        var freeSpotIndex = Array.IndexOf(_passengers, null);
        if (freeSpotIndex < 0)
            return SimulationOp.FromResult(false);

        _passengers[freeSpotIndex] = new(passenger, destinationFloor);
        return GoToFloor(destinationFloor);
    }
}
