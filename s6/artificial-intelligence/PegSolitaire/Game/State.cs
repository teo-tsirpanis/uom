using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PegSolitaire.Game
{
    /// <summary>
    /// The state of a game of Peg Solitaire.
    /// </summary>
    public class State
    {
        /// <summary>
        /// A set of the pieces that are currently on the board.
        /// </summary>
        public ImmutableHashSet<BoardPosition> Pieces { get; }

        /// <summary>
        /// The game's starting <see cref="Board"/>.
        /// </summary>
        public Board Board { get; }
        
        /// <summary>
        /// The <see cref="Move"/>s played in this state so far, with the newest first.
        /// </summary>
        /// <seealso cref="TryPlaySingleMove"/>
        /// <seealso cref="TryPlayManyMoves"/>
        public ImmutableStack<Move> RecentMovesPlayed { get; }

        /// <summary>
        /// Starts a game on the given <see cref="Board"/>.
        /// </summary>
        /// <param name="board">The board the game will be played at.</param>
        /// <exception cref="ArgumentNullException"><paramref name="board"/>
        /// is <see langword="null"/>.</exception>
        public State(Board board)
        {
            Board = board ?? throw new ArgumentNullException(nameof(board));

            var piecesBuilder = ImmutableHashSet.CreateBuilder<BoardPosition>();
            for (int x = 1; x <= board.Width; x++)
            for (int y = 1; y <= board.Height; y++)
            {
                var position = new BoardPosition(x, y);
                if (board[position] == SquareState.Taken)
                    piecesBuilder.Add(position);
            }

            Pieces = piecesBuilder.ToImmutable();
            RecentMovesPlayed = ImmutableStack<Move>.Empty;
        }

        private State(Board board, ImmutableHashSet<BoardPosition> pieces, ImmutableStack<Move> recentMovesPlayed)
        {
            Board = board;
            Pieces = pieces;
            RecentMovesPlayed = recentMovesPlayed;
        }

        /// <summary>
        /// Whether the game has been won.
        /// </summary>
        /// <remarks>A game is considered to be won if
        /// there is only one piece remaining.</remarks>
        public bool HasWon => Pieces.Count == 1;

        /// <summary>
        /// Checks if a move is legal. Used internally to save some computations.
        /// </summary>
        private bool IsLegalMoveImpl(in BoardPosition adjacentPosition, in BoardPosition resultingPosition)
        {
            if (!Pieces.Contains(adjacentPosition)) return false;
            return !Pieces.Contains(resultingPosition) && Board[resultingPosition] != SquareState.Invalid;
        }

        /// <summary>
        /// Enumerates all legal <see cref="Move"/>s of the game.
        /// </summary>
        /// <remarks>The order the moves will appear is undefined
        /// and can differ between different calls of this method
        /// on the same state.</remarks>
        public IEnumerable<Move> GetMoves()
        {
            foreach (var piece in Pieces)
                for (int i = (int) MoveDirection.Up; i <= (int) MoveDirection.Right; i++)
                {
                    var move = new Move(piece, (MoveDirection) i);
                    move.GetAdjacentPositions(out var adjacentPosition, out var resultingPosition);

                    if (IsLegalMoveImpl(adjacentPosition, resultingPosition))
                        yield return move;
                }
        }

        private bool TryPlayImpl(ImmutableHashSet<BoardPosition>.Builder pieces, in Move move)
        {
            move.GetAdjacentPositions(out var adjacentPosition, out var resultingPosition);
            if (!IsLegalMoveImpl(adjacentPosition, resultingPosition)) return false;

            pieces.Remove(move.Position);
            pieces.Remove(adjacentPosition);
            pieces.Add(resultingPosition);

            return true;
        }

        /// <summary>
        /// Tries to play a single <see cref="Move"/> on this state of the game.
        /// </summary>
        /// <param name="move">The move to play.</param>
        /// <param name="newState">The <see cref="State"/> of the game
        /// after <paramref name="move"/> was played.</param>
        /// <returns><see langword="true"/> if the <paramref name="move"/>
        /// was legal and <see langword="false"/> if it was not.</returns>
        public bool TryPlaySingleMove(Move move, [NotNullWhen(true)] out State? newState)
        {
            newState = null;

            var pieces = Pieces.ToBuilder();
            if (!TryPlayImpl(pieces, move)) return false;

            newState = new State(Board, pieces.ToImmutable(), RecentMovesPlayed.Push(move));
            Debug.Assert(newState.Pieces.Count == Pieces.Count - 1);
            return true;
        }

        /// <summary>
        /// Tries to play a sequence of <see cref="Move"/>s on this state of the game.
        /// </summary>
        /// <param name="moves">The moves to play in order.</param>
        /// <param name="newState">The <see cref="State"/> of the game
        /// after <paramref name="moves"/> were played.</param>
        /// <param name="illegalMoveIndex">The zero-based index of the first illegal move.
        /// The value only has meaning if the method returns <see langword="false"/>.</param>
        /// <returns>
        /// <see langword="true"/> if all moves were legal and
        /// <see langword="false"/> if at least one of them was not.
        /// </returns>
        /// <remarks>
        /// Using this function is recommended over repeatedly calling
        /// <see cref="TryPlaySingleMove"/> when all moves are known.
        /// </remarks>
        public bool TryPlayManyMoves(IEnumerable<Move> moves, [NotNullWhen(true)] out State? newState,
            out int illegalMoveIndex)
        {
            if (moves == null) throw new ArgumentNullException(nameof(moves));
            newState = null;
            illegalMoveIndex = 0;

            var pieces = Pieces.ToBuilder();
            var recentMovesPlayed = RecentMovesPlayed;

            foreach (var move in moves)
            {
                if (!TryPlayImpl(pieces, move)) return false;
                recentMovesPlayed = recentMovesPlayed.Push(move);
                illegalMoveIndex++;
            }

            newState = new State(Board, pieces.ToImmutable(), recentMovesPlayed);
            // illegalMoveIndex will have by now the total count of moves.
            Debug.Assert(Pieces.Count == newState.Pieces.Count + illegalMoveIndex);
            return true;
        }

        /// <summary>
        /// Pretty-prints the game's state into a string.
        /// </summary>
        /// <param name="takenSquareChar">The character representing a
        /// square where a piece is placed.</param>
        /// <param name="emptySquareChar">The character representing a
        /// square where there is no piece.</param>
        /// <param name="invalidSquareChar">The character representing
        /// a square where no piece can be placed.</param>
        /// <returns></returns>
        public string ToString(char takenSquareChar, char emptySquareChar, char invalidSquareChar)
        {
            var sb = new StringBuilder();
            for (int y = 1; y <= Board.Height; y++)
            {
                for (int x = 1; x <= Board.Width; x++)
                    if (Board[new BoardPosition(x, y)] == SquareState.Invalid)
                        sb.Append(invalidSquareChar);
                    else if (Pieces.Contains(new BoardPosition(x, y)))
                        sb.Append(takenSquareChar);
                    else
                        sb.Append(emptySquareChar);

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private string? _toStringCached;

        /// <inheritdoc/>
        public override string ToString() =>
            // If this method has been called again on the same
            // object we will avoid allocating a new string.
            // The ??= operator essentially means here:
            // if (_toStringCached == null)
            //     _toStringCached = ToString(...);
            // return _toStringCached;
            _toStringCached ??= ToString('O', '-', ' ');
    }
}
