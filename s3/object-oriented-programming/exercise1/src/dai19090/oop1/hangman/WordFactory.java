package dai19090.oop1.hangman;

import dai19090.oop1.hangman.core.AbstractWordFactory;

import java.io.IOException;
import java.nio.file.*;
import java.util.Random;

/**
 * An implementation of {@link dai19090.oop1.hangman.core.AbstractWordFactory} that
 * picks a random word from a line of a text file (words5000.txt).
 * If that file is not found, a much smaller list of words will be loaded.
 */
public final class WordFactory extends AbstractWordFactory {
    // Powered by https://www.wordfrequency.info.
    private static final String WORDS_FILE = "words5000.txt";
    // Capitalization of the words does not matter.
    private static String[] englishWords = {
            "UNIVERSITY",
            "COMPUTER",
            "LAPTOP",
            "HEADPHONES",
            "FUZZY",
            "DOG",
            "KEYHOLE",
            "TELEPHONE",
            "PRINTER",
            "BUILDING"
    };

    static {
        try {
            // The words in this file are in lowercase, but we don't care.
            // They will be converted to uppercase at the Game's constructor.
            String[] _englishWords = Files.readAllLines(Paths.get(WORDS_FILE)).toArray(new String[0]);
            if (_englishWords.length == 0)
                System.err.printf("File %s is empty. Using default list of words...\n", WORDS_FILE);
            else
                englishWords = _englishWords;
        } catch (IOException e) {
            System.err.printf("File %s was not found. Using default list of words...\n", WORDS_FILE);
        }
    }

    private final Random random = new Random();

    /**
     * {@inheritDoc}
     */
    @Override
    public String getWord() {
        return englishWords[random.nextInt(englishWords.length)];
    }
}
