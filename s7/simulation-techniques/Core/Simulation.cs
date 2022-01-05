using Dai19090.SimulationTechniques.Infrastructure;
using Dai19090.SimulationTechniques.Randomness;

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
    /// <typeparam name="TOptions">The type of <paramref name="options"/>.</typeparam>
    /// <param name="options">An argument that gets passed to <paramref name="initSimulation"/>.</param>
    /// <param name="initSimulation">A delegate that kicks off the simulation's work items.</param>
    /// <param name="random">The random number generator used by the simulation.</param>
    /// <returns>The simulation's registered <see cref="ISimulationInstrument"/>s.</returns>
    /// <remarks>
    /// </remarks>
    public static ISimulationInstrument[] Run<TOptions>(TOptions options, Action<ISimulationState, TOptions> initSimulation, IRandomNumberGenerator random)
    {
        var state = new SimulationState(random);
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

        return state.GetInstruments();
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
