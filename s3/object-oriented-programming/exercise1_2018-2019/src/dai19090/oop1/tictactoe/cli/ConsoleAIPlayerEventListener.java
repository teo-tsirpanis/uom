package dai19090.oop1.tictactoe.cli;

import dai19090.oop1.tictactoe.core.*;
import dai19090.oop1.tictactoe.ai.*;

public class ConsoleAIPlayerEventListener extends AbstractAIPlayerEventListener {
    @Override
    public void movePlayed(Position position, PlayerMark player) {
        System.out.println("Computer Move (" + player + "): " + position);
    }
}
