using System.Collections.Immutable;
using System.Linq;
using PegSolitaire.Game;

namespace PegSolitaire.Ai
{
    /// <summary>
    /// Represents a snapshot of the solver's execution.
    /// </summary>
    public class SolverState
    {
        internal SolverState(State currentGameState, int totalNextStates, ImmutableStack<State> remainingNextStates,
            SolverState? parentState)
        {
            CurrentGameState = currentGameState;
            TotalNextStates = totalNextStates;
            RemainingNextStates = remainingNextStates;
            ParentState = parentState;
            CompletionPercentage =
                (ParentState?.CompletionPercentage ?? 1.0f) * (TotalNextStates - RemainingNextStates.Count()) /
                TotalNextStates;
        }

        /// <summary>
        /// The game <see cref="PegSolitaire.Game.State"/>
        /// the solver is currently evaluating.
        /// </summary>
        public State CurrentGameState { get; }

        /// <summary>
        /// The total number of states that can result from this one.
        /// </summary>
        public int TotalNextStates { get; }

        /// <summary>
        /// The prospective <see cref="PegSolitaire.Game.State"/>s the
        /// solver will take a look at next. They are sorted in descending order of value.
        /// </summary>
        public ImmutableStack<State> RemainingNextStates { get; }

        /// <summary>
        /// The solver's state before the move that led to this one was played.
        /// </summary>
        public SolverState? ParentState { get; }

        /// <summary>
        /// A floating-point value from 0 to 1 that approximates how much
        /// of the available game state space has been evaluated.
        /// </summary>
        public float CompletionPercentage { get; }

        internal SolverState PopNextGameState(out State nextState) =>
            new SolverState(CurrentGameState, TotalNextStates, RemainingNextStates.Pop(out nextState), ParentState);
    }
}
