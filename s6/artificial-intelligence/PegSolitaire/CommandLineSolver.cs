using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using PegSolitaire.Ai;
using PegSolitaire.Game;

namespace PegSolitaire
{
    /// <summary>
    /// Enhances <see cref="Solver"/>'s methods by making them able to
    /// be cancelled either by time-out or by the user pressing Ctrl-C.
    /// </summary>
    public static class CommandLineSolver
    {
        private const string PegSolitaireDisableTimeout = "PEG_SOLITAIRE_DISABLE_TIMEOUT";

        private static readonly bool _isTimeoutDisabled =
            Environment.GetEnvironmentVariable(PegSolitaireDisableTimeout) == "1";

        [SuppressMessage("ReSharper", "AccessToDisposedClosure")]
        private static SearchResult RunWithCancellation(Func<CancellationToken, SearchResult> f, TimeSpan? timeout)
        {
            using var cts = new CancellationTokenSource();
            var userCancelled = false;
            try
            {
                Console.CancelKeyPress += OnCtrlC;
                Console.WriteLine("Press Ctrl+C to cancel...");

                if (timeout != null && !_isTimeoutDisabled)
                    cts.CancelAfter(timeout.Value);
                var result = f(cts.Token);
                Console.WriteLine();
                if (cts.IsCancellationRequested && !userCancelled)
                {
                    Console.WriteLine($"Execution timed-out after {timeout}");
                    Console.WriteLine(
                        $"You can disable the timeout by setting the \"{PegSolitaireDisableTimeout}\" environment variable to 1.");
                }

                return result;
            }
            finally
            {
                Console.CancelKeyPress -= OnCtrlC;
            }

            void OnCtrlC(object? sender, ConsoleCancelEventArgs args)
            {
                if (args.SpecialKey != ConsoleSpecialKey.ControlC || cts.IsCancellationRequested)
                    return;
                Console.WriteLine("Cancelling...");
                cts.Cancel();
                userCancelled = true;
                args.Cancel = true;
            }
        }

        /// <seealso cref="Solver.StartSolving"/>
        public static SearchResult StartSolving(State gameState, AbstractGameStateHeuristic heuristic,
            TimeSpan? timeout = null) =>
            RunWithCancellation(ct => Solver.StartSolving(gameState, heuristic, ct), timeout);

        /// <seealso cref="Solver.ContinueSolving"/>
        public static SearchResult ContinueSolving(SolverState gameState, AbstractGameStateHeuristic heuristic,
            TimeSpan? timeout = null) =>
            RunWithCancellation(ct => Solver.ContinueSolving(gameState, heuristic, ct), timeout);
    }
}
