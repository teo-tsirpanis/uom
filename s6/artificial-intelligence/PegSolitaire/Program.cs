using System;
using PegSolitaire.Ai.Heuristics;
using PegSolitaire.Commands;

TimeSpan? timeout = TimeSpan.FromSeconds(30);

static int PrintUsage()
{
    Console.WriteLine("Usage: dotnet run <command> <arguments>");
    Console.WriteLine("Available commands: dfs");
    return 1;
}

if (args.Length == 0)
    return PrintUsage();
ReadOnlySpan<string> otherArgs = args.AsSpan(1);
return args[0] switch
{
    "dfs" => SimpleCommand.Run("dfs", "depth", new RandomHeuristic(), timeout, otherArgs),
    "best" => SimpleCommand.Run("best", "best", ManhattanDistanceHeuristic.Instance, timeout, otherArgs),
    _ => PrintUsage()
};
