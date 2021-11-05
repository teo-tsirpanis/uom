namespace Dai19090.SimulationTechniques.RandomNumbers.Analyzers;

public sealed class RegionsTestAnalyzer : IRandomNumberAnalyzer
{
    private readonly int[] _regionFrequencies = new int[10];

    public void RecordMeasurement(double measurement)
    {
        var regionIndex = measurement switch
        {
            < 0.1 => 0,
            < 0.2 => 1,
            < 0.3 => 2,
            < 0.4 => 3,
            < 0.5 => 4,
            < 0.6 => 5,
            < 0.7 => 6,
            < 0.8 => 7,
            < 0.9 => 8,
            _ => 9
        };
        _regionFrequencies[regionIndex]++;
    }

    public void WriteResultsTo(TextWriter output)
    {
        output.WriteLine("--------------------REGIONS TEST--------------------");
        output.WriteLine("This test measures the numbers' frequency within even-spaced regions.");

        var totalMeasurements = _regionFrequencies.Sum();
        var expectedRegionFrequency = (double)totalMeasurements / _regionFrequencies.Length;

        output.WriteLine($"Each region's frequency should be around {expectedRegionFrequency} ({1.0/_regionFrequencies.Length:P}).");
        for (int i = 0; i < _regionFrequencies.Length; i++)
        {
            output.WriteLine($"[{i / 10.0}, {(i + 1) / 10.0}): {_regionFrequencies[i]} ({(double)_regionFrequencies[i] / totalMeasurements:P})");
        }

        output.WriteLine();
    }
}
