package dai19090.oop2.surveillance.core;

import java.util.Arrays;

/**
 * A communication that was performed via a text message.
 */
public final class SMS extends Communication {
    private static final String[] suspiciousWords = {
            "bomb",
            "attack",
            "explosives",
            "gun"
    };
    private final String text;

    public SMS(String origin, String destination, Date date, String text) {
        super(origin, destination, date);
        this.text = text;
    }

    public SMS(String origin, String destination, int day, int month, int year, String text) {
        this(origin, destination, new Date(year, month, day), text);
    }

    /**
     * @return The text of the message.
     */
    public String getText() {
        return text;
    }

    /**
     * @return Whether the message contains any suspicious words.
     */
    public boolean isSuspicious() {
        String text = this.text;
        return Arrays.stream(suspiciousWords).anyMatch(text::contains);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public String toString() {
        return "On " + getDate() + ", " + getOrigin() + " sent a text message to " +
                getDestination() + ", whose content is \"" + text + "\".";
    }
}
