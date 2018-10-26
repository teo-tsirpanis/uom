package dai19090.oop1.tictactoe.core;

/**
 * An interface providing read-only access to a tic-tac-toe playing board.
 */
public interface BoardViewer {
    /**
     * Gets the specified state of the cell at the given position.
     *
     * @param position The {@link Position} we are asking about.
     * @return The {@link CellState} at {@code position}, or null if it is not yet set.
     */
    CellState getCell(Position position);
}
