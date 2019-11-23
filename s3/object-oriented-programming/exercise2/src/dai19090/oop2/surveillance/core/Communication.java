package dai19090.oop2.surveillance.core;

/**
 * A communication between two people that took place at a given {@link Date}.
 */
public abstract class Communication {
    private final String origin;
    private final String destination;
    // The exercise's statement asked for three separate fields,
    // but a dedicated date type is a much better design.
    private final Date date;

    public Communication(String origin, String destination, Date date) {
        this.origin = origin;
        this.destination = destination;
        this.date = date;
    }

    /**
     * @return The origin of the communication.
     */
    public final String getOrigin() {
        return origin;
    }

    /**
     * @return The destination of the communication.
     */
    public final String getDestination() {
        return destination;
    }

    /**
     * @return The {@link Date} the communication did take place.
     */
    public final Date getDate() {
        return date;
    }

    /**
     * Prints human-readable information about the communication to the console.
     */
    public final void printInfo() {
        // Descendant classes must override toString().
        System.out.println(this);
    }

    /**
     * Checks whether a particular phone number was involved in the communication.
     *
     * @param number The number in question.
     * @return {@code true}, if {@code number} was either the caller or the callee
     * of this communication, and {@code false} otherwise.
     */
    public final boolean involves(String number) {
        return origin.equals(number) || destination.equals(number);
    }

    /**
     * Checks whether two phone numbers communicated in this communication.
     *
     * @param number1 The first number.
     * @param number2 The second number.
     * @return {@code true} if the first number called the second number
     * or the opposite, and {@code false} otherwise.
     */
    public final boolean involves(String number1, String number2) {
        return involves(number1) && involves(number2);
    }

    /**
     * Checks whether a particular {@link Suspect} was involved in the communication.
     *
     * @param suspect The {@link Suspect} in question.
     * @return {@code true}, if {@code suspect} was either the caller or the callee
     * of this communication, and {@code false} otherwise.
     */
    public final boolean involves(Suspect suspect) {
        return suspect.getNumbersUsed().anyMatch(this::involves);
    }

    /**
     * Checks whether two {@link Suspect}s communicated in this communication.
     *
     * @param suspect1 The first number.
     * @param suspect2 The second number.
     * @return {@code true} if the first {@link Suspect} called the second
     * {@link Suspect} or the opposite, and {@code false} otherwise.
     */
    public final boolean involves(Suspect suspect1, Suspect suspect2) {
        return involves(suspect1) && involves(suspect2);
    }
}
