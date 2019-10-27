package dai19090.oop1.hangman.core;

/**
 * A class that creates {@link Game}s of Hangman.
 * It provides them with random word generation and win/loss record keeping.
 */
public final class GameManager {
    private final AbstractWordFactory wordFactory;
    private int gamesWon = 0;
    private int gamesLost = 0;

    /**
     * An implementation of {@link IGameEventListener} that
     * reports to a {@link GameManager}.
     */
    class GameEventListener implements IGameEventListener {
        public void won() {
            gamesWon++;
        }

        public void lost() {
            gamesLost++;
        }
    }

    /**
     * Creates a {@link GameManager}.
     * @param wordFactory The {@link AbstractWordFactory} object that
     *                    will generate the words for the new {@link Game}s.
     */
    public GameManager(AbstractWordFactory wordFactory) {
        this.wordFactory = wordFactory;
    }

    /**
     * Creates a {@link Game} with a random word that reports the outcome to this {@link GameManager}.
     * @return The created {@link Game}.
     */
    public Game createGame() {
        return new Game(wordFactory.getWord(), new GameEventListener());
    }

    /**
     * @return The number of {@link Game}s won.
     */
    public int getGamesWon() {
        return gamesWon;
    }

    /**
     * @return The number of {@link Game}s lost.
     */
    public int getGamesLost() {
        return gamesLost;
    }
}
