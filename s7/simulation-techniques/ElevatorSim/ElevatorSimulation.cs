using Dai19090.SimulationTechniques.Randomness;

namespace Dai19090.SimulationTechniques.ElevatorSim;

/// <summary>
/// Simulates people coming to a building with elevators.
/// </summary>
public sealed class ElevatorSimulation
{
    private sealed record Person(int Id, (int Floor, int DurationOfStay)[] Plan) : IElevatorPassenger
    {
        public int CurrentFloor { get; set; }

        internal Timestamp LastFloorArrivalTime;

        internal int LastDurationOfStay;

        public CorrelationId CorrelationId { get; } = new($"citizen_{Id}");

        public int TotalProductiveTime => Plan.Sum(static x => x.DurationOfStay);
    }

    private sealed class Floor
    {
        public readonly FloorInstrument? Instrument;

        public readonly WaitingQueue WaitingQueue;

        public Floor(int floorNumber, ISimulationState simulationState)
        {
            // No reason to keep statistics about the ground floor.
            if (floorNumber != 0)
            {
                var instrument = new FloorInstrument(floorNumber);
                Instrument = instrument;
                simulationState.RegisterInstrument(instrument);
            }
            WaitingQueue = new($"floor_{floorNumber}");
        }
    }

    private readonly AbstractElevatorController _elevatorController;

    private readonly Floor[] _floors;

    private readonly PeopleInstrument _peopleInstrument = new();

    private readonly IRandomNumberGenerator _random;

    private readonly ElevatorSimOptions _simulationOptions;

    private readonly ISimulationState _simulationState;

    private ElevatorSimulation(ISimulationState simulationState, ElevatorSimOptions simulationOptions)
    {
        ArgumentNullException.ThrowIfNull(simulationState);
        simulationOptions.Validate();
        _elevatorController = CreateElevatorController(simulationOptions.ElevatorStrategy);
        _floors = CreateFloors();
        _random = simulationState.Random;
        _simulationOptions = simulationOptions;
        _simulationState = simulationState;
        simulationState.RegisterInstrument(_peopleInstrument);

        _ = SimulationMain();

        Floor[] CreateFloors()
        {
            var waitingQueues = new Floor[simulationOptions.NumberOfFloors + 1];
            for (int i = 0; i < waitingQueues.Length; i++)
                waitingQueues[i] = new(i, simulationState);
            return waitingQueues;
        }

        AbstractElevatorController CreateElevatorController(ElevatorStrategy strategy) =>
            strategy switch
            {
                ElevatorStrategy.Simple => new SimpleElevatorController(simulationState, simulationOptions),
                ElevatorStrategy.Smart => new SmartElevatorController(simulationState, simulationOptions),
                _ => throw new ArgumentOutOfRangeException(nameof(strategy))
            };
    }

    public static SimulationResult Run(ElevatorSimOptions options, SimulationOptions simulationOptions)
    {
        ElevatorSimulation? currentSimulation;
        return Simulation.Run((state, _) => currentSimulation = new ElevatorSimulation(state, options), simulationOptions);
    }

    private static int RoundToInt(float x) =>
        (int)MathF.Round(x);

    private int GetRandomFloor(int existingFloor)
    {
        // Let's say that we are on the first out of five floors.
        // totalFloors will be 5. The zeroth floor is only used
        // to enter and exit the building.
        var totalFloors = _simulationOptions.NumberOfFloors;
        // floor will have one of 1, 2, 3, 4. One less possible value
        // than the number of floors.
        var floor = _random.NextInt32UniformClosedOpen(1, totalFloors);
        // Then, if we roll the same floor again (we don't want to), we
        // will return the top floor, ensuring equidistribution of results.
        return floor == existingFloor ? totalFloors : floor;
    }

