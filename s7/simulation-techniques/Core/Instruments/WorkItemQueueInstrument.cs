namespace Dai19090.SimulationTechniques.Instruments;

internal sealed class WorkItemQueueInstrument : ISimulationInstrument
{
    private int _simulationDuration, _totalFruitfulTimeUnits, _totalWorkItems;

    public void WorkItemRan()
    {
        _totalWorkItems++;
    }

    public void SimulationTimeChanged(Timestamp newTime)
    {
        _simulationDuration = newTime.Value;
        _totalFruitfulTimeUnits++;
    }

    public void WriteResultsTo(TextWriter writer)
    {
        writer.WriteLine($"Total work items executed: {_totalWorkItems}");
        writer.WriteLine($"Simulation duration: {_simulationDuration} time units");
        writer.WriteLine($"Total fruitful time units (with scheduled work items): {_totalFruitfulTimeUnits} ({_totalFruitfulTimeUnits * 100.0 / _simulationDuration:P2})");
        writer.WriteLine($"Average work items per time unit: {_totalWorkItems / (double)_simulationDuration:G2}");
        writer.WriteLine($"Average work items per fruitful time unit: {_totalWorkItems / (double)_totalFruitfulTimeUnits:G2}");
    }
}
