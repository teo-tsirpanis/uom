using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Dai19090.SimulationTechniques.Infrastructure;

internal static class AsyncSimulationOpMethodBuilderShared
{
    [DebuggerStepThrough]
    public static void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine =>
        // It does some ExecutionContext trickery that can't be done from
        // public APIs. Let's just hope the method remains stateless.
        default(AsyncTaskMethodBuilder).Start(ref stateMachine);
}

public struct AsyncSimulationOpMethodBuilder<TResult>
{
    private sealed class AsyncStateMachineBox<TStateMachine> : SimulationOp<TResult>, ISimulationWorkItem where TStateMachine : IAsyncStateMachine
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
    private SimulationOp<TResult>? _op;

    private AsyncSimulationOpMethodBuilder(ISimulationState state) : this() => _state = state;

    internal static ISimulationWorkItem GetStateMachineBox<TStateMachine>(ref TStateMachine stateMachine, ref SimulationOp<TResult>? op) where TStateMachine : IAsyncStateMachine
    {
        var executionContext = ExecutionContext.Capture();
        switch (op)
        {
            case null:
                var newBox = new AsyncStateMachineBox<TStateMachine>();
                // important: this must be done before storing stateMachine into newBox.StateMachine!
                // Failure to do so will result in: losing more than two days from your life figuring
                // out that weird bug that manifests only in Release.
                // Let's see why it happens. The state machine contains a method builder, and the method
                // builder contains op. What we did before was assign the state machine inside the box,
                // and then assign op to the box. It worked well in Debug mode because the state machine
                // is a class, but in Release mode, the state machine is a struct, and if we assign op
                // at the end, it would update the state machine on the stack; not the state machine
                // in the box.
                // How to prevent it? Read the real source code and not ILSpy. The implementation was
                // copied from the BCL and contained the comment at the beginning of this. But ILSpy does
                // not contain comments so I didn't think much of it.
                op = newBox;
                newBox.StateMachine = stateMachine;
                newBox.Context = executionContext;
                return newBox;
            case AsyncStateMachineBox<TStateMachine> box:
                box.Context = executionContext;
                return box;
            default:
                ThrowHelpers.ThrowInvalidAsyncSimulationOpMethodBuilderUse();
                return null;
        }
    }

    public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ISimulationCompletion where TStateMachine : IAsyncStateMachine =>
        AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);

    public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ISimulationCompletion where TStateMachine : IAsyncStateMachine =>
        awaiter.UnsafeOnCompleted(_state, GetStateMachineBox(ref stateMachine, ref _op));

    public void SetException(Exception exception) => Task.SetException(exception);

    public void SetResult(TResult result)
    {
        if (_op is null)
            _op = SimulationOp.FromResult(result);
        else
            _op.SetResult(result);
    }

    public SimulationOp<TResult> Task => _op ??= new();

    public static AsyncSimulationOpMethodBuilder<TResult> Create() => new(Simulation.GetCurrentState());

    [DebuggerStepThrough]
    public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine =>
        AsyncSimulationOpMethodBuilderShared.Start(ref stateMachine);

    public void SetStateMachine(IAsyncStateMachine stateMachine)
    {
        if (stateMachine is null)
            throw new ArgumentNullException(nameof(stateMachine));
    }
}

internal struct VoidOpResult { }

public struct AsyncSimulationOpMethodBuilder
{
    private readonly ISimulationState _state;
    private SimulationOp<VoidOpResult>? _op;

    private AsyncSimulationOpMethodBuilder(ISimulationState state) : this() => _state = state;

    public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ISimulationCompletion where TStateMachine : IAsyncStateMachine =>
        AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);

    public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ISimulationCompletion where TStateMachine : IAsyncStateMachine =>
        awaiter.UnsafeOnCompleted(_state, AsyncSimulationOpMethodBuilder<VoidOpResult>.GetStateMachineBox(ref stateMachine, ref _op));

    public void SetException(Exception exception) => Task.SetException(exception);

    public void SetResult()
    {
        if (_op is null)
            _op = SimulationOp<VoidOpResult>.s_defaultResultOp;
        else
            _op.SetResult(default);
    }

    public SimulationOp Task => _op ??= new();

    [DebuggerNonUserCode]
    public static AsyncSimulationOpMethodBuilder Create() => new(Simulation.GetCurrentState());

    [DebuggerStepThrough]
    public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine =>
        AsyncSimulationOpMethodBuilderShared.Start(ref stateMachine);

    public void SetStateMachine(IAsyncStateMachine stateMachine)
    {
        if (stateMachine is null)
            throw new ArgumentNullException(nameof(stateMachine));
    }
}
