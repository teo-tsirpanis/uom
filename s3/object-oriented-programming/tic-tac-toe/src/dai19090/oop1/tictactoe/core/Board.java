package dai19090.oop1.tictactoe.core;

/**
 * A Tic-Tac-Toe playing board.
 */
public final class Board {
    private CellState[][] _board;

    public Board() {
        super();
        _board = new CellState[3][3];
        for (int i = 0; i < _board.length; i++) {
            for (int j = 0; j < _board[i].length; j++) {
                _board[i][j] = null;
            }
        }
    }

    private static int CheckAndFixBounds(int coord) throws IndexOutOfBoundsException {
        if (coord >= 1 && coord <= 3) return coord - 1;
        else throw new IndexOutOfBoundsException(coord);

    }

    public Board(Board b) {
        this();
        for (int i = 0; i < _board.length; i++) {
            for (int j = 0; j < _board[i].length; j++) {
                _board[i][j] = b._board[i][j];
            }
        }
    }

    /**
     * Sets the specified place at the board to the specified one.
     * @param x The row; the first is number 1.
     * @param y The column; the first is number 1.
     * @param state The state to set this cell.
     */
    void changeCell(int x, int y, CellState state) throws IndexOutOfBoundsException, CellAlreadySetException, NullPointerException {
        Board result = new Board(this);
        if (state == null) {
            throw new NullPointerException("state");
        }
        x = CheckAndFixBounds(x);
        y = CheckAndFixBounds(y);
        if (result._board[x][y] != null) {
            throw new CellAlreadySetException();
        }
        result._board[x][y] = state;
    }
}
