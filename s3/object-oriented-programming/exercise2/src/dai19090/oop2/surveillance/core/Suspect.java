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
    private final HashSet<Suspect> partners = new HashSet<>();
    private AbstractRegistry owner;

    public Suspect(String name, String codeName, String country, String city) {
        this.name = name;
        this.codeName = codeName;
        this.country = country;
        this.city = city;
    }

    /**
     * An internal method which sets the {@link AbstractRegistry}
     * which "owns" this suspect. It must be called only once,
     * at {@link AbstractRegistry#addSuspect}.
     *
     * @param owner The {@link AbstractRegistry} in question.
     */
    void setOwner(AbstractRegistry owner) {
        if (this.owner == null)
            this.owner = owner;
        else {
            //noinspection UnnecessaryLocalVariable
            RuntimeException up = new RuntimeException("The suspect's owning registry cannot be set twice.");
            throw up;
        }
    }

    void addPartner(Suspect partner) {
        partners.add(partner);
    }

    /**
     * Adds a phone number to the numbers this suspect uses.
     *
     * @param number The phone number in question.
     */
    public void addNumber(String number) {
        numbersUsed.add(number);
        if (owner != null)
            owner.addPhoneNumberToSuspect(number, this);
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
        return x != this // A suspect cannot be a partner with himself.
                // Normally, both sides of the OR should be true,
                // but we are taking precautions.
                && (this.partners.contains(x) || x.partners.contains(this));
    }

    /**
     * Finds the partners shared by two {@link Suspect}s.
     *
     * @param aSuspect The other {@link Suspect}.
     * @return All the {@link Suspect}s that have communicated to both
     * {@link Suspect}s.
     */
    public ArrayList<Suspect> getCommonPartners(Suspect aSuspect) {
        // https://stackoverflow.com/a/8882126
        HashSet<Suspect> intersection = new HashSet<>(partners);
        intersection.retainAll(aSuspect.partners);
        return new ArrayList<>(intersection);
    }

    /**
     * Finds the partners of this suspect.
     *
     * @return All the {@link Suspect}s that have communicated to this one.
     */
    public Stream<Suspect> getPartners() {
        return partners.stream();
    }

    /**
     * Suggests some suspects that are close to this one,
     * but not directly associated.
     *
     * @return The suggested partners of this suspect.
     */
    public Stream<Suspect> getSuggestedPartners() {
        return getPartners()
                .flatMap(Suspect::getPartners)
                .filter(p -> !partners.contains(p) && p != this)
                .distinct();
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
