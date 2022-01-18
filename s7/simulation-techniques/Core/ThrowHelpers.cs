using System.Diagnostics.CodeAnalysis;

namespace Dai19090.SimulationTechniques;

internal static class ThrowHelpers
{
    [DoesNotReturn]
    public static void ThrowNegativeNumber(string argName, int x)
    {
        throw new ArgumentOutOfRangeException(argName, x, "Number must not be negative.");
    }

    [DoesNotReturn]
    public static void ThrowNotInsideSimulation()
    {
        throw new InvalidOperationException("Operation is allowed only inside a simulation");
    }

    [DoesNotReturn]
    public static void ThrowInvalidAsyncSimulationOpMethodBuilderUse()
    {
        throw new InvalidOperationException($"The {nameof(Infrastructure.AsyncSimulationOpMethodBuilder)} type has been used in an invalid way.");
    }

    [DoesNotReturn]
    public static void ThrowCannotAwaitOutsideSimulation(Type type)
    {
        throw new InvalidOperationException($"Cannot await {type.Name} outside of a simulation.");
    }

    [DoesNotReturn]
    public static void ThrowSimulationOpNotCompleted()
    {
        throw new InvalidOperationException("SimulationOp must be completed before calling GetResult.");
    }

    [DoesNotReturn]
    public static void ThrowSimulationOpAlreadyCompleted()
    {
        throw new InvalidOperationException("SimulationOp must be completed before calling GetResult.");
    }
}
