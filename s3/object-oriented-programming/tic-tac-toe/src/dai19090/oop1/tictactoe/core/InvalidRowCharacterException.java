package dai19090.oop1.tictactoe.core;

/**
 * Invalid row character (ie. not {@code 1}, {@code 2}, or {@code 3}.
 */
public class InvalidRowCharacterException extends TicTacToeException {

    private final char offendingChar;

    public InvalidRowCharacterException(char x) {
        super();
        offendingChar = x;
    }

    /**
     * Gets the wrong row character.
     * @return The wrong row character.
     */
    public char getOffendingChar() {
        return offendingChar;
    }

    @Override
    public String toString() {
        return "Invalid row character: \'" + offendingChar + "\'. Valid row characters are \'1\', \'2\', and \'3\'.";
    }
}