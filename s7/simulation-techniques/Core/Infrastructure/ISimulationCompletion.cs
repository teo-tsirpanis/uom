using System.Runtime.CompilerServices;

namespace Dai19090.SimulationTechniques.Infrastructure;

public interface ISimulationCompletion : ICriticalNotifyCompletion
{
    void INotifyCompletion.OnCompleted(Action continuation)
    {
        ThrowHelpers.ThrowCannotAwaitOutsideSimulation(GetType());
    }

    void ICriticalNotifyCompletion.UnsafeOnCompleted(Action continuation)
    {
        ThrowHelpers.ThrowCannotAwaitOutsideSimulation(GetType());
    }

    void UnsafeOnCompleted(ISimulationState state, ISimulationWorkItem workItem);
}
