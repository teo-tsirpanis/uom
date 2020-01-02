package dai19090.oop2.surveillance.core;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.stream.Collectors;
import java.util.stream.Stream;

/**
 * <p>An interface representing the persistence layer of the
 * system. The exercise demands an in-memory registry,
 * but theoretically this interface can pave the way for a
 * full blown database storage medium.</p>
 * <p>The inheritance mechanism is very flexible. Descendants must
 * override {@link AbstractRegistry#suspects()},
 * {@link AbstractRegistry#communications} and their corresponding
 * {@code add*} methods (which must call {@code super()}, but also
 * can override the protected {@link AbstractRegistry#addPhoneNumberToSuspect}
 * method which will help them to provide a more optimized implementation of
 * {@link AbstractRegistry#getPhoneOwner} with some sort of lookup tables.
 * Of course they are free to override any other method they want, maybe
 * to fetch data from a DBMS</p>
 */
public abstract class AbstractRegistry {
    /**
     * Adds a new {@link Suspect} to the system.
     * Descendants must override this method to
     * actually add their suspect, and call
     * {@code super(suspect)}.
     *
     * @param suspect The {@link Suspect} in question.
     */
    public void addSuspect(Suspect suspect) {
        suspect.setOwner(this);
        // Add to the registry all numbers already assigned to this suspect.
        suspect.getNumbersUsed().forEach(number -> addPhoneNumberToSuspect(number, suspect));
    }

    /**
     * @return All the {@link Suspect}s stored in the system.
     */
    public abstract Stream<Suspect> suspects();

    /**
     * Adds a new {@link Communication} to the system.
     *
     * @param communication The {@link Communication} in question.
     */
    public void addCommunication(Communication communication) {
        Suspect theBadGuy = getPhoneOwner(communication.getOrigin());
        Suspect hisWorseFriend = getPhoneOwner(communication.getDestination());

        // What if a phone number is added later? There wouldn't
        // be any opportunity to regard the newly-added suspect's
        // partners. This here is the only function that calls
        // Suspect#addParnter. And this scenario has real-word parallels.
        // Imagine a suspected terrorist talking to an unidentified
        // friend of his about bombing a building. The second phone
        // number would not have been recognized by the system
        //
        // I have thought of two possible solutions that require some
        // refactoring to be implementable however.
        //
        // The first is to keep a list of unresolved communications.
        // Every time a new phone number gets added, this list gets
        // searched to find of any phone number matches the recently added one.
        //
        // The second way is more simple. A new suspect gets created,
        // with a temporary name like "Johnny Doe". However, the names
        // of the suspects cannot be changed, and I would personally
        // prefer to keep it this way, unless it is explicitly asked
        // in the specifications.
        if (theBadGuy != null && hisWorseFriend != null) {
            theBadGuy.addPartner(hisWorseFriend);
            hisWorseFriend.addPartner(theBadGuy);
        }
    }

    /**
     * @return All the {@link Communication}s stored in the system.
     */
    public abstract Stream<Communication> communications();

    /**
     * Associates a phone number to a {@link Suspect}.
     * This method should only be called inside {@link Suspect#addNumber}.
     *
     * @param number  The phone number.
     * @param suspect The {@link Suspect} that uses {@code number}.
     */
    protected void addPhoneNumberToSuspect(String number, Suspect suspect) {
        // Optimized implementations will implement it.
    }

    /**
     * @param number The phone number
     * @returns The {@link Suspect} that uses {@code number},
     * or {@code null} if there isn't any.
     */
    public Suspect getPhoneOwner(String number) {
        // This algorithm runs in O(n²) time, but can be optimized by
        // a look-up table in descendant classes that also override
        // addPhoneNumberToSuspect.
        return suspects()
                .filter(suspect ->
                        suspect.getNumbersUsed()
                                .anyMatch(number::equals)).findAny()
                .orElse(null);
    }

    /**
     * @return The {@link Suspect} with the most partners,
     * or {@code null} if there aren't any.
     */
    public Suspect getSuspectWithMostPartners() {
        return suspects()
                .max(Comparator.comparingLong(suspect -> suspect.getPartners().count()))
                .orElse(null);
    }

    /**
     * @param countryName The name of the country.
     * @return All the {@link Suspect}s from the country.
     */
    public Stream<Suspect> getSuspectsFromCountry(String countryName) {
        return suspects().filter(s -> s.getCountry().equals(countryName));
    }

    /**
     * Prints details of all {@link Suspect}s from a country.
     *
     * @param countryName The name of the country.
     */
    public void printSuspectsFromCountry(String countryName) {
        System.out.printf("Suspects coming from %s:\n", countryName);
        getSuspectsFromCountry(countryName).forEach(System.out::println);
    }

    /**
     * @param number1 The number of the first party.
     * @param number2 The number of the second party.
     * @return The longest phone call between the two parties.
     */
    public PhoneCall getLongestPhoneCallBetween(String number1, String number2) {
        return communications()
                .filter(comm -> comm instanceof PhoneCall && comm.involves(number1, number2))
                .map(comm -> (PhoneCall) comm)
                .max(Comparator.comparingInt(PhoneCall::getDuration))
                .orElse(null);
    }

    /**
     * @param number1 The number of the first party.
     * @param number2 The number of the second party.
     * @return An {@link ArrayList} of suspicious {@link SMS}es between the two parties.
     */
    // This function should have been called "getSuspiciousMessagesBetween"
    public ArrayList<SMS> getMessagesBetween(String number1, String number2) {
        return communications()
                .filter(comm -> comm instanceof SMS && ((SMS) comm).isSuspicious() && comm.involves(number1, number2))
                .map(comm -> (SMS) comm)
                // Demanding an ArrayList is a problem...
                .collect(Collectors.toCollection(ArrayList::new));
    }
}
