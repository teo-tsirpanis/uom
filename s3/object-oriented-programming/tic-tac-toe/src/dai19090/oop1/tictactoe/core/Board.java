package dai19090.oop1.tictactoe.core;

import java.util.ArrayList;

/**
 * A Tic-Tac-Toe playing board.
 */
final class Board implements BoardViewer {

    private final PlayerMark[][] _board;

    /**
     * Creates an empty {@link Board}.
     */
    Board() {
        super();
        _board = new PlayerMark[3][3];
        for (int i = 0; i < _board.length; i++) {
            for (int j = 0; j < _board[i].length; j++) {
                _board[i][j] = null;
            }
        }
    }

    @Override
    public PlayerMark getCell(Position position) {
        return _board[position.getRowIndex()][position.getColumnIndex()];
    }

    /**
     * Sets the specified place at the board to the specified one.
     *
     * @param position The {@link Position} of the board to change.
     * @param state    The {@link PlayerMark} to set this cell.
     * @throws CellAlreadySetException The cell in the given position is already set.
     * @throws NullPointerException    {@code state} is {@code null}.
     */
    void setCell(Position position, PlayerMark state) {
        if (state == null) throw new NullPointerException("state");
        if (getCell(position) != null) throw new CellAlreadySetException(position);
        _board[position.getRowIndex()][position.getColumnIndex()] = state;
    }

    @Override
    public ArrayList<Position> getAvailablePositions() {
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
            for (int j = 0; j < _board[i].length; j++) {
                sb.append(PlayerMark.format(_board[i][j]));
                sb.append("|");
            }
            sb.append("\n");
        }
        return sb.toString();
    }
}
