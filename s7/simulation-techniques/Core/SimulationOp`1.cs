using Dai19090.SimulationTechniques.Infrastructure;
using System.Runtime.CompilerServices;

namespace Dai19090.SimulationTechniques;

/// <summary>
/// A descendant of <see cref="SimulationOp"/> that has a result value.
/// </summary>
/// <typeparam name="TResult">The type of the simulation op's result value.</typeparam>
[AsyncMethodBuilder(typeof(AsyncSimulationOpMethodBuilder<>))]
public class SimulationOp<TResult> : SimulationOp
{
    internal static readonly SimulationOp<TResult> s_defaultResultOp = new() { _isCompleted = true };

    internal TResult? _result;

    internal bool TrySetResult(TResult result)
    {
        if (!TryComplete()) return false;
        _result = result;
        InvokeContinuations();
        return true;
    }

    internal void SetResult(TResult result)
    {
        if (!TrySetResult(result))
            ThrowHelpers.ThrowSimulationOpAlreadyCompleted();
    }

    internal SimulationOp() { }

    public new SimulationOpAwaiter<TResult> GetAwaiter() => new(this);
}
