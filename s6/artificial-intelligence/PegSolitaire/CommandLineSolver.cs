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
        [SuppressMessage("ReSharper", "AccessToDisposedClosure")]
        private static SearchResult RunWithCancellation<TInput>(
            Func<TInput, AbstractGameStateHeuristic, CancellationToken, SearchResult> f,
            TInput input, AbstractGameStateHeuristic heuristic, TimeSpan? timeout)
        {
            using var cts = new CancellationTokenSource();
            var userCancelled = false;
            try
            {
                Console.CancelKeyPress += OnCtrlC;
                Console.Write("Press Ctrl+C to cancel...");

                if (timeout != null)
                    cts.CancelAfter(timeout.Value);
                var result = f(input, heuristic, cts.Token);
                Console.WriteLine();
                if (cts.IsCancellationRequested && !userCancelled)
                    Console.WriteLine($"Execution timed-out after {timeout}");
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
            RunWithCancellation(Solver.StartSolving, gameState, heuristic, timeout);

        /// <seealso cref="Solver.ContinueSolving"/>
        public static SearchResult ContinueSolving(SolverState gameState, AbstractGameStateHeuristic heuristic,
            TimeSpan? timeout = null) =>
            RunWithCancellation(Solver.ContinueSolving, gameState, heuristic, timeout);
    }
}
