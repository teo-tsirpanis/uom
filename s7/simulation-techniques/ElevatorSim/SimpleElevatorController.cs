namespace Dai19090.SimulationTechniques.ElevatorSim;

/// <summary>
/// An implementation of <see cref="AbstractElevatorController"/> that
/// calls the nearest elevators; and all of them if there is a tie.
/// </summary>
internal sealed class SimpleElevatorController : AbstractElevatorController
{
    public SimpleElevatorController(ISimulationState simulationState, ElevatorSimOptions options) : base(simulationState, options) { }

    protected override IEnumerable<Elevator> SelectElevatorsToSummon(int currentFloor, ElevatorDirection direction)
    {
        var elevatorsSorted =
            from elevator in _elevatorCabins
            orderby Math.Abs(elevator.CurrentFloor - currentFloor)
            select elevator;

        var lastDistance = -1;

        foreach (var elevator in elevatorsSorted)
        {
            var distance = Math.Abs(elevator.CurrentFloor - currentFloor);
            if (lastDistance >= 0 && distance > lastDistance)
                yield break;
            lastDistance = distance;
            yield return elevator;
        }
    }
}
