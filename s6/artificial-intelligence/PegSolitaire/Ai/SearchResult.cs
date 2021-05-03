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
        /// <see cref="IsCancelled"/> to dinstinguish.</remarks>
        [MemberNotNullWhen(true, nameof(Solution))]
        public bool IsSuccessful { get; private init; }

        /// <summary>
        /// Whether the search was cancelled while it was running.
        /// </summary>
        /// <remarks>The search is considered to be
        /// cancelled if it is timed-out too.</remarks>
        public bool IsCancelled { get; private init; }

        /// <summary>
        /// The time the search took.
        /// </summary>
        public TimeSpan ElapsedTime { get; private init; }

        /// <summary>
        /// The total number of moves that were evaluated during the search.
        /// </summary>
        public long TotalEvaluatedMoves { get; private init; }

        /// <summary>
        /// The first sequence of <see cref="Move"/>s the search found
        /// (if it did) that lead to a winning game of Peg Solitaire. 
        /// </summary>
        /// <remarks>This property is not <see langword="null"/> if
        /// <see cref="IsSuccessful"/> is <see langword="true"/>.</remarks>
        public IReadOnlyList<Move>? Solution { get; private init; }

        internal static SearchResult FromResult(IReadOnlyList<Move> solution, TimeSpan elapsedTime,
            long totalEvaluatedMoves) =>
            new SearchResult
            {
                IsSuccessful = true,
                IsCancelled = false,
                ElapsedTime = elapsedTime,
                TotalEvaluatedMoves = totalEvaluatedMoves,
                Solution = solution
            };

        internal static SearchResult FromFailed(TimeSpan elapsedTime, long totalEvaluatedMoves) =>
            new SearchResult
            {
                IsSuccessful = false,
                IsCancelled = false,
                ElapsedTime = elapsedTime,
                TotalEvaluatedMoves = totalEvaluatedMoves
            };

        internal static SearchResult FromCancelled(TimeSpan elapsedTime, long totalEvaluatedMoves) =>
            new SearchResult
            {
                IsSuccessful = false,
                IsCancelled = true,
                ElapsedTime = elapsedTime,
                TotalEvaluatedMoves = totalEvaluatedMoves
            };
    }
}
