using System;
using System.Runtime.CompilerServices;
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            var distanceSum = 0;
            for (int x1 = 1; x1 <= state.Board.Width; x1++)
            for (int y1 = 1; y1 <= state.Board.Height; y1++)
            {
                var pos1 = new BoardPosition(x1, y1);
                if (!state.HasPiece(pos1)) continue;
                for (int x2 = 1; x2 <= state.Board.Width; x2++)
                for (int y2 = 1; y2 <= state.Board.Height; y2++)
                {
                    var pos2 = new BoardPosition(x2, y2);
                    if (state.HasPiece(pos2)) distanceSum += ManhattanDistance(pos1, pos2);
                }
            }

            // We don't need to pick averages; all competing
            // states will have the same number of pieces.
            return distanceSum;
        }
    }
}
