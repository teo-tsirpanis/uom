using System;
using System.Linq;
using PegSolitaire.Game;

namespace PegSolitaire.Ai.Heuristics
{
    /// <summary>
    /// Assigns a heuristic value to each <see cref="State"/>
    /// based on the Manhattan Distance between its pieces.
    /// </summary>
    /// <remarks>This class is a thread-safe singleton and
    /// cannot be created. Use <see cref="Instance"/> to
    /// access it.</remarks>
    public sealed class ManhattanDistanceHeuristic : AbstractGameStateHeuristic
    {
        private static int ManhattanDistance(BoardPosition pos1, BoardPosition pos2) =>
            Math.Abs(pos1.X - pos2.X) + Math.Abs(pos1.Y - pos2.Y);

        /// <summary>
        /// The singleton instance of this class.
        /// </summary>
        public static ManhattanDistanceHeuristic Instance { get; } =
            new ManhattanDistanceHeuristic();

        private ManhattanDistanceHeuristic()
        {
        }

        /// <inheritdoc/>
        public override float GetHeuristic(State state)
        {
            var numberOfPieces = state.Pieces.Count;
            Span<BoardPosition> pieces = numberOfPieces <= 64
                ? stackalloc BoardPosition[numberOfPieces]
                : new BoardPosition [numberOfPieces];
            var i = 0;
            foreach (var piece in state.Pieces) pieces[i++] = piece;
            var distanceSum = 0;
            for (i = 0; i < pieces.Length; i++)
            for (int j = i + 1; j < pieces.Length; j++)
                distanceSum += ManhattanDistance(pieces[i], pieces[j]);

            // We don't need to pick averages; all competing
            // states will have the same number of pieces.
            return distanceSum;
        }
    }
}
