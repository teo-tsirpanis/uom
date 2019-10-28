package dai19090.oop1.hangman.core;

import java.util.HashSet;

/**
 * A game of Hangman. It can be associated with a {@link GameManager}.
 */
public final class Game {
    private static final int DEFAULT_ATTEMPTS = 8;
    private final String trueWord;
    private final IGameEventListener eventListener;
    private final HashSet<Character> charactersTried = new HashSet<>(26);
    private final int distinctCharacters;
    private int guessesLeft;
    private int successfulGuesses = 0;
    private int failedGuesses = 0;

    /**
     * Creates a {@link Game}. This constructor is intended for internal use only.
     * Consumers should use {@link GameManager#createGame()} instead.
     * @param trueWord The word the player has to guess.
     * @param eventListener The {@link IGameEventListener} to report the outcome to.
     */
    Game(String trueWord, IGameEventListener eventListener) {
        this.trueWord = trueWord.toUpperCase();
        this.eventListener = eventListener;
        this.distinctCharacters = Utilities.getDistinctCharacters(this.trueWord);
        // Giving eight attempts for a word with nine distinct characters is futile.
        this.guessesLeft = distinctCharacters > DEFAULT_ATTEMPTS ? distinctCharacters + 5 : DEFAULT_ATTEMPTS;
    }

    /**
     * Makes an attempt to guess a character in the word.
     * @param c The character to test against.
     * @return An object of type {@link AttemptResult}.
     */
    public AttemptResult attempt(char c) {
        c = Character.toUpperCase(c);
        if (isWon() || isLost())
            return AttemptResult.CANNOT_PLAY_ANYMORE;
        else if (!charactersTried.add(c))
            return AttemptResult.ALREADY_SUBMITTED;
        else if (trueWord.indexOf(c) != -1) {
            guessesLeft--;
            successfulGuesses++;
            if (isWon() && eventListener != null)
                eventListener.won();
            return AttemptResult.CORRECT_ANSWER;
        }
        else {
            guessesLeft--;
            failedGuesses++;
            if (isLost() && eventListener != null)
                eventListener.lost();
            return AttemptResult.INCORRECT_ANSWER;
        }
    }

    /**
     * @return How many {@link Game#attempt}s the player can do before he loses.
     */
    public int getGuessesLeft() {
        return guessesLeft;
    }

    /**
     * @return How many successful guesses the player has done.
     */
    public int getSuccessfulGuesses() {
        return successfulGuesses;
    }

    /**
     * @return How many unsuccessful guesses the player has done.
     */
    public int getFailedGuesses() {
        return failedGuesses;
    }

    /**
     * @return Whether the game is won. More {@link Game#attempt}s cannot be done after that.
     */
    public boolean isWon() {
        return successfulGuesses == distinctCharacters;
    }

    /**
     * @return Whether the game is lost. More {@link Game#attempt}s cannot be done after that.
     */
    public boolean isLost() {
        return guessesLeft == 0;
    }

    /**
     * @return The word to find, but with the undiscovered characters obscured.
     */
    public String getWord() {
        StringBuilder sb = new StringBuilder(trueWord.length());
        for (int i = 0; i < trueWord.length(); i++)
            if (charactersTried.contains(trueWord.charAt(i)))
                sb.append(trueWord.charAt(i));
            else
                sb.append('-');
        return sb.toString();
    }
}
