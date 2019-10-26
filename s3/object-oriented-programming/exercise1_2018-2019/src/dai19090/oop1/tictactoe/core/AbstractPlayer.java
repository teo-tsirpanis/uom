package dai19090.oop1.tictactoe.core;

import java.util.ArrayList;

/**
 * An abstract type describing a tic-tac-toe player.
 */
public abstract class AbstractPlayer {
    /**
     * Gets the best move out of a list of available ones.
     * @param positions The available moves, ie. the places on the board that have not yet been played.
     * @param boardViewer A read-only view of the playing board.
     * @param player The player that is playing now.
     * @return The best move for the player to make.
     */
    public abstract Position play(ArrayList<Position> positions, BoardViewer boardViewer, PlayerMark player);
}
