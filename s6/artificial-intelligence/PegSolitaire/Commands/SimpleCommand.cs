using System;
using System.Collections.Generic;
using System.IO;
using PegSolitaire.Ai;
using PegSolitaire.Game;

namespace PegSolitaire.Commands
{
    internal static class SimpleCommand
    {
        private static void WriteSolutionToFile(string outputFile, IReadOnlyCollection<Move> moves)
        {
            using var file = File.CreateText(outputFile);
            file.WriteLine(moves.Count);
            foreach (var move in moves)
            {
                var startingPos = move.Position;
                var resultingPos = move.GetResultingPosition();
                file.WriteLine($"{startingPos.X} {startingPos.Y} {resultingPos.X} {resultingPos.Y}");
            }
        }

        public static int Run(string commandName, string algorithmName, AbstractGameStateHeuristic heuristic,
            TimeSpan timeout, ReadOnlySpan<string> args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine($"{commandName} - solves Peg Solitaire Games using {algorithmName}-first search");
                Console.WriteLine($"Usage: {commandName} <input file> <output file>");
                return 1;
            }

            var inputFile = args[0];
            var outputFile = args[1];

            var board = Board.FromFile(inputFile);
            if (board == null)
            {
                Console.WriteLine("Error while reading the input file.");
                return 1;
            }

            var initialState = new State(board);
            var searchResult = CommandLineSolver.StartSolving(initialState, heuristic, timeout);
            int exitCode = 0;
            if (searchResult.FoundSolution)
            {
                Console.WriteLine("Solution found, writing it to the output file.");
                WriteSolutionToFile(outputFile, searchResult.Solution);
            }
            else if (!searchResult.CanContinue)
            {
                Console.WriteLine("No solution could be found.");
                exitCode = 2;
            }

            CommandLineUtilities.PrintPerformanceSummary(searchResult.TotalEvaluatedStates, searchResult.ElapsedTime);

            return exitCode;
        }
    }
}
