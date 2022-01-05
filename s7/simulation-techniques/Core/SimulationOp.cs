using Dai19090.SimulationTechniques.Infrastructure;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace Dai19090.SimulationTechniques;

/// <summary>
/// Represents a task that runs pseudo-concurrently with others within a simulation.
/// </summary>
/// <remarks>
/// Such tasks can be launched inside a simulation by defining
/// and calling an <c>async SimulationOp</c> function.
/// </remarks>
[AsyncMethodBuilder(typeof(AsyncSimulationOpMethodBuilder))]
public class SimulationOp
{
    private bool _isCompleted;
    private ExceptionDispatchInfo? _exception;
    private List<ISimulationWorkItem>? _continuations;

    /// <summary>
    /// Whether the operation has completed.
    /// </summary>
    public bool IsCompleted => _isCompleted;

    /// <summary>
    /// Whether the operation has completed successfully.
    /// </summary>
    public bool IsCompletedSuccessfully => _isCompleted && _exception == null;

    /// <summary>
    /// Whether the operation has failed.
    /// </summary>
    public bool IsFaulted => _isCompleted && _exception != null;

    /// <summary>
    /// A completed <see cref="SimulationOp"/>.
    /// </summary>
    public static SimulationOp Completed { get; } = new SimulationOp() { _isCompleted = true};

    public SimulationOpAwaiter GetAwaiter() => new(this);

    internal SimulationOp()
    {
    }

    internal void UnsafeAddContinuation(ISimulationWorkItem continuation)
    {
        if (_isCompleted)
            Simulation.GetCurrentState().UnsafeQueueWorkItemNow(continuation);
        else
            (_continuations ??= new()).Add(continuation);
    }

    internal void InvokeContinuations()
    {
        var continuations = Interlocked.Exchange(ref _continuations, null);
        if (continuations is null)
            return;

        var simulationState = Simulation.GetCurrentState();
        foreach (var continuation in continuations)
            simulationState.UnsafeQueueWorkItemNow(continuation);
    }

    internal void CheckCompletedException()
    {
        if (!_isCompleted)
            ThrowHelpers.ThrowSimulationOpNotCompleted();
        _exception?.Throw();
    }

    internal void SetResult()
    {
        if (_isCompleted)
            ThrowHelpers.ThrowSimulationOpAlreadyCompleted();
        _isCompleted = true;
        InvokeContinuations();
    }

    internal void SetException(Exception exception)
    {
        if (_isCompleted)
            ThrowHelpers.ThrowSimulationOpAlreadyCompleted();
        _isCompleted = true;
        _exception = ExceptionDispatchInfo.Capture(exception);
        InvokeContinuations();
    }
}
