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
public partial class SimulationOp
{
    private protected bool _isCompleted;
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
    public static SimulationOp CompletedOp { get; } = new() { _isCompleted = true };

    /// <summary>
    /// Creates a failed <see cref="SimulationOp"/>.
    /// </summary>
    /// <param name="e">The exception that is thrown when the op gets awaited.</param>
    public static SimulationOp FromException(Exception e) =>
        new() { _isCompleted = true, _exception = ExceptionDispatchInfo.Capture(e) };

    /// <summary>
    /// Creates a failed <see cref="SimulationOp{T}"/>.
    /// </summary>
    /// <param name="e">The exception that is thrown when the op gets awaited.</param>
    public static SimulationOp<TResult> FromException<TResult>(Exception e) =>
        new() { _isCompleted = true, _exception = ExceptionDispatchInfo.Capture(e) };

    public static SimulationOp<TResult> FromResult<TResult>(TResult result) =>
        result is null ? SimulationOp<TResult>.s_defaultResultOp : new() { _isCompleted = true, _result = result };

    public SimulationOpAwaiter GetAwaiter() => new(this);

    internal SimulationOp() { }

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

    private protected bool TryComplete()
    {
        if (_isCompleted)
            return false;
        _isCompleted = true;
        return true;
    }

    internal void CheckCompletedException()
    {
        if (!_isCompleted)
            ThrowHelpers.ThrowSimulationOpNotCompleted();
        _exception?.Throw();
    }

    internal bool TrySetResult()
    {
        if (!TryComplete()) return false;
        InvokeContinuations();
        return true;
    }

    internal bool TrySetException(Exception exception)
    {
        if (!TryComplete()) return false;
        _exception = ExceptionDispatchInfo.Capture(exception);
        InvokeContinuations();
        return true;
    }

    internal void SetResult()
    {
        if (!TrySetResult())
            ThrowHelpers.ThrowSimulationOpAlreadyCompleted();
    }

    internal void SetException(Exception exception)
    {
        if (!TrySetException(exception))
            ThrowHelpers.ThrowSimulationOpAlreadyCompleted();
    }
}
