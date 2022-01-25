using Dai19090.SimulationTechniques.Instruments;
using System.Diagnostics;

namespace Dai19090.SimulationTechniques.ElevatorSim;

public sealed class PeopleInstrument : ISimulationInstrument
{
    private UpDownAccumulator _peopleOnBuildingAccumulator;

    private IntegerAccumulator _timeSpentAccumulator, _waitingTimeAccumulator;

    private RealAccumulator _waitingTimePercentageAccumulator;

    public TimeSpan AverageTimeSpent => _timeSpentAccumulator.Average.ToSeconds();

    public TimeSpan MaxTimeSpent => TimeSpan.FromSeconds(_timeSpentAccumulator.Max);

    public TimeSpan MinTimeSpent => TimeSpan.FromSeconds(_timeSpentAccumulator.Min);

    public TimeSpan AverageWaitingTime => _waitingTimeAccumulator.Average.ToSeconds();

    public TimeSpan MaxWaitingTime => TimeSpan.FromSeconds(_waitingTimeAccumulator.Max);

    public TimeSpan MinWaitingTime => TimeSpan.FromSeconds(_waitingTimeAccumulator.Min);

    public double AverageWaitingTimePercentage => _waitingTimePercentageAccumulator.Average;

    public double MaxWaitingTimePercentage => _waitingTimePercentageAccumulator.Max;

    public double MinWaitingTimePercentage => _waitingTimePercentageAccumulator.Min;

    internal PeopleInstrument() { }

    internal void ArrivalFulfilled(Timestamp arrivalTime, Timestamp departureTime, int productiveTime)
    {
        var timeSpent = departureTime - arrivalTime;
        var waitingTime = timeSpent - productiveTime;
        var waitingTimePercentage = (double)waitingTime / timeSpent;
        Debug.Assert(waitingTime >= 0);
        _timeSpentAccumulator.Submit(timeSpent);
        _waitingTimeAccumulator.Submit(waitingTime);
        _waitingTimePercentageAccumulator.Submit(waitingTimePercentage);
    }

    void ISimulationInstrument.OnSimulationTimeChanged(Timestamp newTime)
    {
        _peopleOnBuildingAccumulator.AdvanceTime(newTime);
    }

    public void WriteResultsTo(TextWriter writer)
    {
        writer.WriteLine("---------------------------PEOPLE STATISTICS--------------------------");
        writer.WriteLine($"Average time spent: {AverageTimeSpent}");
        writer.WriteLine($"Max time spent: {MaxTimeSpent}");
        writer.WriteLine($"Min time spent: {MinTimeSpent}");
        writer.WriteLine($"Average waiting time: {AverageWaitingTime}");
        writer.WriteLine($"Max waiting time: {MaxWaitingTime}");
        writer.WriteLine($"Min waiting time: {MinWaitingTime}");
        writer.WriteLine($"Average waiting time percentage: {AverageWaitingTimePercentage:P2}");
        writer.WriteLine($"Max waiting time percentage: {MaxWaitingTimePercentage:P2}");
        writer.WriteLine($"Min waiting time percentage: {MinWaitingTimePercentage:P2}");
        writer.WriteLine();
    }
}
