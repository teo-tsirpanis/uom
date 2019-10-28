package dai19090.oop1.hangman;

import dai19090.oop1.hangman.core.*;

import java.util.Scanner;

class Program {

    private static char getCharacterGuess(Scanner in) {
        String s = "";
        while (s.length() != 1) {
            System.out.print("Your guess: ");
            s = in.nextLine().toUpperCase();
        }
        return s.charAt(0);
    }

    private static void printGameOverview(Game game) {
        System.out.printf("The random word is now: %s\n", game.getWord());
        System.out.printf("You have %d guesses left.\n", game.getGuessesLeft());
    }

    private static void playGame(Game game, Scanner in) {
        while (true) {
            printGameOverview(game);
            char c = getCharacterGuess(in);
            switch (game.attempt(c)) {
                case CORRECT_ANSWER:
                    System.out.println("The guess is CORRECT!");
                    break;
                case INCORRECT_ANSWER:
                    System.out.printf("There are no %c's in the word.\n", c);
                    break;
                case CANNOT_PLAY_ANYMORE:
                    System.out.println("Get out! You can't play anymore. Or you did find a bug... :-(");
                    break;
                case ALREADY_SUBMITTED:
                    System.out.printf("You have already submitted %c.\n", c);
                    break;
            }

            if (game.isWon()) {
                System.out.printf("Congratulations! You guessed the word: %s\n", game.getWord());
                // There is no reason to display the number of successful and unsuccessful guesses.
                // The player already knows them.
                break;
            }

            if (game.isLost()) {
                System.out.printf("Too bad. :-( You didn't guess the word (it was %s).\n", game.getWord());
                break;
            }
        }
    }

    private static void printStats(GameManager gameManager) {
        int gamesWon = gameManager.getGamesWon();
        int gamesLost = gameManager.getGamesLost();

        System.out.printf("You have played so far %d games. You won %d times and lost %d times.\n",
                gamesWon + gamesLost, gamesWon, gamesLost);
    }

    public static void main(String[] args) {
        System.out.println("Hangman ~ A little console game by Theodore Tsirpanis (dai19090)");

        GameManager gameManager = new GameManager(new WordFactory());
        Scanner in = new Scanner(System.in);

        boolean doContinue = true;
        while (doContinue) {
            System.out.println("MAIN MENU");
            System.out.println("   -  Start a new Game (N)");
            System.out.println("   -  Statistics (S)");
            System.out.println("   -  Exit (E)");

            String c = in.nextLine().toUpperCase();

            switch (c) {
                case "N":
                    System.out.println();
                    Game game = gameManager.createGame();
                    playGame(game, in);
                    break;
                case "S":
                    printStats(gameManager);
                    break;
                case "E":
                    doContinue = false;
                    break;
            }
        }
    }
}
