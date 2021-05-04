using PegSolitaire.Game;

namespace PegSolitaire.Ai
{
    /// <summary>
    /// Gives heuristic scores to game <see cref="State"/>.
    /// </summary>
    /// <remarks>This class is thread-safe only if
    /// <see cref="GetHeuristic"/> is thread-safe.</remarks>
    public abstract class AbstractGameStateHeuristic
    {
        /// <summary>
        /// Calculates the heuristic for a game <see cref="State"/>.
        /// </summary>
        /// <param name="state">The prospective game state to evaluate.</param>
        /// <returns>A <see cref="float"/> representing the value of
        /// <paramref name="state"/>. States with lower heuristic value
        /// will be evaluated first.</returns>
        public abstract float GetHeuristic(State state);
    }
}
