using Dai19090.SimulationTechniques.Randomness;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Dai19090.SimulationTechniques.ElevatorSim;

public enum ElevatorStrategy { Simple, Smart }

public sealed class ElevatorSimOptions : SimulationOptions
{
    private ulong? _seed;

    public int NumberOfFloors { get; set; } = 8;

    public int NumberOfElevators { get; set; } = 2;

    public int TotalArrivals { get; set; } = 500;

    public int ElevatorMovingDelay { get; set; } = 5;

    public int ElevatorDoorOpeningDelay { get; set; } = 2;

    public int ElevatorDoorOpeningDuration { get; set; } = 5;

    public int ElevatorCapacity { get; set; } = 4;

    public NormalDistribution DurationOfStayOnFloor { get; set; } = new(TimeSpan.FromMinutes(30).TotalSeconds, TimeSpan.FromMinutes(7.5).TotalSeconds);

    public NormalDistribution NumberOfFloorsVisited { get; set; } = new(2, 0.5);

    public float MeanTimeBetweenArrivals { get; set; } = (float)TimeSpan.FromMinutes(2).TotalSeconds;

    public ElevatorStrategy ElevatorStrategy { get; set; } = ElevatorStrategy.Simple;

    public ulong? Seed
    {
        get => _seed;
        set
        {
            var seed = value ?? GenerateRandomSeed();
            _seed = seed;
            RandomNumberGenerator = new Pcg32Generator(seed);
        }
    }

    public ElevatorSimOptions() : base(new Pcg32Generator(0)) { }

    private static ulong GenerateRandomSeed()
    {
        Span<byte> buffer = stackalloc byte[sizeof(ulong)];
        System.Security.Cryptography.RandomNumberGenerator.Fill(buffer);
        return MemoryMarshal.Read<ulong>(buffer);
    }

    public void Validate()
    {
        var exceptions = new List<Exception>();

        AssertIsStrictlyPositive(NumberOfFloors);
        AssertIsStrictlyPositive(NumberOfElevators);
        AssertIsStrictlyPositive(TotalArrivals);
        AssertIsPositive(ElevatorMovingDelay);
        AssertIsPositive(ElevatorDoorOpeningDelay);
        AssertIsPositive(ElevatorDoorOpeningDuration);
        AssertIsPositive(ElevatorCapacity);
        if (MeanTimeBetweenArrivals <= 0)
            exceptions.Add(new ArgumentOutOfRangeException(nameof(MeanTimeBetweenArrivals), MeanTimeBetweenArrivals, "Value must be greater than zero."));
        if (!Enum.IsDefined(ElevatorStrategy))
            exceptions.Add(new ArgumentOutOfRangeException(nameof(ElevatorStrategy), $"Value must be one of {string.Join(',', Enum.GetNames<ElevatorStrategy>())}."));

        if (exceptions.Count > 0)
            throw new AggregateException("Validating options failed", exceptions);

        void AssertIsPositive(int x, [CallerArgumentExpression("x")] string? expression = null)
        {
            if (x < 0)
                exceptions!.Add(new ArgumentOutOfRangeException(expression, x, "Value must be positive."));
        }

        void AssertIsStrictlyPositive(int x, [CallerArgumentExpression("x")] string? expression = null)
        {
            if (x <= 0)
                exceptions!.Add(new ArgumentOutOfRangeException(expression, x, "Value must be greater than zero."));
        }
    }
}
