using System.Diagnostics;

namespace Dai19090.SimulationTechniques.Instruments;

public struct UpDownAccumulator
{
    private int _totalArea, _totalTimeUnits, _totalTimeUnitsNonZero;

    public int Value { get; private set; }

    public int Max { get; private set; }

    public double Average => (double)_totalArea / _totalTimeUnits;

    public double AverageNonZero => (double)_totalArea / _totalTimeUnitsNonZero;

    public void Up()
    {
        var value = ++Value;
        if (value > Max)
            Max = value;
    }

    public void Down()
    {
        if (Value == 0)
            throw new InvalidOperationException("Cannot decrement an accumulator below zero.");
        Value--;
    }

    public void AdvanceTime(Timestamp timeUnits)
    {
        Debug.Assert(timeUnits.Value > _totalTimeUnits);
        var elapsedTime = timeUnits.Value - _totalTimeUnits;
        _totalArea += Value * elapsedTime;
        _totalTimeUnits = timeUnits.Value;
        if (Value != 0)
            _totalTimeUnitsNonZero += elapsedTime;
    }
}
