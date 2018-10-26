package dai19090.oop1.tictactoe.core;

/**
 * A Tic-Tac-Toe playing board.
 */
public final class Board {
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
    public Board(Board b) {
        this();
        for (int i = 0; i < _board.length; i++) {
            if (_board[i].length >= 0)
                System.arraycopy(b._board[i], 0, _board[i], 0, _board[i].length);
        }
    }

    /**
     * Gets the specified state of the cell at the given position.
     *
     * @param position The {@link Position} we are asking about.
     * @return The {@link CellState} at {@code position}, or null if it is not yet set.
     */
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
    void setCell(Position position, CellState state) throws CellAlreadySetException {
        Board result = new Board(this);
        if (state == null) {
            throw new NullPointerException("state");
        }
        if (getCell(position) != null) {
            throw new CellAlreadySetException();
        }
        result._board[position.getRowIndex()][position.getColumnIndex()] = state;
    }
}
