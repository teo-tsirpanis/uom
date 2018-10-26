package dai19090.oop1.tictactoe.core;

public final class Position {
    private final int rowIndex;
    private final int columnIndex;

    private static int CheckAndFixBounds(int coordinate) {
        if (coordinate >= 1 && coordinate <= 3) return coordinate - 1;
        else throw new IndexOutOfBoundsException(Integer.toString(coordinate));
    }

    /**
     * Creates a {@link Position} from the given coordinates (from 1 to 3, starting from the left and the top).
     * @param row The row.
     * @param column The column
     * @throws IndexOutOfBoundsException The row or the column are outside the allowed range.
     */
    public Position(int row, int column) {
        this.rowIndex = CheckAndFixBounds(row);
        this.columnIndex = CheckAndFixBounds(column);
    }

    /**
     * Creates a {@link Position} from the given textually encoded coordinates.
     * @param positionCode The coordinates in the form of ([ABC][123]), where the letters signify the column
     *                     (left-to-right), and the number signify the row (top-to-bottom).
     * @throws InvalidColumnCharacterException The column letter is invalid.
     * @throws InvalidRowCharacterException The row number is invalid.
     * @throws PositionLengthMismatchException The position code is not two characters long.
     */
    public Position(String positionCode) {
        if (positionCode.length() == 2) {
            switch (positionCode.charAt(0)) {
                case 'A':
                    columnIndex = 0;
                    break;
                case 'B':
                    columnIndex = 1;
                    break;
                case 'C':
                    columnIndex = 2;
                    break;
                default:
                    throw new InvalidColumnCharacterException(positionCode.charAt(0));
            }
            try {
                this.rowIndex = CheckAndFixBounds(Integer.parseInt(positionCode.substring(1)));
            } catch (NumberFormatException e) {
                //noinspection UnnecessaryLocalVariable
                InvalidRowCharacterException up = new InvalidRowCharacterException(positionCode.charAt(1));
                throw up;
            }
        } else
            throw new PositionLengthMismatchException(positionCode.length());
    }

    int getRowIndex() {
        return rowIndex;
    }

    int getColumnIndex() {
        return columnIndex;
    }

    /**
     * @return The position's row (from 1 to 3).
     */
    public int getRow() {
        return rowIndex + 1;
    }

    /**
     * @return The position's column (from 1 to 3).
     */
    public int getColumn() {
        return columnIndex + 1;
    }

    @Override
    public String toString() {
        return "Row: " + getRow() + " Column: " + getColumn();
    }
}
