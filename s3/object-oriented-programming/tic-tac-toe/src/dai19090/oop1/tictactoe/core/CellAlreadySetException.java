package dai19090.oop1.tictactoe.core;

/**
 * Thrown when a cell that was already set is tried to be set again.
 */
public class CellAlreadySetException extends TicTacToeException {
    private final Position position;

    CellAlreadySetException(Position pos) {
        position = pos;
    }

    public Position getPosition() {
        return position;
    }

    @Override
    public String toString() {
        return "Cell at " + getPosition() + " is already set.";
    }
}
