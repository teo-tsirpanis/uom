package dai19090.oop1.tictactoe.core;

/**
 * An abstract class for listening to game events.
 */
public abstract class AbstractEventListener {

    /**
     * An exception did occur during a player's turn.
     * @param player The player who caused the exception.
     * @param e The exception in question.
     * @return Whether to re-attempt trying to play, or keep the {@link Game}'s state unchanged.
     */
    public abstract Boolean exceptionDuringPlay(CellState player, Exception e);

    /**
     * A player has won.
     * @param player The winner.
     */
    public abstract void playerWon(CellState player);

    /**
     * The game ended in a draw.
     */
    public abstract void draw();
}
