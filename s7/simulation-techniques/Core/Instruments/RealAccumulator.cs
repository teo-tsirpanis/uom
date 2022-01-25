namespace Dai19090.SimulationTechniques.Instruments;

public struct RealAccumulator
{
    public double Total { get; private set; }

    public int SubmissionCount { get; private set; }

    public double Max { get; private set; }

    public double Min { get; private set; }

    public double Average => (double)Total / SubmissionCount;

    public void Submit(double value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));
        if (value > Max)
            Max = value;
        if (value < Min || SubmissionCount == 0)
            Min = value;
        Total += value;
        SubmissionCount++;
    }
}
