namespace Dai19090.SimulationTechniques.Infrastructure;

public readonly struct DelayAwaitable
{
    public readonly struct DelayAwaiter : ISimulationCompletion
    {
        private readonly int _delay;

        internal DelayAwaiter(int delay)
        {
            _delay = delay;
        }

        public bool IsCompleted => _delay <= 0;

        public void UnsafeOnCompleted(ISimulationState state, ISimulationWorkItem workItem)
        {
            state.UnsafeQueueWorkItemLater(workItem, _delay);
        }

        public void GetResult()
        {
        }
    }

    private readonly int _delay;

    internal DelayAwaitable(int delay)
    {
        _delay = delay;
    }

    public DelayAwaiter GetAwaiter() => new(_delay);
}
