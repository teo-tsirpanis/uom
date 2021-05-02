using System;

namespace PegSolitaire.Game
{
    /// <summary>
    /// A position in a <see cref="Board"/>.
    /// </summary>
    public readonly struct BoardPosition : IEquatable<BoardPosition>
    {
        /// <summary>
        /// The position's X coordinate, starting from top to bottom.
        /// </summary>
        public int X { get; init; }

        /// <summary>
        /// The position's Y coordinate, starting from left to right.
        /// </summary>
        public int Y { get; init; }

        /// <inheritdoc/>
        public bool Equals(BoardPosition other) =>
            X == other.X && Y == other.Y;

        /// <inheritdoc/>
        public override bool Equals(object? obj) =>
            obj is BoardPosition other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(X, Y);

        /// <inheritdoc/>
        public override string ToString() => $"({X}, {Y})";
    }
}
