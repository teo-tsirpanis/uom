using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Dai19090.SimulationTechniques.Infrastructure;

public struct AsyncSimulationOpMethodBuilder
{
    private sealed class AsyncStateMachineBox<TStateMachine> : SimulationOp, ISimulationWorkItem where TStateMachine : IAsyncStateMachine
    {
        public TStateMachine? StateMachine;
        public ExecutionContext? Context;

        public void Run()
        {
            if (Context is null)
            {
                Debug.Assert(StateMachine is not null);
                StateMachine.MoveNext();
            }
            else
            {
                ExecutionContext.Run(Context, static x =>
                {
                    ((AsyncStateMachineBox<TStateMachine>)x!).StateMachine!.MoveNext();
                }, this);
            }

            if (IsCompleted)
            {
                StateMachine = default;
                Context = null;
            }
        }
    }

    private readonly ISimulationState _state;
    private SimulationOp? _op;

    private AsyncSimulationOpMethodBuilder(ISimulationState state) : this()
    {
        _state = state;
    }

    private ISimulationWorkItem GetStateMachineBox<TStateMachine>(ref TStateMachine stateMachine, ref SimulationOp? op) where TStateMachine : IAsyncStateMachine
    {
        var executionContext = ExecutionContext.Capture();
        switch (op)
        {
            case null:
                var newBox = new AsyncStateMachineBox<TStateMachine>()
                {
                    StateMachine = stateMachine,
                    Context = executionContext
                };
                op = newBox;
                return newBox;
            case AsyncStateMachineBox<TStateMachine> box:
                box.Context = executionContext;
                return box;
            default:
                ThrowHelpers.ThrowInvalidAsyncSimulationOpMethodBuilderUse();
                return null;
        }
    }

    public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ISimulationCompletion where TStateMachine : IAsyncStateMachine
    {
        AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
    }

    public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ISimulationCompletion where TStateMachine : IAsyncStateMachine
    {
        awaiter.UnsafeOnCompleted(_state, GetStateMachineBox(ref stateMachine, ref _op));
    }

    public void SetException(Exception exception)
    {
        Task.SetException(exception);
    }

    public void SetResult()
    {
        if (_op is null)
            _op = SimulationOp.Completed;
        else
            _op.SetResult();
    }

    public SimulationOp Task => _op ?? new();

    public static AsyncSimulationOpMethodBuilder Create()
    {
        var state = Simulation.GetCurrentState();
        return new(state);
    }

    public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
    {
        // It does some ExecutionContext trickery that can't be done from
        // public APIs. Let's just hope the method remains stateless.
        default(AsyncTaskMethodBuilder).Start(ref stateMachine);
    }

    public void SetStateMachine(IAsyncStateMachine stateMachine)
    {
        if (stateMachine is null)
            throw new ArgumentNullException(nameof(stateMachine));
    }
}
