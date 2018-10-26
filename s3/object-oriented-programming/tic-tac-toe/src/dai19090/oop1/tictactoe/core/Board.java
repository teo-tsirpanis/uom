package dai19090.oop1.tictactoe.core;

/**
 * A Tic-Tac-Toe playing board.
 */
public final class Board implements BoardViewer {
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
