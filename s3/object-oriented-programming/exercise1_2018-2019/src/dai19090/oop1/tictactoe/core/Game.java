package dai19090.oop1.tictactoe.core;

import java.util.ArrayList;

/**
 * A game of tic-tac-toe.
 */
public class Game {
    private final Board board = new Board();
    private final AbstractPlayer playerX, playerO;
    private PlayerMark currentPlayer = PlayerMark.X;

    /**
     * Creates a {@link Game} of two specified {@link AbstractPlayer}s.
     * @param playerX The player of "X" that also plays first.
     * @param playerO The player of "O".
     */
    public Game(AbstractPlayer playerX, AbstractPlayer playerO) {
        this.playerX = playerX;
        this.playerO = playerO;
    }

    private AbstractPlayer getCurrentPlayer() {
        if (currentPlayer == PlayerMark.X) return playerX;
        return playerO;
    }

    /**
     * @return A {@link BoardViewer} of the current playing board.
     */
    public BoardViewer viewBoard() {
        return board;
    }

    /**
     * Performs a move of the game. The {@link AbstractPlayer} who is playing,
     * is given a list of available moves and chooses the best one.
     * Console applications should just call this method until it returns {@code false}.
     * GUI applications should first check for the status of the board, ask the user for
     * his next move, and then call this method when it is ready to be given.
     * @param listener An {@link AbstractEventListener} to respond to game events.
     * @return Whether to continue calling this method.
     *         {@code false} if the game has ended, {@code true} otherwise.
     */
    public boolean stepGame(AbstractEventListener listener) {
        // First check if the game is won.
        PlayerMark winnerMaybe = WinnerChecker.didAnybodyWon(board);
        if (winnerMaybe != null) {
            listener.playerWon(winnerMaybe);
            return false;
        }
        // Then check if it is a draw.
        ArrayList<Position> availablePositions = board.getAvailablePositions();
        if (availablePositions.isEmpty()) {
            listener.draw();
            return false;
        }
        Position positionToPlay = null;
        // Try to get a next move from the player.
        while (positionToPlay == null) try {
            positionToPlay = getCurrentPlayer().play(availablePositions, viewBoard(), currentPlayer);
        } catch (Exception e) {
            if (!listener.exceptionDuringPlay(currentPlayer, e))
                // For console applications that have a linear lifetime, the play method would ask the
                // human player for the next move from a console window, and if it is invalid, it would ask him again.
                // For GUI applications however, where they don't operate inside a loop, if a player has played
                // an invalid move, we should exit this procedure and do not try to "play" again.
                // Instead, the GUI should call this method again when the user has given a new move.
                return true;
        }
        try {
            board.setCell(positionToPlay, currentPlayer);
            switch (currentPlayer) {
                case X:
                    currentPlayer = PlayerMark.O;
                    break;
                case O:
                    currentPlayer = PlayerMark.X;
                    break;
            }
        } catch (Exception e) {
            // If the board refuses to place this mark, then it is sure it would fail again.
            // We exit the method, and wait it to be called again.
            listener.exceptionDuringPlay(currentPlayer, e);
        }
        return true;
    }
}
