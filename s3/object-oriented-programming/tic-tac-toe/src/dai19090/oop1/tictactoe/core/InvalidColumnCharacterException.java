package dai19090.oop1.tictactoe.core;

public class InvalidColumnCharacterException extends TicTacToeException {

    private final char offendingChar;

    public InvalidColumnCharacterException(char x) {
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
        return "Invalid column character: \'" + offendingChar + "\'. Valid column characters are \'A\', \'B\', and \'C\'.";
    }
}
