package dai19090.oop2.surveillance.core;

/**
 * A communication that was performed via a phone call.
 */
public final class PhoneCall extends Communication {

    private final int duration;

    public PhoneCall(String origin, String destination, Date date, int duration) {
        super(origin, destination, date);
        this.duration = duration;
    }

    public PhoneCall(String origin, String destination, int day, int month, int year, int duration) {
        this(origin, destination, new Date(year, month, day), duration);
    }

    /**
     * @return The duration of the phone call.
     */
    public int getDuration() {
        return duration;
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public String toString() {
        return "On " + getDate() + ", " + getOrigin() + " phoned " +
                getDestination() + ", and were talking for " + duration + " seconds.";
    }
}
