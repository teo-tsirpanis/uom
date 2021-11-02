namespace Dai19090.SimulationTechniques.RandomNumbers.Analyzers;

public sealed class LimitedMeasuresOfPositionAnalyzer : MeasuresOfPositionAnalyzer
{
    private readonly List<double> _measurements;

    public LimitedMeasuresOfPositionAnalyzer(int capacity)
    {
        _measurements = new List<double>(capacity);
    }

    public override void RecordMeasurement(double measurement)
    {
        if (_measurements.Count == _measurements.Capacity) return;

        _measurements.Add(measurement);
        base.RecordMeasurement(measurement);
    }

    public override void WriteResultsTo(TextWriter output)
    {
        output.WriteLine($"--------------------FIRST {_measurements.Count} NUMBERS--------------------");
        for (int i = 0; i < _measurements.Count; i++)
        {
            output.Write(_measurements[i].ToString("F7"));
            if (i % 10 == 9)
                output.WriteLine();
            else
                output.Write(' ');
        }
        output.WriteLine();
        WriteSummary(output);
        output.WriteLine();
    }
}
