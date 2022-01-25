using Dai19090.SimulationTechniques.Instruments;
using System.Diagnostics;

namespace Dai19090.SimulationTechniques.ElevatorSim;

public sealed class FloorInstrument : ISimulationInstrument
{
    private UpDownAccumulator _peopleOnFloorAccumulator;

    private IntegerAccumulator _timeOnFloorAccumulator, _waitingTimeAccumulator;

    private RealAccumulator _waitingTimePercentageAccumulator;

    public int FloorNumber { get; }

    public int TotalArrivalsOnFloor { get; private set; }

    public double AveragePeopleOnFloor => _peopleOnFloorAccumulator.Average;

    public double AveragePeopleOnFloorNonZero => _peopleOnFloorAccumulator.AverageNonZero;

    public int MaxPeopleOnFloor => _peopleOnFloorAccumulator.Max;

    public TimeSpan AverageTimeSpentOnFloor => _timeOnFloorAccumulator.Average.ToSeconds();

    public TimeSpan MaxTimeSpentOnFloor => TimeSpan.FromSeconds(_timeOnFloorAccumulator.Max);

    public TimeSpan MinTimeSpentOnFloor => TimeSpan.FromSeconds(_timeOnFloorAccumulator.Min);

    public TimeSpan AverageWaitingTime => _waitingTimeAccumulator.Average.ToSeconds();

    public TimeSpan MaxWaitingTime => TimeSpan.FromSeconds(_waitingTimeAccumulator.Max);

    public TimeSpan MinWaitingTime => TimeSpan.FromSeconds(_waitingTimeAccumulator.Min);

    public double AverageWaitingTimePercentage => _waitingTimePercentageAccumulator.Average;

    public double MaxWaitingTimePercentage => _waitingTimePercentageAccumulator.Max;

    public double MinWaitingTimePercentage => _waitingTimePercentageAccumulator.Min;

    internal FloorInstrument(int floorNumber) => FloorNumber = floorNumber;

    internal void ArrivedAtFloor()
    {
        TotalArrivalsOnFloor++;
        _peopleOnFloorAccumulator.Up();
    }

    internal void LeftTheFloor(Timestamp arrivalTime, Timestamp departureTime, int productiveTime)
    {
        var timeSpent = departureTime - arrivalTime;
        var waitingTime = timeSpent - productiveTime;
        var waitingTimePercentage = (double)waitingTime / timeSpent;
        Debug.Assert(waitingTime >= 0);
        _timeOnFloorAccumulator.Submit(timeSpent);
        _waitingTimeAccumulator.Submit(waitingTime);
        _waitingTimePercentageAccumulator.Submit(waitingTimePercentage);
    }

    void ISimulationInstrument.OnSimulationTimeChanged(Timestamp newTime)
    {
        _peopleOnFloorAccumulator.AdvanceTime(newTime);
    }

    public void WriteResultsTo(TextWriter writer)
    {
        writer.WriteLine($"---------------------------FLOOR {FloorNumber} STATISTICS--------------------------");
        writer.WriteLine($"Total arrivals on floor: {TotalArrivalsOnFloor}");
        writer.WriteLine($"Average people on floor: {AveragePeopleOnFloor:G2}");
        writer.WriteLine($"Average people on floor (non-zero): {AveragePeopleOnFloorNonZero:G2}");
        writer.WriteLine($"Max people on floor: {MaxPeopleOnFloor}");
        writer.WriteLine($"Average time spent on floor: {AverageTimeSpentOnFloor}");
        writer.WriteLine($"Max time spent on floor: {MaxTimeSpentOnFloor}");
        writer.WriteLine($"Min time spent on floor: {MinTimeSpentOnFloor}");
        writer.WriteLine($"Average waiting time: {AverageWaitingTime}");
        writer.WriteLine($"Max waiting time: {MaxWaitingTime}");
        writer.WriteLine($"Min waiting time: {MinWaitingTime}");
        writer.WriteLine($"Average waiting time percentage: {AverageWaitingTimePercentage:P2}");
        writer.WriteLine($"Max waiting time percentage: {MaxWaitingTimePercentage:P2}");
        writer.WriteLine($"Min waiting time percentage: {MinWaitingTimePercentage:P2}");
        writer.WriteLine();
    }
}
