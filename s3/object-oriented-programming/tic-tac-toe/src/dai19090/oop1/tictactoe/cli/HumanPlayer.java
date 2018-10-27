package dai19090.oop1.tictactoe.cli;

import dai19090.oop1.tictactoe.core.*;

import java.util.ArrayList;
import java.util.Scanner;

/**
 * A human player that plays the game from the console.
 */
public class HumanPlayer extends AbstractPlayer {

    private static final Scanner in = new Scanner(System.in);

    /**
     * Asks the user for a move.
     */
    @Override
    public int play(ArrayList<Position> positions, BoardViewer boardViewer, PlayerMark player) {
        System.out.print("Player Move (" + player + "): ");
        Position pos = new Position(in.next());
        // The core library covers for us in case of an invalid pattern.
        return positions.indexOf(pos);
    }
}
