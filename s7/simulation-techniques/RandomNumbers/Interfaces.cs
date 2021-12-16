namespace Dai19090.SimulationTechniques.RandomNumbers;

public interface IRandomNumberGenerator
{
    double NextDouble();
}

public interface IRandomNumberAnalyzer
{
    void RecordMeasurement(double measurement);

    void WriteResultsTo(TextWriter output);
}
