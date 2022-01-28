using Dai19090.SimulationTechniques.Randomness;

namespace Dai19090.SimulationTechniques.ElevatorSim;

/// <summary>
/// An implementation of <see cref="AbstractElevatorController"/> that
/// tries to call the elevator that will come to the floor the soonest.
/// </summary>
internal sealed class SmartElevatorController : AbstractElevatorController
{
    private readonly IRandomNumberGenerator _random;

    public SmartElevatorController(ISimulationState simulationState, ElevatorSimOptions options) : base(simulationState, options)
    {
        _random = simulationState.Random;
    }

    private void LogMessage(string message) => _simulationState.LogMessage(message, new("elevator_controller"));

    private Elevator? PickAtRandom(IEnumerable<Elevator> elevators)
    {
        var arr = elevators.ToArray();
        switch (arr.Length)
        {
            case 0:
                LogMessage("Could not pick one");
                return null;
            case 1:
                var chosen = arr[0];
                LogMessage($"Picked {chosen}");
                return chosen;
            default:
                chosen = arr[_random.NextInt32UniformClosedOpen(0, arr.Length)];
                LogMessage($"Picked {chosen} randomly out of {arr.Length} candidates");
                return chosen;
        }
    }

    protected override IEnumerable<Elevator> SelectElevatorsToSummon(int currentFloor, ElevatorDirection direction)
    {
        LogMessage("Trying to intelligently pick an elevator");
        var smartPick =
            from elevator in _elevatorCabins
            where
            !elevator.IsActive
            || (!elevator.IsMoving && elevator.CurrentFloor == currentFloor)
            || (direction == elevator.Direction && direction == ElevatorDirection.Up ? elevator.CurrentFloor < currentFloor : elevator.CurrentFloor > currentFloor)
            let distance = Math.Abs(elevator.CurrentFloor - currentFloor)
            orderby distance
            select (elevator, distance);
        if (PickAtRandom(PickTop(smartPick)) is Elevator chosen) { return new Elevator[] { chosen }; }

        LogMessage("Picking one of the nearest elevators instead");
        var nearest =
            from elevator in _elevatorCabins
            let distance = Math.Abs(elevator.CurrentFloor - currentFloor)
            orderby distance
            select (elevator, distance);
        return new Elevator[] { PickAtRandom(PickTop(nearest))! };
    }
}
