package dai19090.oop1.tictactoe.core;

import java.util.ArrayList;

/**
 * An interface providing read-only access to a tic-tac-toe playing board.
 */
public interface BoardViewer {
    /**
     * Gets the {@link PlayerMark} at the given position.
     *
     * @param position The {@link Position} we are asking about.
     * @return The {@link PlayerMark} at {@code position}, or null if it is not yet set.
     */
    PlayerMark getCell(Position position);

    default PlayerMark getCell(int row, int column) {
        return getCell(new Position(row + 1, column + 1));
    }

    /**
     * @return An {@link ArrayList} of the unclaimed positions in the board.
     */
    ArrayList<Position> getAvailablePositions();
}
