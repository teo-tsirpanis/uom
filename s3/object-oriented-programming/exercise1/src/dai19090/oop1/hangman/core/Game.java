package dai19090.oop1.hangman.core;

import java.util.HashSet;

/**
 * A game of Hangman. It can be associated with a {@link GameManager}.
 */
public final class Game {
    private final String trueWord;
    private final IGameEventListener eventListener;
    private final HashSet<Character> charactersTried = new HashSet<>(26);
    private final int distinctCharacters;
    private int guessesLeft = 5;
    private int successfulGuesses = 0;

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
            successfulGuesses++;
            if (isWon() && eventListener != null)
                eventListener.won();
            return AttemptResult.CORRECT_ANSWER;
        }
        else {
            guessesLeft--;
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
        if (isWon() || isLost())
            return trueWord;
        StringBuilder sb = new StringBuilder(trueWord.length());
        for (int i = 0; i < trueWord.length(); i++)
            if (charactersTried.contains(trueWord.charAt(i)))
                sb.append(trueWord.charAt(i));
            else
                sb.append('-');
        return sb.toString();
    }
}
