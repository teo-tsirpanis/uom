namespace Dai19090.SimulationTechniques.ElevatorSim;

public enum ElevatorDirection
{
    Up = 1,
    Down = -1
}

public static class DirectionExtensions
{
    public static ElevatorDirection Opposite(this ElevatorDirection direction) =>
        direction == ElevatorDirection.Up ? ElevatorDirection.Down : ElevatorDirection.Up;

    public static ElevatorDirection Create(int currentFloor, int destinationFloor) =>
        Math.Sign(destinationFloor - currentFloor) switch
        {
            1 => ElevatorDirection.Up,
            -1 => ElevatorDirection.Down,
            _ => throw new ArgumentException($"{nameof(currentFloor)} and {nameof(destinationFloor)} cannot be the same."),
        };
}
