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
        output.WriteLine($"Mean: {mean:G6} (should be near {ExpectedMean:G6}, difference is {Math.Abs(mean - ExpectedMean):E})");
        var stdev = GetStandardDeviation();
        output.WriteLine($"Standard deviation: {stdev:G6} (should be near {ExpectedStandardDeviation:G6}, difference is {Math.Abs(stdev - ExpectedStandardDeviation):E})");
    }

    public virtual void WriteResultsTo(TextWriter output)
    {
        output.WriteLine("--------------------MEASURES OF POSITION--------------------");
        WriteSummary(output);
        output.WriteLine();
    }
}
