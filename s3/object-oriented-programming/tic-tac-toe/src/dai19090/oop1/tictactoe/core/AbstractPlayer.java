package dai19090.oop1.tictactoe.core;

import java.util.ArrayList;

/**
 * An abstract type describing a tic-tac-toe player.
 */
public abstract class AbstractPlayer {
    /**
     * @return The player's corresponding {@link CellState}.
     */
    public abstract CellState getCellState();

    /**
     * Gets the best move out of a list of available ones.
     * @param positions The available moves, ie. the places on the board that have not yet been played.
     * @param boardViewer A read-only view of the playing board.
     * @return The index of the best move for the player to make.
     */
    public abstract int play(ArrayList<Position> positions, BoardViewer boardViewer);
}
