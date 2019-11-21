package dai19090.oop2.surveillance.core;

/**
 * A communication between two people that took place at a given {@link Date}.
 */
public abstract class Communication {
	private final String origin;
	private final String destination;
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
	 * Prints human-readable information about the communication.
	 */
	public final void printInfo() {
		// Descendant classes must override toString().
		System.out.println(this);
	}
}
