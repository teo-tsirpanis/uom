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
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (!(o instanceof Position)) {
            return false;
        }
        Position pos2 = (Position) o;
        return this.rowIndex == pos2.rowIndex && this.columnIndex == pos2.columnIndex;
    }

    @Override
    public int hashCode() {
        return (this.rowIndex << 2) + (this.rowIndex); // These two numbers don't take more than 2 bits.
    }

    @Override
    public String toString() {
        String col = "";
        switch (getRow()) {
            case 1: col = "A"; break;
            case 2: col = "B"; break;
            case 3: col = "C"; break;
        }
        return col + getRow();
    }
}
