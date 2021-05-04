using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using PegSolitaire.Game;

namespace PegSolitaire.Ai
{
    /// <summary>
    /// The result of a search for the solutions to a Peg Solitaire game.
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// Whether the search managed to find a solution.
        /// </summary>
        /// <remarks>A value of <see langword="false"/> may mean either
        /// that the algorithm exhaustively searched all possible outcomes
        /// to no avail, or that the search was cancelled. Consult
        /// <see cref="CanContinue"/> to dinstinguish.</remarks>
        [MemberNotNullWhen(true, nameof(Solution))]
        public bool FoundSolution => Solution != null;

        /// <summary>
        /// Whether search can continue to find more results.
        /// </summary>
        /// <seealso cref="Solver.ContinueSolving"/>
        [MemberNotNullWhen(true, nameof(SubsequentSolverState))]
        public bool CanContinue => SubsequentSolverState != null;

        /// <summary>
        /// The time the search took.
        /// </summary>
        public TimeSpan ElapsedTime { get; }

        /// <summary>
        /// The total number of game <see cref="State"/>s
        /// that were evaluated during the search.
        /// </summary>
        public long TotalEvaluatedStates { get; }

        /// <summary>
        /// The first sequence of <see cref="Move"/>s the search found
        /// (if it did) that lead to a winning game of Peg Solitaire. 
        /// </summary>
        public IReadOnlyList<Move>? Solution { get; }

        /// <summary>
        /// The <see cref="SolverState"/> from which the
        /// search can continue to find more solutions.
        /// </summary>
        /// <remarks>If it is <see langword="null"/>, search
        /// has exhausted all possible outcomes and cannot find another solution.</remarks>
        public SolverState? SubsequentSolverState { get; }

        internal SearchResult(IReadOnlyList<Move>? solution, TimeSpan elapsedTime, long totalEvaluatedStates,
            SolverState? subsequentSolverState)
        {
            Solution = solution;
            ElapsedTime = elapsedTime;
            TotalEvaluatedStates = totalEvaluatedStates;
            SubsequentSolverState = subsequentSolverState;
        }
    }
}
