package dai19090.oop2.surveillance.core;

/**
 * A communication that was performed via a text message.
 */
public final class SMS extends Communication {
    private final String text;

    public SMS(String origin, String destination, Date date, String text) {
        super(origin, destination, date);
        this.text = text;
    }

    public SMS(String origin, String destination, int year, int month, int day, String text) {
        this(origin, destination, new Date(year, month, day), text);
    }

    /**
     * @return The text of the message.
     */
    public final String getText() {
        return text;
    }

    @Override
    public String toString() {
        return "On " + getDate() + ", " + getOrigin() + " sent a text message to " +
                getDestination() + ", whose content is \"" + text + "\".";
    }
}
