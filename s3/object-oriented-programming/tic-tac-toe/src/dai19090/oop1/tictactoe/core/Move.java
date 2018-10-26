package dai19090.oop1.tictactoe.core;

/**
 * A tic-tac-toe move.
 * It is made of a {@link CellState} signifying the player that is going to play it,
 * and the {@link Position} it is going to be played.
 */
public final class Move {
    private final CellState cellState;
    private final Position position;

    /**
     * @return The move's corresponding {@link CellState}.
     */
    public CellState getCellState() {
        return cellState;
    }
    /**
     * @return The move's corresponding {@link Position}.
     */
    public Position getPosition() {
        return position;
    }

    Move(CellState cellState, Position position) {
        this.cellState = cellState;
        this.position = position;
    }
}
