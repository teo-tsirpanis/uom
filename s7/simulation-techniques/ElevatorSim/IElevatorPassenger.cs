namespace Dai19090.SimulationTechniques.ElevatorSim;

public interface IElevatorPassenger
{
    CorrelationId CorrelationId { get; }

    int CurrentFloor { get; set; }
}
