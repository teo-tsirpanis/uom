namespace Dai19090.SimulationTechniques.ElevatorSim;

internal static class Utilities
{
    public static void MoveNullsToTheEnd<T> (this Span<T> x) where T: class?
    {
        x.Sort(static (x1, x2) => (x1 is null).CompareTo(x2 is null));
    }
}
