package dai19090.oop1.tictactoe.cli;

import dai19090.oop1.tictactoe.core.*;

/**
 * An {@link AbstractEventListener} that prints its events to the console.
 */
public class ConsoleEventListener extends AbstractEventListener {

    @Override
    public Boolean exceptionDuringPlay(PlayerMark player, Exception e) {
        System.out.println("An error did happen during the turn of Player " + player + ": " + e.toString());
        return true;
    }

    @Override
    public void playerWon(PlayerMark player) {
        if (player == PlayerMark.X)
            System.out.println("You win!");
        else
            System.out.println("You lost... :-(");
    }

    @Override
    public void draw() {
        System.out.println("The game has ended in a draw.");
    }
}
