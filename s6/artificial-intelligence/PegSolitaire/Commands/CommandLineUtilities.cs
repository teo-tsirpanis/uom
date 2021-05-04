using System;

namespace PegSolitaire.Commands
{
    internal static class CommandLineUtilities
    {
        public static void PrintPerformanceSummary(long totalStatesEvaluated, TimeSpan elapsedTime) =>
            Console.WriteLine($"Evaluated {totalStatesEvaluated} game states in {elapsedTime}");
    }
}
