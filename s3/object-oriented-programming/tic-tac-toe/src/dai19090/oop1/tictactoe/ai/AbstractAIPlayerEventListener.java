package dai19090.oop1.tictactoe.ai;

import dai19090.oop1.tictactoe.core.*;

/**
 * An abstract class for listening to the moves of an {@link AbstractAIPlayer}.
 */
public abstract class AbstractAIPlayerEventListener {
    /**
     * A move was played by an {@link AbstractAIPlayer}.
     * @param position The move's position.
     * @param player The player who played that move.
     */
    public abstract void movePlayed(Position position, PlayerMark player);
}
