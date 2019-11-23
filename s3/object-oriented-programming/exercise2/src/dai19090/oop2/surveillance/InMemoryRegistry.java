package dai19090.oop2.surveillance;

import dai19090.oop2.surveillance.core.*;

import java.util.ArrayList;
import java.util.stream.Stream;

/**
 * An implementation of {@link AbstractRegistry} that stores
 * {@link Suspect}s and {@link Communication}s in memory.
 * Obviously, all data are lost when tha app gets closed,
 * which is the reason more serious alternatives should have
 * been considered in real life.
 */
public class InMemoryRegistry extends AbstractRegistry {
    private ArrayList<Suspect> _suspects = new ArrayList<>();
    private ArrayList<Communication> _communications = new ArrayList<>();

    /**
     * {@inheritDoc}
     */
    @Override
    public void addSuspect(Suspect suspect) {
        _suspects.add(suspect);
        super.addSuspect(suspect);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public Stream<Suspect> suspects() {
        return _suspects.stream();
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public void addCommunication(Communication communication) {
        _communications.add(communication);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public Stream<Communication> communications() {
        return _communications.stream();
    }
}
