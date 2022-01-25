using System.Diagnostics;

namespace Dai19090.SimulationTechniques.ElevatorSim;

public abstract class AbstractElevatorController
{
    protected readonly Elevator[] _elevatorCabins;

    protected readonly ElevatorSimOptions _simulationOptions;

    protected readonly ISimulationState _simulationState;

    public AbstractElevatorController(ISimulationState simulationState, ElevatorSimOptions options)
    {
        _elevatorCabins = new Elevator[options.NumberOfElevators];
        _simulationOptions = options;
        _simulationState = simulationState;
        for (int i = 0; i < _elevatorCabins.Length; i++)
            _elevatorCabins[i] = new Elevator(simulationState, options, i);
    }

    protected abstract IEnumerable<Elevator> SelectElevatorsToSummon(int currentFloor, ElevatorDirection direction);

    private async SimulationOp<SimulationOp> CallOnlyElevatorAndGotoFloorAsync(IElevatorPassenger passenger, int destinationFloor)
    {
        var elevator = _elevatorCabins[0];

        while (true)
        {
            await elevator.Summon(destinationFloor);

            if (await elevator.TryEnterAsync(passenger, destinationFloor) is SimulationOp op)
                return op;

            _simulationState.LogMessage($"The elevator was full, trying to summon it again", passenger.CorrelationId);
        }
    }

    public async SimulationOp<SimulationOp> CallElevatorAndGoToFloorAsync(IElevatorPassenger passenger, int destinationFloor)
    {
        // If we have only one elevator, we can take a simpler path.
        if (_elevatorCabins.Length == 1)
            return await CallOnlyElevatorAndGotoFloorAsync(passenger, destinationFloor);

        var currentFloor = passenger.CurrentFloor;
        var direction = DirectionExtensions.Create(currentFloor, destinationFloor);

        // We repeat until we find an elevator that goes us to the floor we want.
        while (true)
        {
            // We ask the controller which elevators to summon, and summon them all.
            SimulationOp<Elevator>?[] elevators =
                SelectElevatorsToSummon(currentFloor, direction)
                .Select(x => SummonImpl(currentFloor, x))
                .ToArray();
            SimulationOp<Elevator>? chosenElevatorOp;

            // We wait until one of the elevators we asked for comes.
            while ((chosenElevatorOp = await SimulationOp.WhenAny(elevators)) != null)
            {
                var chosenElevator = await chosenElevatorOp;

                // If we can enter it, we return a simulation op that
                // will complete when we arrive to our destination.
                if (await chosenElevator.TryEnterAsync(passenger, destinationFloor) is SimulationOp op)
                    return op;

                // If we cannot because it is full, we cross it off and wait for one of the rest.
                var elevatorIdx = Array.IndexOf(elevators, chosenElevatorOp);
                Debug.Assert(elevatorIdx >= 0);
                elevators[elevatorIdx] = null;
            }
            // If all the elevators are full, we try to ask from the controller again.
            _simulationState.LogMessage($"All elevators were full, trying to summon them again", passenger.CorrelationId);
            // But first we wait for a bit until the elevators have left the floor.
            await Simulation.Delay(_simulationOptions.ElevatorDoorOpeningDuration);
        }

        static async SimulationOp<Elevator> SummonImpl(int floor, Elevator elevator)
        {
            await elevator.Summon(floor);
            return elevator;
        }
    }
}
