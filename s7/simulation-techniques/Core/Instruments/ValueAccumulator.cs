using System.Numerics;

namespace Dai19090.SimulationTechniques.Instruments;

public struct ValueAccumulator<T> where T : INumber<T>
{
    public T Total { get; private set; }

    public int SubmissionCount { get; private set; }

    public T Max { get; private set; }

    public T Min { get; private set; }

    public double Average => double.CreateSaturating(Total) / SubmissionCount;

    public void Submit(T value)
    {
        if (T.IsNegative(value))
            throw new ArgumentOutOfRangeException(nameof(value));
        if (value > Max)
            Max = value;
        if (value < Min || SubmissionCount == 0)
            Min = value;
        Total += value;
        SubmissionCount++;
    }
}
