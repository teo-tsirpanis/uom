using System;
using System.IO;
using PegSolitaire.Game;

namespace PegSolitaire.Commands
{
    internal static class VerifyCommand
    {
        private static Move[]? ReadMoves(string path)
        {
            using var file = File.OpenText(path);
            if (!int.TryParse(file.ReadLine(), out var moveCount)) return null;

            var moves = new Move[moveCount];
            for (int i = 0; i < moveCount; i++)
            {
                var line = file.ReadLine();
                if (line == null) return null;

                var coordinates = line.Split(' ');
                if (coordinates.Length != 4) return null;

                if (!int.TryParse(coordinates[0], out var x1)) return null;
                if (!int.TryParse(coordinates[1], out var y1)) return null;
                if (!int.TryParse(coordinates[2], out var x2)) return null;
                if (!int.TryParse(coordinates[3], out var y2)) return null;

                var pos1 = new BoardPosition(x1, y1);
                var pos2 = new BoardPosition(x2, y2);

                if (!Move.TryCreateFromPositions(pos1, pos2, out moves[i])) return null;
            }

            return moves;
        }

        public static int Run(ReadOnlySpan<string> args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine($"verify - plays Peg Solitaire games");
                Console.WriteLine($"Usage: verify <board file> <moves file>");
                return 1;
            }

            var boardFile = args[0];
            var movesFile = args[1];

            var board = Board.FromFile(boardFile);
            if (board == null)
            {
                Console.WriteLine("Error while reading the input file.");
                return 1;
            }

            var moves = ReadMoves(movesFile);
            if (moves == null)
            {
                Console.WriteLine("Error while reading the moves file.");
                return 1;
            }

            var state = new State(board);
            if (!state.TryPlayManyMoves(moves, out var newState, out var illegalMoveIndex))
            {
                Console.WriteLine($"Error while playing the game: move #{illegalMoveIndex + 1} is illegal.");
                return 1;
            }
            
            Console.WriteLine($"After {moves.Length} moves were played, the game's state looks like this:");
            Console.WriteLine(newState);
            if (!newState.HasWon())
            {
                Console.WriteLine("The game is not won.");
                return 2;
            }

            Console.WriteLine("The game is won!");
            return 0;
        }
    }
}
