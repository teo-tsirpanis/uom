package dai19090.oop1.hangman.core;

/**
 * A class that reports the outcome of a game to the {@link GameManager}.
 * Only one of any methods must be called.
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
