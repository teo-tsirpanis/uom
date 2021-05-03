using System.IO;

namespace PegSolitaire.Game
{
    /// <summary>
    /// The state a square of the board can be in.
    /// </summary>
    public enum SquareState : byte
    {
        /// <summary>
        /// No piece can be placed on this square.
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// A piece is on this square.
        /// </summary>
        Taken = 1,

        /// <summary>
        /// A piece can be on this square but currently isn't.
        /// </summary>
        Empty = 2
    }

    /// <summary>
    /// Represents the initial board of a Peg Solitaire game.
    /// </summary>
    public class Board
    {
        private readonly SquareState[,] _board;

        private Board(SquareState[,] board)
        {
            _board = board;
            Width = _board.GetLength(1);
            Height = _board.GetLength(0);
        }

        /// <summary>
        /// The board's width.
        /// </summary>
        /// <remarks>If the board is not square, this property will contain the distance
        /// between the leftmost and the rightmost square where a piece can be placed.</remarks>
        public int Width { get; }

        /// <summary>
        /// The board's height.
        /// </summary>
        /// <remarks>If the board is not square, this property will contain the distance
        /// between the topmost and the bottommost square where a piece can be placed.</remarks>
        public int Height { get; }

        /// <summary>
        /// Returns the <see cref="SquareState"/> of the
        /// board's square at the given <see cref="BoardPosition"/>.
        /// </summary>
        /// <param name="position">The square's position.</param>
        /// <returns>The square's state, or <see cref="SquareState.Invalid"/>
        /// if <paramref name="position"/> is invalid.</returns>
        public SquareState this[BoardPosition position]
        {
            get
            {
                if (position.X < 0 || position.X >= Width || position.Y < 0 || position.Y >= Height)
                    return SquareState.Invalid;
                return _board[position.Y, position.X];
            }
        }

        /// <summary>
        /// Reads a <see cref="Board"/> from the given <see cref="TextReader"/>.
        /// </summary>
        /// <returns>The game board, or <see langword="null"/> if the input was invalid.</returns>
        /// <remarks>The input's syntax is specified in the
        /// assignment's statement. Examples of it are provided.</remarks>
        public static Board? FromTextReader(TextReader reader)
        {
            var dimensionsLine = reader.ReadLine();
            if (dimensionsLine == null) return null;
            var dimensions = dimensionsLine.Split(' ');
            if (dimensions.Length != 2) return null;
            if (!int.TryParse(dimensions[0], out var height)) return null;
            if (!int.TryParse(dimensions[1], out var width)) return null;

            var board = new SquareState[height, width];

            for (int i = 0; i < height; i++)
            {
                var line = reader.ReadLine();
                if (line == null) return null;
                var numbers = line.Split(' ');
                if (numbers.Length != width) return null;
                for (int j = 0; j < width; j++)
                {
                    if (!int.TryParse(numbers[j], out var x) || x < 0 || x > 2) return null;
                    board[i, j] = (SquareState) x;
                }
            }

            return new Board(board);
        }

        /// <summary>
        /// Reads a <see cref="Board"/> from a string.
        /// </summary>
        /// <seealso cref="FromTextReader"/>
        public static Board? FromString(string str) =>
            FromTextReader(new StringReader(str));

        /// <summary>
        /// Reads a <see cref="Board"/> from a file at the fiven path.
        /// </summary>
        /// <seealso cref="FromTextReader"/>
        public static Board? FromFile(string path)
        {
            using var file = File.OpenText(path);
            return FromTextReader(file);
        }
    }
}
