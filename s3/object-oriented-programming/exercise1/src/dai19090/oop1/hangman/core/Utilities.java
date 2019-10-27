package dai19090.oop1.hangman.core;

/**
 * A class holding some utility functions.
 */
class Utilities {
    /**
     * Counts the distinct characters of a string.
     * Counting is performed on a case-sensitive basis.
     * @param str The string whose distinct characters are to be counted.
     * @return The number of distinct characters of the given string.
     */
    static int getDistinctCharacters(String str) {
        return (int) str.chars().distinct().count();
    }
}
