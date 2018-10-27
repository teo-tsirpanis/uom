package dai19090.oop1.tictactoe.core;

/**
 * Utilities to check whether a player has won.
 */
public class WinnerChecker {

    private static final int[][][] winningPositions =
            {
                    // Horizontal lines
                    {{0, 0}, {0, 1}, {0, 2}},
                    {{1, 0}, {1, 1}, {1, 2}},
                    {{2, 0}, {2, 1}, {2, 2}},
                    // Vertical lines
                    {{0, 0}, {1, 0}, {2, 0}},
                    {{0, 1}, {1, 1}, {2, 1}},
                    {{0, 2}, {1, 2}, {2, 2}},
                    // Diagonals
                    {{0, 0}, {1, 1}, {2, 2}},
                    {{0, 2}, {1, 1}, {2, 0}}
            };

    /**
     * Checks if any player has won in this board.
     * @param board The {@link BoardViewer} to check for the winner.
     * @return The {@link PlayerMark} who has won, or {@code null} if nobody has.
     */
    public static PlayerMark didAnybodyWon(BoardViewer board) {
        for (int[][] winPos : winningPositions) {
            PlayerMark[] positions = new PlayerMark[3];
            for (int i = 0; i < winPos.length; i++) {
                positions[i] = board.getCell(winPos[i][0], winPos[i][1]);
            }
            if (positions[0] == positions[1] && positions[1] == positions[2])
                return positions[0];
        }
        return null;
    }
}
