package dai19090.oop1.tictactoe.core;

/**
 * Thrown to indicate an invalid column character (ie. not {@code A}, {@code B}, or {@code C}.
 */
public class InvalidColumnCharacterException extends TicTacToeException {

    private final char offendingChar;

    InvalidColumnCharacterException(char x) {
        super();
        offendingChar = x;
    }

    /**
     * Gets the wrong column character.
     * @return The wrong column character.
     */
    public char getOffendingChar() {
        return offendingChar;
    }

    @Override
    public String toString() {
        return "Invalid column character: \'" + getOffendingChar() + "\'. Valid column characters are \'A\', \'B\', and \'C\'.";
    }
}
