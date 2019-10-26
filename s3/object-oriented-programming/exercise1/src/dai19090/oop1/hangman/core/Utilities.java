package dai19090.oop1.hangman.core;

class Utilities {
    static int getDistinctCharacters(String str) {
        return (int) str.chars().distinct().count();
    }
}
