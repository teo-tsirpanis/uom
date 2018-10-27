package dai19090.oop1.tictactoe.core;

import java.util.ArrayList;

/**
 * A Tic-Tac-Toe playing board.
 */
public final class Board implements BoardViewer {
    private static final int[][][] winningPositions =
            {
                    {{0, 0}, {0, 1}, {0, 2}},
                    {{1, 0}, {1, 1}, {1, 2}},
                    {{2, 0}, {2, 1}, {2, 2}},
                    {{0, 0}, {1, 0}, {2, 0}},
                    {{0, 1}, {1, 1}, {2, 1}},
                    {{0, 2}, {1, 2}, {2, 2}},
                    {{0, 0}, {1, 1}, {2, 2}},
                    {{0, 2}, {1, 1}, {2, 0}}
            };

    private final CellState[][] _board;

    /**
     * Creates an empty {@link Board}.
     */
    public Board() {
        super();
        _board = new CellState[3][3];
        for (int i = 0; i < _board.length; i++) {
            for (int j = 0; j < _board[i].length; j++) {
                _board[i][j] = null;
            }
        }
    }

    /**
     * Creates a {@link Board} from another one.
     *
     * @param b The {@link Board} to copy.
     * @return The new {@link Board}.
     */
    @SuppressWarnings("CopyConstructorMissesField")
    public Board(Board b) {
        this();
        for (int i = 0; i < _board.length; i++)
            if (_board[i].length >= 0)
                System.arraycopy(b._board[i], 0, _board[i], 0, _board[i].length);
    }

    @Override
    public CellState getCell(Position position) {
        return _board[position.getRowIndex()][position.getColumnIndex()];
    }

    /**
     * Sets the specified place at the board to the specified one.
     *
     * @param position The {@link Position} of the board to change.
     * @param state    The {@link CellState} to set this cell.
     * @throws CellAlreadySetException The cell in the given position is already set.
     * @throws NullPointerException    {@code state} is {@code null}.
     */
    void setCell(Position position, CellState state) {
        Board result = new Board(this);
        if (state == null) throw new NullPointerException("state");
        if (getCell(position) != null) throw new CellAlreadySetException(position);
        result._board[position.getRowIndex()][position.getColumnIndex()] = state;
    }

    CellState tryGetWinner() {
        for (int[][] winPos: winningPositions) {
            CellState[] positions = new CellState[3];
            for (int i = 0; i < winPos.length; i++) {
                positions[i] = _board[winPos[i][0]][winPos[i][1]];
            }
            if (positions[0] == positions[1] && positions[1] == positions[2])
                return positions[0];
        }
        return null;
    }

    ArrayList<Position> getAvailablePositions() {
        ArrayList<Position> positions = new ArrayList<>(9);
        for (int i = 0; i < _board.length; i++) {
            for (int j = 0; j < _board[i].length; j++) {
                if (_board[i][j] == null)
                    positions.add(new Position(i + 1, j + 1));
            }
        }
        return positions;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder((9 + 1) * 4);
        // The board's string representation has exactly this number of characters. The extra number character per
        // row is for the newline, which is one LF, even on the CRLF-laden Windows.
        sb.append("   A B C \n");
        for (int i = 0; i < _board.length; i++) {
            sb.append(i + 1);
            sb.append(" |");
            for (int j = 0; j < _board[i].length; j++) sb.append(CellState.format(_board[i][j]));
            sb.append("|'n");
        }
        return sb.toString();
    }
}
