package dai19090.oop2.surveillance.core;

import java.util.HashSet;

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
     * {@inheritDoc}
     */
    @Override
    public String toString() {
        return String.format("%s (%s)", name, codeName);
    }
}
