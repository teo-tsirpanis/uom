using Dai19090.SimulationTechniques.Instruments;

namespace Dai19090.SimulationTechniques.ElevatorSim;

/// <summary>
/// Mesaures statistics about the <see cref="Elevator"/> cabins.
/// </summary>
public sealed class ElevatorInstrument : ISimulationInstrument
{
    private readonly CorrelationId _correlationId;

    private readonly int _floorDelay;

    private UpDownAccumulator _totalPassengersAccumulator;

    private int _simulationDuration;

    /// <summary>
    /// The average number of passengers in the elevator, at times where it had passengers.
    /// </summary>
    public double AverageNonEmptyOccupancy => _totalPassengersAccumulator.AverageNonZero;

    /// <summary>
    /// The average number of passengers in the elevator, at all times.
    /// </summary>
    public double AverageOccupancy => _totalPassengersAccumulator.Average;

    /// <summary>
    /// The total number of times the elevator has left the idle state and started moving.
    /// </summary>
    public int TotalActivations { get; private set; }

    /// <summary>
    /// The total distance traveled by the elevator.
    /// </summary>
    public int TotalFloorsTraveled { get; private set; }

    /// <summary>
    /// The total number of passengers that have been served by the elevator.
    /// </summary>
    public int TotalPassengersServed { get; private set; }

    /// <summary>
    /// The total amount of time units in which the elevator has been moving.
    /// </summary>
    public int TimeInMotion => _floorDelay * TotalFloorsTraveled;

    /// <summary>
    /// The percentage of time in the simulation the elevator has been moving.
    /// </summary>
    public double PercentageInMotion => (double)TimeInMotion / _simulationDuration;

    /// <summary>
    /// The elevator's name.
    /// </summary>
    public string ElevatorName => _correlationId.ToString();

    internal ElevatorInstrument(ElevatorSimOptions options, CorrelationId correlationId)
    {
        _correlationId = correlationId;
        _floorDelay = options.ElevatorMovingDelay;
    }

    internal void OnActivated() => TotalActivations++;

    internal void OnOneFloorTraveled() => TotalFloorsTraveled++;

    internal void OnPassengerEntered() => _totalPassengersAccumulator.Up();

    internal void OnPassengerLeft()
    {
        _totalPassengersAccumulator.Down();
        TotalPassengersServed++;
    }

    void ISimulationInstrument.OnSimulationTimeChanged(Timestamp newTime)
    {
        _totalPassengersAccumulator.AdvanceTime(newTime);
        _simulationDuration = newTime.Value;
    }

    public void WriteResultsTo(TextWriter writer)
    {
        writer.WriteLine($"------------------{ElevatorName} STATISTICS------------------");
        writer.WriteLine($"Total floors traveled: {TotalFloorsTraveled}");
        writer.WriteLine($"Time units in motion: {TimeInMotion}");
        writer.WriteLine($"Percentage in motion: {PercentageInMotion:P2}");
        writer.WriteLine($"Total activations: {TotalActivations}");
        writer.WriteLine($"Total passengers served: {TotalPassengersServed}");
        writer.WriteLine($"Average occupancy (at all times): {AverageOccupancy:G2}");
        writer.WriteLine($"Average occupancy (when the elevator was not empty): {AverageNonEmptyOccupancy:G2}");
        writer.WriteLine();
    }
}
