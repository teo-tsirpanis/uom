package dai19090.oop1.tictactoe.cli;

import dai19090.oop1.tictactoe.ai.*;
import dai19090.oop1.tictactoe.core.*;

/**
 * The program's entry point.
 */
public class Program {

    public static void main(String[] args) {
        System.out.println("************\nTic-Tac-Toe!\n************");
        System.out.println("\nPlease enter the column (A, B or C) and then the row (1, 2, or 3) of your move.");

        AbstractEventListener listener = new ConsoleEventListener();
        Game game = new Game(new HumanPlayer(), new RandomPlayer(new ConsoleAIPlayerEventListener()));

        do {
            System.out.println();
            System.out.println(game.viewBoard().toString());
        } while (game.stepGame(listener));
    }
}
