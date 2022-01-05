namespace Dai19090.SimulationTechniques.Infrastructure;

public readonly struct SimulationOpAwaiter : ISimulationCompletion
{
    private readonly SimulationOp _op;

    internal SimulationOpAwaiter(SimulationOp op)
    {
        _op = op;
    }

    public bool IsCompleted => _op.IsCompleted;

    public void GetResult() => _op.CheckCompletedException();

    public void UnsafeOnCompleted(ISimulationState state, ISimulationWorkItem workItem)
    {
        _op.UnsafeAddContinuation(workItem);
    }
}
