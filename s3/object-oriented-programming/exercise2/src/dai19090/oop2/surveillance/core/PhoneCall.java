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

	/**
	 * @return The duration of the phone call.
	 */
	public int getDuration() {
		return duration;
	}
	
	@Override
	public String toString() {
		return "On " + getDate() + ", " + getOrigin() + " phoned " +
				getDestination() + ", and were talking for " + duration + " seconds.";
	}
}
