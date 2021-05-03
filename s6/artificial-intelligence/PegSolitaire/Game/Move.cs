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
        public BoardPosition Position { get; }

        /// <summary>
        /// The direction at which the piece will move.
        /// </summary>
        public MoveDirection Direction { get; }

        /// <summary>
        /// Creates a <see cref="Move"/>.
        /// </summary>
        /// <remarks>This constructor is not meant to called from
        /// outside the <see cref="State.GetMoves"/> method.</remarks>
        internal Move(BoardPosition position, MoveDirection direction)
        {
            Position = position;
            Direction = direction;
        }

        /// <summary>
        /// Calculates important <see cref="BoardPosition"/>s for this move. 
        /// </summary>
        /// <param name="posOneSquareAway">The position one square away from
        /// <see cref="Position"/> towards <see cref="Direction"/>. In Peg
        /// Solitaire this move will be considered legal if the square at
        /// that position has a piece.</param>
        /// <param name="posTwoSquaresAway">The position two squares away from
        /// <see cref="Position"/> towards <see cref="Direction"/>. In Peg
        /// Solitaire this move will be considered legal if the square at
        /// that position is empty.</param>
        /// <remarks>This method may return invalid positions if
        /// the move itself is invalid (such as moving up while
        /// already being at the top of the board).</remarks>
        public void GetAdjacentPositions(out BoardPosition posOneSquareAway, out BoardPosition posTwoSquaresAway)
        {
            int x = Position.X;
            int y = Position.Y;
            ref int coordToChange = ref x;
            int displacement = 0;

            // Depending on the direction, we will decide
            // which coordinate to change and by how much.
            switch (Direction)
            {
                case MoveDirection.Up:
                    coordToChange = ref y;
                    displacement = -1;
                    break;
                case MoveDirection.Down:
                    coordToChange = ref y;
                    displacement = 1;
                    break;
                case MoveDirection.Left:
                    displacement = -1;
                    break;
                case MoveDirection.Right:
                    displacement = 1;
                    break;
            }

            coordToChange += displacement;
            // At this point the coordinates will be one square away.
            posOneSquareAway = new BoardPosition(x, y);
            coordToChange += displacement;
            // At this point the coordinates will be two squares away.
            posTwoSquaresAway = new BoardPosition(x, y);
        }

        /// <summary>
        /// Gets the position the piece will move to.
        /// </summary>
        /// <remarks>This method may return an invalid position if
        /// the move itself is invalid (such as moving up while
        /// already being at the top of the board).</remarks>
        public BoardPosition GetResultingPosition()
        {
            GetAdjacentPositions(out _, out var position);
            return position;
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
