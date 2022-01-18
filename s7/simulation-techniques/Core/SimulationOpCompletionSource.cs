namespace Dai19090.SimulationTechniques;

/// <summary>
/// Controls the delayed completion of a <see cref="SimulationOp"/>
/// </summary>
public sealed class SimulationOpCompletionSource
{
    /// <summary>
    /// The completion source's <see cref="SimulationOp"/>.
    /// </summary>
    public SimulationOp Op { get; } = new();

    /// <summary>
    /// Marks <see cref="Op"/> as failed.
    /// </summary>
    /// <param name="exception">The exception to be thrown when <see cref="Op"/> is awaited.</param>
    public void SetException(Exception e) => Op.SetException(e);

    /// <summary>
    /// Marks <see cref="Op"/> as completed.
    /// </summary>
    public void SetResult() => Op.SetResult();
}

/// <summary>
/// Controls the delayed completion of a <see cref="SimulationOp{TResult}"/>
/// </summary>
public sealed class SimulationOpCompletionSource<TResult>
{
    /// <summary>
    /// The completion source's <see cref="SimulationOp{TResult}"/>.
    /// </summary>
    public SimulationOp<TResult> Op { get; } = new();

    /// <summary>
    /// Marks <see cref="Op"/> as failed.
    /// </summary>
    /// <param name="exception">The exception to be thrown when <see cref="Op"/> is awaited.</param>
    public void SetException(Exception e) => Op.SetException(e);

    /// <summary>
    /// Marks <see cref="Op"/> as completed.
    /// </summary>
    public void SetResult(TResult result) => Op.SetResult(result);
}
