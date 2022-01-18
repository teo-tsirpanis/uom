using System.Diagnostics;

namespace Dai19090.SimulationTechniques.Instruments;

/// <summary>
/// Measures statistics about a <see cref="WaitingQueue"/>.
/// </summary>
public class WaitingQueueInstrument : ISimulationInstrument
{
    private int _queueLength, _totalArrivalsArea, _simulationDuration;

    /// <summary>
    /// The <see cref="WaitingQueue">'s name.
    /// </summary>
    public string QueueName { get; }

    /// <summary>
    /// The maximum amount of time units an arrival has waited in the queue.
    /// </summary>
    public int MaxWaitingTime { get; private set; }

    /// <summary>
    /// The total amount of time units spent while waiting in the queue.
    /// </summary>
    public int TotalWaitingTime { get; private set; }

    /// <summary>
    /// The total number of arrivals that have waited in the queue.
    /// </summary>
    public int TotalQueueArrivals { get; private set; }

    /// <summary>
    /// The maximum number of arrivals that have ever waited in the queue at the same time.
    /// </summary>
    public int MaxQueueLength { get; private set; }

    /// <summary>
    /// The average time units an arrival has waited in the queue.
    /// </summary>
    public double AverageWaitingTime => (double)TotalWaitingTime / TotalQueueArrivals;

    /// <summary>
    /// The average number of arrivals that have waited in the queue at the same time.
    /// </summary>
    public double AverageQueueLength => (double)_totalArrivalsArea / _simulationDuration;

    internal WaitingQueueInstrument(string queueName)
    {
        QueueName = queueName;
    }

    internal void ArrivalCame()
    {
        _queueLength++;
    }

    internal void ArrivalFulfilled(Timestamp startingTime, Timestamp endingTime)
    {
        _queueLength--;
        var waitingTime = endingTime.Value - startingTime.Value;
        TotalWaitingTime += waitingTime;
        TotalQueueArrivals++;
        if (waitingTime > MaxWaitingTime)
            MaxWaitingTime = waitingTime;
    }

    void ISimulationInstrument.OnSimulationTimeChanged(Timestamp newTime)
    {
        var timePassed = newTime.Value - _simulationDuration;
        Debug.Assert(timePassed > 0);
        _totalArrivalsArea += _queueLength * timePassed;
        if (_queueLength > MaxQueueLength)
            MaxQueueLength = _queueLength;

        _simulationDuration = newTime.Value;
    }

    public void WriteResultsTo(TextWriter writer)
    {
        writer.WriteLine($"------------------{QueueName} WAITING QUEUE STATISTICS------------------");
        writer.WriteLine($"Total queue arrivals: {TotalQueueArrivals}");
        writer.WriteLine($"Total waiting time: {TotalWaitingTime}");
        writer.WriteLine($"Max waiting time: {MaxWaitingTime}");
        writer.WriteLine($"Average waiting time: {AverageWaitingTime:G2}");
        writer.WriteLine($"Max queue length: {MaxQueueLength}");
        writer.WriteLine($"Average queue length: {AverageQueueLength:G2}");
        writer.WriteLine();
    }
}
