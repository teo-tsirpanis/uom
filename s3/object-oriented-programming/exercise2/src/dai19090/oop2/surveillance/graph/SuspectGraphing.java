package dai19090.oop2.surveillance.graph;

import dai19090.oop2.surveillance.core.*;
import edu.uci.ics.jung.graph.*;

import java.util.stream.Stream;

public final class SuspectGraphing {
    private SuspectGraphing() {
        // You can't create me!
    }

    /**
     * Creates an undirected graph representing the
     * suspects and the relations between them.
     *
     * The graph is provided by the JUNG library.
     *
     * @param registry The {@link AbstractRegistry} containing the suspects.
     * @return An undirected graph with each suspect being a vertex.
     */
    public static UndirectedGraph<Suspect, Object> createSuspectGraph(AbstractRegistry registry) {
        UndirectedSparseGraph<Suspect, Object> g = new UndirectedSparseGraph<>();
        // Well, passing just the stream of suspects didn't work.
        // As it turned out, we can't traverse a stream twice,
        // in contrast with .NET's IEnumerable.
        registry.suspects().forEach(g::addVertex);
        registry.suspects().forEach(s1 ->
                s1.getPartners().forEach(s2 -> g.addEdge(new Object(), s1, s2)));
        return g;
    }
}