    private (int Floor, int DurationOfStay)[] GenerateRandomPlan()
    {
        // If our building only has one floor, we only can go on there once.
        if (_simulationOptions.NumberOfFloors == 1)
            return new (int Floor, int DurationOfStay)[] { (1, RoundToInt(_random.NextSingleNormal(_simulationOptions.DurationOfStayOnFloor))) };

        var numberOfFloors = RoundToInt(_random.NextSingleNormal(_simulationOptions.NumberOfFloorsVisited));
        numberOfFloors = Math.Max(numberOfFloors, 1);
        var plan = new (int, int)[numberOfFloors];
        int lastFloor = 0;
        for (int i = 0; i < plan.Length; i++)
        {
            lastFloor = GetRandomFloor(lastFloor);
            plan[i] = (lastFloor, Math.Abs(RoundToInt(_random.NextSingleNormal(_simulationOptions.DurationOfStayOnFloor))));
        }

        return plan;
    }

    private Person GenerateRandomPerson(int id)
    {
        return new(id, GenerateRandomPlan());
    }

    private void ArrivedAtFloor(Person person) =>
        _floors[person.CurrentFloor].Instrument?.ArrivedAtFloor();

    private void LeftFloor(Person person) =>
        _floors[person.CurrentFloor].Instrument?.LeftTheFloor(person.LastFloorArrivalTime, _simulationState.CurrentTime, person.LastDurationOfStay);

    private async SimulationOp GoToFloorAsync(Person person, int floor)
    {
        SimulationOp leftElevatorOp;
        var currentFloor = person.CurrentFloor;
        // We enter the respective floor's waiting queue.
        using (await _floors[currentFloor].WaitingQueue.EnterAsync(person.CorrelationId))
        {
            // When our turn comes, we call the elevator(s) and enter them when one of them comes.
            leftElevatorOp = await _elevatorController.CallElevatorAndGoToFloorAsync(person, floor);

        }
        LeftFloor(person);
        // Having entered an elevator, we leave the queue and wait until we arrive at our floor.
        await leftElevatorOp;
        ArrivedAtFloor(person);
        person.LastFloorArrivalTime = _simulationState.CurrentTime;
    }

    private async SimulationOp PersonMain(Person person)
    {
        LogMessage($"Entered the building, will visit {person.Plan.Length} floors in total");
        var arrivalTime = _simulationState.CurrentTime;

        foreach (var (floor, durationOfStay) in person.Plan)
        {
            LogMessage($"Time to go to floor {floor} and stay there for {TimeSpan.FromSeconds(durationOfStay)}");
            await GoToFloorAsync(person, floor);
            if (person.CurrentFloor != floor)
                throw new Exception($"{Utilities.FormatLogItem(_simulationState.CurrentTime, person.CorrelationId)} did not arrive at floor {floor} but is at floor {person.CurrentFloor}");
            await Simulation.Delay(durationOfStay);
            person.LastDurationOfStay = durationOfStay;
        }

        LogMessage($"Time to go to the ground floor and leave");
        await GoToFloorAsync(person, 0);
        LogMessage($"Left the building");
        var departureTime = _simulationState.CurrentTime;
        _peopleInstrument.ArrivalFulfilled(arrivalTime, departureTime, person.TotalProductiveTime);

        void LogMessage(string message) => _simulationState.LogMessage(message, person.CorrelationId);
    }

    private async SimulationOp SimulationMain()
    {
        // We generate the people beforehand to ensure identical results
        // accross elevator controller implementations that might use randomness.
        var allArrivals = new (Person Person, int TimeUntilNext)[_simulationOptions.TotalArrivals];
        var scale = 1.0f / _simulationOptions.MeanTimeBetweenArrivals;
        for (int i = 1; i <= allArrivals.Length; i++)
        {
            allArrivals[i - 1] = (GenerateRandomPerson(i), RoundToInt(_random.NextSingleExponential(scale)));
        }

        foreach (var arrival in allArrivals)
        {
            _ = PersonMain(arrival.Person);
            await Simulation.Delay(arrival.TimeUntilNext);
        }
    }
}
