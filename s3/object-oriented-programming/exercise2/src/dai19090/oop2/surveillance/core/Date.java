package dai19090.oop2.surveillance.core;

/**
 * A very simple class that represents a calendar date.
 */
public final class Date {
    private final int day;
    private final int month;
    private final int year;

    public Date(int day, int month, int year) {
        this.day = day;
        this.month = month;
        this.year = year;
    }

    /**
     * @return The date's day of the month.
     */
    public int getDay() {
        return day;
    }

    /**
     * @return The date's month of the year.
     */
    public int getMonth() {
        return month;
    }

    /**
     * @return The date's year.
     */
    public int getYear() {
        return year;
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public String toString() {
        return String.format("%d-%d-%d", year, month, day);
    }
}
