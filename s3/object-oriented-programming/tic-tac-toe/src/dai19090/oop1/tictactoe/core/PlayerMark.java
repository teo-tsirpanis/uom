package dai19090.oop1.tictactoe.core;

/**
 * The mark of a Tic-Tac-Toe cell.
 */
public enum PlayerMark {
    /**
     * Marked by Player X.
     */
    X,
    /**
     * Marked by Player O.
     */
    O;

    public static char format(PlayerMark state) {
        if (state != null)
            switch (state) {
                case X:
                    return 'X';
                case O:
                    return 'O';
            }
        return ' ';
    }
}
