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
    /// Represents a snapshot of the solver's execution.
    /// </summary>
    /// <param name="CurrentGameState">The game <see cref="PegSolitaire.Game.State"/>
    /// the solver is currently evaluating.</param>
    /// <param name="NextStates">The prospective <see cref="PegSolitaire.Game.State"/>s the
    /// solver will take a look at next. They are sorted in descending
    /// order of value.</param>
    /// <param name="PreviousState">The solver's state before
    /// the move that led to this one was played.</param>
    // A record is a syntactic sugar for a class with some fields and a constructor.
    // It also allows things like the "with" expression as seen in Solver.TryGetNextGameState.
    public record SolverState(State CurrentGameState, ImmutableStack<State> NextStates,
        SolverState? PreviousState);

    /// <summary>
    /// Solves Peg Solitaire games.
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
                    nextGameState = default;
                    subsequentState = null;
                    return false;
                }

                if (!state.NextStates.IsEmpty)
                {
                    subsequentState = state with {NextStates = state.NextStates.Pop(out nextGameState)};
                    return true;
                }

                state = state.PreviousState;
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

                // We sort in descending order because
                var nextStatesSorted = nextStatesBuffer.OrderByDescending(heuristic.GetHeuristic);
                var nextStatesStack = ImmutableStack.CreateRange(nextStatesSorted);
                currentSolverState = new SolverState(gameState, nextStatesStack, currentSolverState);
                totalEvaluatedMoves += nextStatesBuffer.Count;
            }
            finally
            {
                nextStatesBuffer.Clear();
            }
        }

        private static SearchResult SolveImpl(SolverState? state, AbstractGameStateHeuristic heuristic,
            long totalEvaluatedStates, CancellationToken ct)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (true)
            {
                if (ct.IsCancellationRequested)
                    return SearchResult.FromCancelled(stopwatch.Elapsed, totalEvaluatedStates);

                if (state == null || !TryGetNextGameState(state, out var nextGameState, out state))
                    return SearchResult.FromFailed(stopwatch.Elapsed, totalEvaluatedStates);

                if (nextGameState.HasWon)
                    return SearchResult.FromResult(nextGameState.RecentMovesPlayed.Reverse().ToList(),
                        stopwatch.Elapsed, totalEvaluatedStates);

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
        /// <returns></returns>
        public static SearchResult StartSolving(State gameState, AbstractGameStateHeuristic heuristic,
            CancellationToken ct = default)
        {
            long totalEvaluatedStates = 0;
            SolverState? solverState = null;
            TryFindMoreMoves(gameState, heuristic, ref solverState, ref totalEvaluatedStates);
            return SolveImpl(solverState, heuristic, totalEvaluatedStates, ct);
        }

        /// <summary>
        /// Finds more solutions on a <see cref="SolverState"/>.
        /// </summary>
        /// <param name="solverState">The solver's state to be processed.</param>
        /// <param name="heuristic">The <see cref="AbstractGameStateHeuristic"/>
        /// that will be used by the search algorithm.</param>
        /// <param name="ct">A <see cref="CancellationToken"/>
        /// that can be used to cancel the search.</param>
        public static SearchResult ContinueSolving(SolverState solverState,
            AbstractGameStateHeuristic heuristic, CancellationToken ct = default)
        {
            return SolveImpl(solverState, heuristic, 0, ct);
        }
    }
}
