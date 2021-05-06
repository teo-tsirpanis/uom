using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using PegSolitaire.Ai;
using PegSolitaire.Game;

namespace PegSolitaire
{
    /// <summary>
    /// Enhances <see cref="Solver"/>'s methods by making them able to
    /// be cancelled either by time-out or by the user pressing Ctrl-C,
    /// and by reporting its progress at regular intervals.
    /// </summary>
    public static class CommandLineSolver
    {
        [SuppressMessage("ReSharper", "AccessToDisposedClosure")]
        private static SearchResult RunWithCancellationAndProgress(
            Func<CancellationToken, IProgress<SolverState>?, SearchResult> f, TimeSpan? timeout)
        {
            using var cts = new CancellationTokenSource();
            var userCancelled = false;
            try
            {
                Console.CancelKeyPress += OnCtrlC;
                Console.Write("Press Ctrl+C to cancel...");

                if (timeout != null)
                    cts.CancelAfter(timeout.Value);
                var progress = new Progress<SolverState>(state =>
                    Console.WriteLine($"Progress: {state.CompletionPercentage:P}."));
                var result = f(cts.Token, progress);
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
            RunWithCancellationAndProgress((ct, progress) =>
                Solver.StartSolving(gameState, heuristic, ct, progress), timeout);

        /// <seealso cref="Solver.ContinueSolving"/>
        public static SearchResult ContinueSolving(SolverState gameState, AbstractGameStateHeuristic heuristic,
            TimeSpan? timeout = null) =>
            RunWithCancellationAndProgress((ct, progress) =>
                Solver.ContinueSolving(gameState, heuristic, ct, progress), timeout);
    }
}
