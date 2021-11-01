using Dai19090.SimulationTechniques.RandomNumbers.Analyzers;
using Dai19090.SimulationTechniques.RandomNumbers.Generators;
using System.Diagnostics;

namespace Dai19090.SimulationTechniques.RandomNumbers
{
    public static class Program
    {
        public const int TotalSamples = 1_000_000;
        public const int TotalSamplesToDisplay = 100;

        public static void Main()
        {
            var seed = Random.Shared.Next();
            Console.WriteLine($"Using seed {seed}");

            var rng = new DefaultLinearCongruentialGenerator(seed);

            var analyzers = new IRandomNumberAnalyzer[]
            {
                new LimitedMeasuresOfPositionAnalyzer(TotalSamplesToDisplay),
                new MeasuresOfPositionAnalyzer()
            };

            Console.WriteLine($"Testing the RNG with {TotalSamples} samples");

            var stopwatch = Stopwatch.StartNew();
            RunExperiment(rng, analyzers);
            stopwatch.Stop();

            Console.WriteLine($"Finished in {stopwatch.Elapsed}");

            Console.WriteLine("Displaying results");

            foreach (var analyzer in analyzers) analyzer.WriteResultsTo(Console.Out);
        }

        private static void RunExperiment(IRandomNumberGenerator rng, IRandomNumberAnalyzer[] analyzers)
        {
            for (int i = 0; i < TotalSamples; i++)
            {
                var number = rng.NextDouble();
                foreach (var analyzer in analyzers) analyzer.RecordMeasurement(number);
            }
        }
    }
}
