package dai19090.oop1.tictactoe.cli;

import dai19090.oop1.tictactoe.core.*;

public class ConsoleEventListener extends AbstractEventListener {
    /**
     * An exception did occur during a player's turn.
     *
     * @param player The player who caused the exception.
     * @param e      The exception in question.
     * @return Whether to re-attempt trying to call the {@code play} method,
     * or exit, keeping the {@link Game}'s state unchanged.
     */
    @Override
    public Boolean exceptionDuringPlay(PlayerMark player, Exception e) {
        System.out.println("An error did happen during the turn of Player (" + player + "): " + e.toString());
        return true;
    }

    /**
     * A player has won.
     *
     * @param player The winner.
     */
    @Override
    public void playerWon(PlayerMark player) {
        System.out.println("Player " + player + " won!");
    }

    /**
     * The game ended in a draw.
     */
    @Override
    public void draw() {
        System.out.println("The game has ended in a draw.");
    }
}
