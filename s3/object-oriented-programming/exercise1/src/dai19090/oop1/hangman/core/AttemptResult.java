package dai19090.oop1.hangman.core;

/**
 * The result of an invocation of {@link Game#attempt}.
 */
public enum AttemptResult {
    /**
     * The attempt was successful. The character was added to the word.
     */
    CORRECT_ANSWER,
    /**
     * The attempt was unsuccessful. The character does not exist at the word.
     */
    INCORRECT_ANSWER,
    /**
     * The game has finished; further attempts are not allowed.
     */
    CANNOT_PLAY_ANYMORE,
    /**
     * The character was already submitted.
     */
    ALREADY_SUBMITTED
}
