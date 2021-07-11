using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Medallion.Shell;

internal static class Program
{
    private const string DEPTH = "depth";

    private const string HILL = "hill";

    private static readonly Regex timeSpentMatcher = new(@"Time spent: (\d*\.\d*) secs", RegexOptions.Compiled);

    /// <summary>
    /// Generates random Boolean Satisfiability problems with various constraints and solves them.
    /// </summary>
    /// <param name="output">A CSV file with the execution's results.</param>
    /// <param name="k">How many disjunctions each constraint will have.</param>
    /// <param name="n">How many variables the problems have.</param>
    /// <param name="ratios">How many ratios of constraints to variables to test.</param>
    /// <param name="trials">How many problems to test for each number of variables.</param>
    /// <param name="parallelism">The maximum amount of solver processes
    /// to run in parallel. Defaults to the number of CPU cores.</param>
    static async Task Main(string output = "results.csv", int k = 4, int n = 20, int ratios = 10, int trials = 10, int parallelism = 0)
    {
        output = Path.GetFullPath(output);
        if (parallelism <= 0) parallelism = Environment.ProcessorCount;

        using var concurrencyLimiter = new SemaphoreSlim(parallelism);

        var executions = new List<Task<ExecutionResult>>();

        for (int i = 0; i < trials; i++)
            QueueExecution(executions, k, 1, n, concurrencyLimiter);
        for (int i = 1; i <= ratios; i++)
            for (int j = 1; j <= trials; j++)
                QueueExecution(executions, k, i * n, n, concurrencyLimiter);

        var results = await Task.WhenAll(executions);

        foreach (var x in results)
            if (File.Exists(x.InputFile))
                File.Delete(x.InputFile);

        Console.WriteLine($"Writing results to {output}");
        await AnalyzeResultsAsync(output, results, n);
    }

    static async Task AnalyzeResultsAsync(string resultsFile, ExecutionResult[] results, int n)
    {
        var query =
            results
                .GroupBy(x => x.VariableCount / n)
                .Select(x =>
                {
                    int count = 0, successfulCount = 0;
                    foreach (var execution in x)
                    {
                        count++;
                        if (execution.Successful) successfulCount++;
                    }

                    var dict =
                        x.GroupBy(y => y.Method)
                        .ToDictionary(y => y.Key, y =>
                        {
                            var sum = y.Sum(z => z.Successful ? z.DurationMilliseconds : null).GetValueOrDefault();
                            return successfulCount == 0 ? 0 : sum / successfulCount;
                        });
                    return new
                    {
                        RatioMOverN = x.Key,
                        ProbabilityOfSuccess = (double)successfulCount / count,
                        DepthMilliseconds = dict[DEPTH],
                        HillMilliseconds = dict[HILL]
                    };
                });

        await using var file = new StreamWriter(resultsFile);
        await file.WriteLineAsync("MoverN,ProbabilityOfSuccess,DepthMs,HillMs");
        foreach (var x in query)
        {
            // Without Invariant, decimal points in Greek computers
            // will be printed as commas, confusing the CSV file.
            var line = FormattableString.Invariant($"{x.RatioMOverN},{x.ProbabilityOfSuccess},{x.DepthMilliseconds},{x.HillMilliseconds}");
            await file.WriteLineAsync(line);
        }
    }

    static void QueueExecution(List<Task<ExecutionResult>> executions, int k, int m, int n, SemaphoreSlim concurrencyLimiter)
    {
        var inputFile = GenerateProblem(k, m, n);
        executions.Add(ExecuteAsync(DEPTH, inputFile, m, concurrencyLimiter));
        executions.Add(ExecuteAsync(HILL, inputFile, m, concurrencyLimiter));
    }

    static async Task<ExecutionResult> ExecuteAsync(string method, string inputFile, int m, SemaphoreSlim concurrencyLimiter)
    {
        var tempOutput = Path.GetTempFileName();
        try
        {
            await concurrencyLimiter.WaitAsync();
            var command = Command.Run("bcsp", method, inputFile, tempOutput);
            Console.Error.WriteLine($"Starting solving {inputFile} with {m} constraints using the {method} algorithm on process {command.ProcessId}");
            CommandResult result = await command.Task;
            Console.Error.WriteLine($"Process {command.ProcessId} exited.");
            var stdout = result.StandardOutput;

            var successful = !stdout.Contains("NO SOLUTION", StringComparison.Ordinal);

            if (successful && !await VerifyAsync(inputFile, tempOutput))
                Console.WriteLine($"A problem with {m} constraints is not verified!");

            var timeSpent = (int)TimeSpan.FromSeconds(double.Parse(timeSpentMatcher.Match(stdout).Groups[1].Value, NumberFormatInfo.InvariantInfo)).TotalMilliseconds;

            return new ExecutionResult(m, method, inputFile, timeSpent, successful);
        }
        finally
        {
            concurrencyLimiter.Release();
            File.Delete(tempOutput);
        }
    }

    /// <summary>
    /// Generates a random Boolean Satisfiability problem and
    /// places it in a temporary file whose path is returned.
    /// </summary>
    static string GenerateProblem(int k, int m, int n)
    {
        var tempFile = Path.GetTempFileName();
        var rng = new Random();
        using (var writer = new StreamWriter(tempFile))
        {
            writer.WriteLine($"{n} {m} {k}");
            for (var i = 0; i < m; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    var num = rng.Next(1, n);
                    if (rng.Next() % 2 == 0)
                        num = -num;
                    writer.Write($"{num} ");
                }
                writer.WriteLine();
            }
        }
        return tempFile;
    }

    static async Task<bool> VerifyAsync(string problemFile, string outFile)
    {
        var result = await Command.Run("bcsp_validate", problemFile, outFile).Task;
        var stdout = result.StandardOutput;
        return stdout.Contains("ok!", StringComparison.Ordinal);
    }

    record ExecutionResult(int VariableCount, string Method, string InputFile, int DurationMilliseconds, bool Successful);
}
