package dai19090.oop1.tictactoe.core;

/**
 * Invalid board position length.
 */
public class PositionLengthMismatchException extends TicTacToeException {
    private final int index;

    PositionLengthMismatchException(int idx) {
        index = idx;
    }

    @Override
    public String toString() {
        return "Invalid board position length: Expecting 2 characters, but got " + index + ".";
    }
}
