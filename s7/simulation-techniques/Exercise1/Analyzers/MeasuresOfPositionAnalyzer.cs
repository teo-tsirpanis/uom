using System.Globalization;

namespace Dai19090.SimulationTechniques.RandomNumbers;

public class MeasuresOfPositionAnalyzer : IRandomNumberAnalyzer
{
    private long _count;
    private double _runningSum, _runningSumOfSquares;

    protected const double ExpectedMean = 0.5;

    protected double GetMean() => _runningSum / _count;

    protected static readonly double ExpectedStandardDeviation = 1 / Math.Sqrt(12);

    protected double GetStandardDeviation()
    {
        var meanOfSquares = _runningSumOfSquares / _count;
        var mean = GetMean();
        var squareOfMean = mean * mean;
        return Math.Sqrt(meanOfSquares - squareOfMean);
    }

    public virtual void RecordMeasurement(double measurement)
    {
        _count++;
        _runningSum += measurement;
        _runningSumOfSquares += measurement * measurement;
    }

    protected void WriteSummary(TextWriter output)
    {
        var mean = GetMean();
        var meanLine = string.Create(CultureInfo.InvariantCulture,
            $"Mean: {mean} (should be near {ExpectedMean}, difference is {Math.Abs(mean - ExpectedMean)})");
        output.WriteLine(meanLine);
        var stdev = GetStandardDeviation();
        var stdevLine = string.Create(CultureInfo.InvariantCulture,
            $"Standard deviation: {stdev} (should be near {ExpectedStandardDeviation}, difference is {Math.Abs(stdev - ExpectedStandardDeviation)})");
        output.WriteLine(stdevLine);
    }

    public virtual void WriteResultsTo(TextWriter output)
    {
        output.WriteLine("--------------------MEASURES OF POSITION--------------------");
        WriteSummary(output);
        output.WriteLine();
    }
}
