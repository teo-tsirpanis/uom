using System.Diagnostics;

namespace Dai19090.SimulationTechniques.Instruments;

/// <summary>
/// Measures statistics about a <see cref="WaitingQueue"/>.
/// </summary>
public class WaitingQueueInstrument : ISimulationInstrument
{
    private UpDownAccumulator _queueLengthAccumulator;

    private IntegerAccumulator _waitingTimeAccumulator;

    /// <summary>
    /// The <see cref="WaitingQueue">'s name.
    /// </summary>
    public string QueueName { get; }

    /// <summary>
    /// The maximum amount of time units an arrival has waited in the queue.
    /// </summary>
    public int MaxWaitingTime => _waitingTimeAccumulator.Max;

    /// <summary>
    /// The total amount of time units spent while waiting in the queue.
    /// </summary>
    public int TotalWaitingTime => _waitingTimeAccumulator.Total;

    /// <summary>
    /// The total number of arrivals that have waited in the queue.
    /// </summary>
    public int TotalQueueArrivals => _waitingTimeAccumulator.SubmissionCount;

    /// <summary>
    /// The average time units an arrival has waited in the queue.
    /// </summary>
    public double AverageWaitingTime => _waitingTimeAccumulator.Average;

    /// <summary>
    /// The maximum number of arrivals that have ever waited in the queue at the same time.
    /// </summary>
    public int MaxQueueLength => _queueLengthAccumulator.Max;

    /// <summary>
    /// The average number of arrivals that have waited in the queue at the same time.
    /// </summary>
    public double AverageQueueLength => _queueLengthAccumulator.Average;

    internal WaitingQueueInstrument(string queueName)
    {
        QueueName = queueName;
    }

    internal void ArrivalCame()
    {
        _queueLengthAccumulator.Up();
    }

    internal void ArrivalFulfilled(Timestamp startingTime, Timestamp endingTime)
    {
        _queueLengthAccumulator.Down();
        var waitingTime = endingTime.Value - startingTime.Value;
        _waitingTimeAccumulator.Submit(waitingTime);
    }

    void ISimulationInstrument.OnSimulationTimeChanged(Timestamp newTime)
    {
        _queueLengthAccumulator.AdvanceTime(newTime);
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
