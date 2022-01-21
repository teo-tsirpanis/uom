using Dai19090.SimulationTechniques.Randomness;

namespace Dai19090.SimulationTechniques.ElevatorSim;

public sealed class ElevatorSimOptions : SimulationOptions
{
    public int NumberOfFloors { get; set; }

    public int NumberOfElevators { get; set; }

    public int NumberOfPeople { get; set; }

    public int ElevatorMovingDelay { get; set; }

    public int ElevatorDoorOpeningDelay { get; set; }

    public int ElevatorCapacity { get; set; }

    public ElevatorSimOptions(ulong seed) : base(new Pcg32Generator(seed))
    {
    }
}
