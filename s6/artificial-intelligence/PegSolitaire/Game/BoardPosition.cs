using System;
using System.Runtime.CompilerServices;

namespace PegSolitaire.Game
{
    /// <summary>
    /// A position in a <see cref="Board"/>.
    /// </summary>
    public readonly struct BoardPosition : IEquatable<BoardPosition>
    {
        /// <summary>
        /// The position's one-based X coordinate, starting from top to bottom.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// The position's one-based Y coordinate, starting from left to right.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Creates a <see cref="BoardPosition"/>
        /// with the given one-based coordinates.
        /// </summary>
        public BoardPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

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

    internal static class BoardPositionExtensions
    {
        /// <summary>
        /// Accesses two-dimensional arrays with a <see cref="BoardPosition"/>.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="position"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T GetFromPosition<T>(this T[,] array, in BoardPosition position) =>
            ref array[position.Y - 1, position.X - 1];
    }
}
