package dai19090.oop2.surveillance.core;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.stream.Collectors;
import java.util.stream.Stream;

/**
 * An interface representing the persistence layer of the
 * system. The exercise demands an in-memory registry,
 * but theoretically this interface can pave the way for a
 * full blown database storage medium.
 */
public abstract class AbstractRegistry {
    /**
     * Adds a new {@link Suspect} to the system.
     * @param suspect The {@link Suspect} in question.
     */
    public void addSuspect(Suspect suspect) {
        suspect.setOwner(this);
    }

    /**
     * @return All the {@link Suspect}s stored in the system.
     */
    public abstract Stream<Suspect> suspects();

    /**
     * @return The {@link Suspect} with the most partners,
     * or {@code null} if there aren't any.
     */
    public Suspect getSuspectWithMostPartners() {
        return suspects()
                .max(Comparator.comparingLong(suspect -> suspect.getPartners().count()))
                .orElse(null);
    };

    /**
     * Adds a new {@link Communication} to the system.
     * @param communication The {@link Communication} in question.
     */
    public abstract void addCommunication(Communication communication);

    /**
     * @return All the {@link Communication}s stored in the system.
     */
    public abstract Stream<Communication> communications();

    /**
     * @param number1 The number of the first party.
     * @param number2 The number of the second party.
     * @return The longest phone call between the two parties.
     */
    public PhoneCall getLongestPhoneCallBetween(String number1, String number2) {
        return communications()
                .filter(comm -> comm.involves(number1, number2))
                .filter(comm -> comm instanceof PhoneCall)
                .map(comm -> (PhoneCall) comm)
                .max(Comparator.comparingInt(PhoneCall::getDuration))
                .orElse(null);
    }

    /**
     * @param number1 The number of the first party.
     * @param number2 The number of the second party.
     * @return An {@link ArrayList} of suspicious {@link SMS}es between the two parties.
     */
    public ArrayList<SMS> getMessagesBetween(String number1, String number2) {
        return communications()
                .filter(comm -> comm.involves(number1, number2) && comm instanceof SMS)
                .map(comm -> (SMS) comm)
                // This function should have been called "getSuspiciousMessagesBetween"
                .filter(SMS::isSuspicious)
                // Demanding an ArrayList is a problem...
                .collect(Collectors.toCollection(ArrayList::new));
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
     * @param countryName The name of the country.
     */
    public void printSuspectsFromCountry(String countryName) {
        System.out.printf("Suspects coming from %s:\n", countryName);
        getSuspectsFromCountry(countryName).forEach(System.out::println);
    }
}
