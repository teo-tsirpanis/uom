using System.Diagnostics.CodeAnalysis;

namespace Dai19090.SimulationTechniques;

internal static class ThrowHelpers
{
    [DoesNotReturn]
    public static void ThrowArgumentNull(string argName)
    {
        throw new ArgumentNullException(argName);
    }

    [DoesNotReturn]
    public static void ThrowNegativeNumber(string argName, int x)
    {
        throw new ArgumentOutOfRangeException(argName, x, "Number must not be negative.");
    }
}
