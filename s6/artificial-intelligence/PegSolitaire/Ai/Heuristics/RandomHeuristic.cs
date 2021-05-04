using System;
using PegSolitaire.Game;

namespace PegSolitaire.Ai.Heuristics
{
    /// <summary>
    /// Assigns a random heuristic value to each <see cref="State"/>.
    /// This class is not thread-safe.
    /// </summary>
    /// <remarks>In essence this heuristic makes the <see cref="Solver"/>'s
    /// best-first search algorithm a depth-first one.</remarks>
    public class RandomHeuristic : AbstractGameStateHeuristic
    {
        private readonly Random _rng = new Random();

        /// <inheritdoc/>
        public override float GetHeuristic(State state) => (float) _rng.NextDouble();
    }
}
