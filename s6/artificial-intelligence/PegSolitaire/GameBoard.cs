using System.IO;

namespace PegSolitaire
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
    public class GameBoard
    {
        private readonly SquareState[,] _board;

        private GameBoard(SquareState[,] board)
        {
            _board = board;
        }

        /// <summary>
        /// The board's width.
        /// </summary>
        /// <remarks>If the board is not square, this property will contain the
        /// distance between the leftmost and the rightmost element.</remarks>
        public int Width => _board.GetLength(1);

        /// <summary>
        /// The board's height.
        /// </summary>
        /// <remarks>If the board is not square, this property will contain the
        /// distance between the topmost and the bottommost element.</remarks>
        public int Height => _board.GetLength(0);

        /// <summary>
        /// Returns the <see cref="SquareState"/> of the
        /// board's square at the given (X,Y) coordinates.
        /// </summary>
        /// <param name="line">The zero-based coordinate of the square's line.</param>
        /// <param name="col">The zero-based coordinate of the square's column.</param>
        /// <exception cref="System.IndexOutOfRangeException">
        /// Either <paramref name="line"/> or <paramref name="col"/> is negative
        /// or greater than or equal to <see cref="Height"/> or <see cref="Width"/>
        /// respectively.</exception>
        public SquareState this[int line, int col] => _board[col, line];

        /// <summary>
        /// Reads a <see cref="GameBoard"/> from the given <see cref="TextReader"/>.
        /// </summary>
        /// <returns>The game board, or <see langword="null"/> if the input was invalid.</returns>
        /// <remarks>The input's syntax is specified in the
        /// assignment's statement. Examples of it are provided.</remarks>
        public static GameBoard? FromTextReader(TextReader reader)
        {
            var dimensionsLine = reader.ReadLine();
            if (dimensionsLine == null) return null;
            var dimensions = dimensionsLine.Split(' ');
            if (dimensions.Length != 2) return null;
            if (!int.TryParse(dimensions[0], out var width)) return null;
            if (!int.TryParse(dimensions[1], out var height)) return null;

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

            return new GameBoard(board);
        }

        /// <summary>
        /// Reads a <see cref="GameBoard"/> from a string.
        /// </summary>
        /// <seealso cref="FromTextReader"/>
        public static GameBoard? FromString(string str) =>
            FromTextReader(new StringReader(str));

        /// <summary>
        /// Reads a <see cref="GameBoard"/> from a file at the fiven path.
        /// </summary>
        /// <seealso cref="FromTextReader"/>
        public static GameBoard? FromFile(string path)
        {
            using var file = File.OpenText(path);
            return FromTextReader(file);
        }
    }
}
