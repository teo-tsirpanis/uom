package dai19090.oop1.hangman.core;

/**
 * An interface that reports the outcome of a game.
 * Only one of any methods must be called.
 * This interface is not public to prevent its abuse.
 */
interface IGameEventListener {
    /**
     * The game was won.
     */
    void won();

    /**
     * The game was lost.
     */
    void lost();
}
