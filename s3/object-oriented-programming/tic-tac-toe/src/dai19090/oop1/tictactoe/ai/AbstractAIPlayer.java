package dai19090.oop1.tictactoe.ai;

import dai19090.oop1.tictactoe.core.*;

import java.util.ArrayList;

/**
 * An abstract type describing a tic-tac-toe player controlled by an Artificial Intelligence.
 * Its differences from the {@link AbstractPlayer} are that the AI player accepts a special event
 * listener that notifies the application of his moves, and that the user must override the class' {@link AbstractAIPlayer#think} method.
 */
public abstract class AbstractAIPlayer extends AbstractPlayer {

    private final AbstractAIPlayerEventListener listener;

    /**
     * Creates an {@link AbstractAIPlayer} that broadcasts his moves to the given event {@link AbstractAIPlayerEventListener}.
     * @param listener The player's event listener.
     */
    public AbstractAIPlayer(AbstractAIPlayerEventListener listener) {
        this.listener = listener;
    }

    protected abstract Position think(ArrayList<Position> positions, BoardViewer boardViewer, PlayerMark player);

    @Override
    public Position play(ArrayList<Position> positions, BoardViewer boardViewer, PlayerMark player) {
        Position pos = think(positions, boardViewer, player);
        listener.movePlayed(pos, player);
        return pos;
    }
}
