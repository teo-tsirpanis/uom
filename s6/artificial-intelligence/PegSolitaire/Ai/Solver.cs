using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using PegSolitaire.Game;

namespace PegSolitaire.Ai
{
    /// <summary>
    /// Solves Peg Solitaire games using best-first search.
    /// </summary>
    public static class Solver
    {
        private static bool TryGetNextGameState([DisallowNull] SolverState? state,
            [NotNullWhen(true)] out State? nextGameState,
            [NotNullWhen(true)] out SolverState? subsequentState)
        {
            while (true)
            {
                if (state == null)
                {
                    nextGameState = null;
                    subsequentState = null;
                    return false;
                }

                if (!state.RemainingNextStates.IsEmpty)
                {
                    subsequentState = state.PopNextGameState(out nextGameState);
                    return true;
                }

                state = state.ParentState;
            }
        }

        [ThreadStatic] private static List<State>? _reusableNextStatesBuffer;

        private static void TryFindMoreMoves(State gameState, AbstractGameStateHeuristic heuristic,
            ref SolverState? currentSolverState, ref long totalEvaluatedMoves)
        {
            var nextStatesBuffer = _reusableNextStatesBuffer ??= new List<State>();
            try
            {
                Debug.Assert(nextStatesBuffer.Count == 0);
                foreach (var move in gameState.GetMoves())
                {
                    if (gameState.TryPlaySingleMove(move, out var nextGameState))
                        nextStatesBuffer.Add(nextGameState);
                    else
                        Debug.Fail("State.GetMoves cannot return moves that cannot be played.");
                }

                if (nextStatesBuffer.Count == 0) return;

                // We sort in descending order to make the state with
                // the worst heuristic value fall deeper in the stack.
                var nextStatesSorted =
                    nextStatesBuffer.OrderByDescending(heuristic.GetHeuristic);
                var nextStatesStack = ImmutableStack.CreateRange(nextStatesSorted);
                currentSolverState =
                    SolverState.Create(gameState, nextStatesStack, currentSolverState);
                totalEvaluatedMoves += nextStatesBuffer.Count;
            }
            finally
            {
                nextStatesBuffer.Clear();
            }
        }

        private static IReadOnlyList<Move>? SolveImpl(ref SolverState? state, AbstractGameStateHeuristic heuristic,
            ref long totalEvaluatedStates, CancellationToken ct)
        {
            var originalSolverState = state;
            while (true)
            {
                if (ct.IsCancellationRequested || state == null ||
                    !TryGetNextGameState(state, out var nextGameState, out state))
                {
                    Debug.Assert(state != null || originalSolverState != state,
                        "Solver state did not change; it will lead to infinite loops.");
                    return null;
                }

                if (nextGameState.HasWon())
                    return nextGameState.RecentMovesPlayed.Reverse().ToList();

                TryFindMoreMoves(nextGameState, heuristic, ref state, ref totalEvaluatedStates);
            }
        }

        /// <summary>
        /// Starts solving a game <see cref="State"/>.
        /// </summary>
        /// <param name="gameState">The game state to solve.</param>
        /// <param name="heuristic">The <see cref="AbstractGameStateHeuristic"/>
        /// that will be used by the search algorithm.</param>
        /// <param name="ct">A <see cref="CancellationToken"/>
        /// that can be used to cancel the search.</param>
        public static SearchResult StartSolving(State gameState, AbstractGameStateHeuristic heuristic,
            CancellationToken ct = default)
        {
            var stopwatch = Stopwatch.StartNew();
            long totalEvaluatedStates = 0;
            SolverState? solverState = null;
            TryFindMoreMoves(gameState, heuristic, ref solverState, ref totalEvaluatedStates);
            var solution = SolveImpl(ref solverState, heuristic, ref totalEvaluatedStates, ct);
            stopwatch.Stop();
            return new SearchResult(solution, stopwatch.Elapsed, totalEvaluatedStates, solverState);
        }

        /// <summary>
        /// Finds more solutions on a <see cref="SolverState"/>.
        /// </summary>
        /// <param name="solverState">The solver's state to be processed.</param>
        /// <param name="heuristic">The <see cref="AbstractGameStateHeuristic"/>
        /// that will be used by the search algorithm.</param>
        /// <param name="ct">A <see cref="CancellationToken"/>
        /// that can be used to cancel the search.</param>
        /// <seealso cref="SearchResult.SubsequentSolverState"/>
        public static SearchResult ContinueSolving([DisallowNull] SolverState? solverState,
            AbstractGameStateHeuristic heuristic, CancellationToken ct = default)
        {
            var stopwatch = Stopwatch.StartNew();
            long totalEvaluatedStates = 0;
            var solution = SolveImpl(ref solverState, heuristic, ref totalEvaluatedStates, ct);
            stopwatch.Stop();
            return new SearchResult(solution, stopwatch.Elapsed, totalEvaluatedStates, solverState);
        }
    }
}
