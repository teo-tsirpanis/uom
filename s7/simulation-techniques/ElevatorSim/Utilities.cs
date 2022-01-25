namespace Dai19090.SimulationTechniques.ElevatorSim;

internal static class Utilities
{
    internal static TimeOnly BaseElevatorSimTime => new(8, 0);

    public static void MoveNullsToTheEnd<T> (this Span<T> x) where T: class?
    {
        x.Sort(static (x1, x2) => (x1 is null).CompareTo(x2 is null));
    }

    public static string FormatLogItem(Timestamp timestamp, CorrelationId correlationId)
    {
        var time = BaseElevatorSimTime.Add(TimeSpan.FromSeconds(timestamp.Value), out var wrappedDays);

        if (correlationId.IsDefault)
            return $"[D{wrappedDays + 1} {time:HH:mm:ss}]";
        else
            return $"[D{wrappedDays + 1} {time:HH:mm:ss} {correlationId.Value}]";
    }
}
