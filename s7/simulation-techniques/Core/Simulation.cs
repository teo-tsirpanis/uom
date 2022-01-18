using Dai19090.SimulationTechniques.Infrastructure;

namespace Dai19090.SimulationTechniques;

public static partial class Simulation
{
    private static readonly AsyncLocal<ISimulationState?> _ambientState = new();

    internal static ISimulationState GetCurrentState()
    {
        var ambientState = _ambientState.Value;
        if (ambientState is null)
            ThrowHelpers.ThrowNotInsideSimulation();
        return ambientState;
    }

    /// <summary>
    /// Runs a simulation.
    /// </summary>
    /// <param name="initSimulation">A delegate that kicks off the simulation's work items.
    /// It must call <c>async SimulationOp</c> methods in a fire-and-forget style.</param>
    /// <param name="options">The simulation's options. Also passed to <paramref name="initSimulation"/>.</param>
    /// <param name="initArg">An argument that gets passed to <paramref name="initSimulation"/>.</param>
    /// <remarks>
    /// In documentation, code running "inside a simulation" means code that is called from
    /// <paramref name="initSimulation"/> directly or indirectly.
    /// </remarks>
    public static SimulationResult Run(Action<ISimulationState, SimulationOptions> initSimulation, SimulationOptions options)
    {
        var state = new SimulationState(options);
        var oldState = _ambientState.Value;
        _ambientState.Value = state;
        try
        {
            initSimulation(state, options);
        }
        finally
        {
            _ambientState.Value = oldState;
        }

        while (state.RunNextWorkItem());

        return new(state.CurrentTime.Value, state.GetInstruments());
    }

    /// <summary>
    /// When awaited, pauses the execution of the simulation operation
    /// for <paramref name="delay"/> time units.
    /// </summary>
    /// <param name="delay">The number of time units to wait for. Must be positive.</param>
    /// <remarks>
    /// Time starts counting when the method's return value is awaited, not when the method is called.
    /// </remarks>
    public static DelayAwaitable Delay(int delay)
    {
        if (delay < 0)
            ThrowHelpers.ThrowNegativeNumber(nameof(delay), delay);
        return new(delay);
    }
}
