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
            TimeSpan? timeout, ReadOnlySpan<string> args)
        {
            if (args.Length == 0 || args.Length > 2)
            {
                Console.WriteLine($"{commandName} - solves Peg Solitaire games using {algorithmName}-first search");
                Console.WriteLine($"Usage: {commandName} <input file> <optional output file>");
                return 1;
            }

            var inputFile = args[0];

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
                if (args.Length == 2)
                {
                    Console.WriteLine("Solution found, writing it to the output file.");
                    WriteSolutionToFile(args[1], searchResult.Solution);
                }
                else
                {
                    Console.WriteLine("Solution found:");
                    foreach (var move in searchResult.Solution) Console.WriteLine(move.ToString());
                }
            }
            else if (!searchResult.CanContinue)
            {
                Console.WriteLine("No solution could be found.");
                exitCode = 2;
            }

            Console.WriteLine($"Evaluated {searchResult.TotalEvaluatedStates} game states in {searchResult.ElapsedTime}");

            return exitCode;
        }
    }
}
