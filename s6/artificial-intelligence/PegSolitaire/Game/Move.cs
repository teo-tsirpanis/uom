using System;

namespace PegSolitaire.Game
{
    /// <summary>
    /// The direction a game piece goes in a <see cref="Move"/>.
    /// </summary>
    public enum MoveDirection : byte
    {
        /// <summary>
        /// The piece goes two squares upwards.
        /// </summary>
        Up,

        /// <summary>
        /// The piece goes two squares downwards.
        /// </summary>
        Down,

        /// <summary>
        /// The piece goes two squares to the left.
        /// </summary>
        Left,

        /// <summary>
        /// The piece goes two squares to the right.
        /// </summary>
        Right
    }

    /// <summary>
    /// A move in the game, where one piece moves
    /// from one position to another near it.
    /// </summary>
    public readonly struct Move : IEquatable<Move>
    {
        /// <summary>
        /// The position of the piece that is going to be moved.
        /// </summary>
        public BoardPosition Position { get; init; }

        /// <summary>
        /// The direction at which the piece will move.
        /// </summary>
        public MoveDirection Direction { get; init; }

        /// <summary>
        /// Gets the position the piece will move to.
        /// </summary>
        /// <remarks>This method may return an invalid position if
        /// the move is illegal (such as moving up while already
        /// being at the top-left corner of the board).</remarks>
        public BoardPosition GetResultingPosition()
        {
            var x = Position.X;
            var y = Position.Y;

            switch (Direction)
            {
                case MoveDirection.Up:
                    y -= 2;
                    break;
                case MoveDirection.Down:
                    y += 2;
                    break;
                case MoveDirection.Left:
                    x -= 2;
                    break;
                case MoveDirection.Right:
                    x += 2;
                    break;
            }

            return new BoardPosition {X = x, Y = y};
        }

        /// <inheritdoc/>
        public bool Equals(Move other) =>
            Position.Equals(other.Position) && Direction == other.Direction;

        /// <inheritdoc/>
        public override bool Equals(object? obj) =>
            obj is Move other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() =>
            HashCode.Combine(Position.X, Position.Y, Direction);

        /// <inheritdoc/>
        public override string ToString() => $"{Position} -> {GetResultingPosition()}";
    }
}
