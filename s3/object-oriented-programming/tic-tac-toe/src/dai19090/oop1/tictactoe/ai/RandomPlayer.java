package dai19090.oop1.tictactoe.ai;

import dai19090.oop1.tictactoe.core.*;

import java.util.ArrayList;
import java.util.Random;

/**
 * A player that plays randomly.
 */
public class RandomPlayer extends AbstractAIPlayer {

    private final Random rng = new Random();

    /**
     * {@inheritDoc}
     */
    public RandomPlayer(AbstractAIPlayerEventListener listener) {
        super(listener);
    }

    @Override
    public Position think(ArrayList<Position> positions, BoardViewer boardViewer, PlayerMark player) {
        return positions.get(rng.nextInt(positions.size()));
    }
}
