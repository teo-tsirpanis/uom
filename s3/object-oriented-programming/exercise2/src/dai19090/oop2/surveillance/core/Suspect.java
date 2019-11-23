package dai19090.oop2.surveillance.core;

import java.util.*;
import java.util.stream.*;

/**
 * A suspect whose communications are being tracked by this surveillance system.
 */
public final class Suspect {
    private final String name;
    private final String codeName;
    private final String country;
    private final String city;

    private final HashSet<String> numbersUsed = new HashSet<>();
    private AbstractRegistry owner;

    public Suspect(String name, String codeName, String country, String city) {
        this.name = name;
        this.codeName = codeName;
        this.country = country;
        this.city = city;
    }

    private AbstractRegistry getOwner() {
        if (owner != null)
            return owner;
        else
            throw new RuntimeException("This suspect object is not added in any registry.");
    }

    void setOwner(AbstractRegistry owner) {
        if (owner != null)
            this.owner = owner;
        else {
            //noinspection UnnecessaryLocalVariable
            RuntimeException up = new RuntimeException("A suspect cannot be added to different registries.");
            throw up;
        }
    }

    public void addNumber(String number) {
        numbersUsed.add(number);
    }

    /**
     * @return The suspect's name.
     */
    public String getName() {
        return name;
    }

    /**
     * @return The suspect's code name.
     */
    public String getCodeName() {
        return codeName;
    }

    /**
     * @return The suspect's country of origin.
     */
    public String getCountry() {
        return country;
    }

    /**
     * @return The suspect's city of residence.
     */
    public String getCity() {
        return city;
    }

    /**
     * @return The phone numbers the suspect is known to use.
     */
    public Stream<String> getNumbersUsed() {
        return numbersUsed.stream();
    }

    /**
     * Checks if two {@link Suspect}s are connected.
     *
     * @param x The other {@link Suspect}.
     * @return Whether there is at least one {@link Communication} between
     * numbers known to belong to the two {@link Suspect}s.
     */
    public boolean isConnectedTo(Suspect x) {
        // This function sadly takes O(n²) time.
        // Impressive how two lines of the Java 8 streams can hide so much complexity.
        // But since performance of a program is not a criterion in its evaluation,
        // this is OK. In real life, a DBMS would have been more suitable of efficiently
        // answering such queries.
        return x != this &&
                getOwner().communications()
                .anyMatch(comm -> comm.involves(this, x));
    }

    /**
     * Finds the partners shared by two {@link Suspect}s.
     *
     * @param aSuspect The other {@link Suspect}.
     * @return All the {@link Suspect}s that have communicated to both
     * {@link Suspect}s.
     */
    public ArrayList<Suspect> getCommonPartners(Suspect aSuspect) {
        // Oh boy! That's O(n³)!
        return getOwner().suspects()
                .filter(suspect -> suspect.isConnectedTo(this) && suspect.isConnectedTo(aSuspect))
                .collect(Collectors.toCollection(ArrayList::new));
    }

    /**
     * Finds the partners of this suspect.
     *
     * @return All the {@link Suspect}s that have communicated to this one.
     */
    public Stream<Suspect> getPartners() {
        return getOwner().suspects().filter(this::isConnectedTo);
    }

    /**
     * Prints the partners of this suspect to the console.
     * An asterisk is also printed if their country is the
     * same with this {@link Suspect}.
     */
    public void printPartners() {
        getPartners().forEach(suspect -> {
            System.out.print(suspect);
            if (suspect.country.equals(this.country))
                System.out.print(" *");
            System.out.println();
        });
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public String toString() {
        return String.format("%s (%s)", name, codeName);
    }
}
