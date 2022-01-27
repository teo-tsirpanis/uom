using Dai19090.SimulationTechniques;
using Dai19090.SimulationTechniques.ElevatorSim;
using Dai19090.SimulationTechniques.Randomness;
using System.Text.Json;

if (args.Length != 2)
{
    Console.WriteLine("Usage: <input file> <output file>");
    return 1;
}

var inputFile = args[0];
var outputFile = args[1];

var options = await LoadOptionsAsync(inputFile);

var logItems = new List<string>();
var simOptions = new SimulationOptions(new Pcg32Generator(options.Seed.GetValueOrDefault()));
simOptions.OnLogMessage += (timestamp, id, message) =>
{
    logItems.Add($"{Utilities.FormatLogItem(timestamp, id)} {message}");
};

var result = ElevatorSimulation.Run(options, simOptions);

await MarkdownRenderer.WriteElevatorSimResultsToFileAsync(outputFile, options, result, logItems);
Console.WriteLine($"Success");
return 0;

static async Task<ElevatorSimOptions> LoadOptionsAsync(string path)
{
    await using var stream = new FileStream(path, new FileStreamOptions() { Access = FileAccess.Read, Mode = FileMode.Open, Options = FileOptions.Asynchronous });
    var elevatorSimOptions = await JsonSerializer.DeserializeAsync(stream, ElevatorSimJsonContext.Default.ElevatorSimOptions);
    return elevatorSimOptions!;
}
