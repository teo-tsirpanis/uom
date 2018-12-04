#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

#define LEN 282

void shuffle(char* str)
{
    // Using the Fisher-Yates shuffling algorithm.
    // Note: The C's PRNG is not strong enough for very large text sizes.
    // See https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle#Pseudorandom_generators
    for (int i = strlen(str) - 1; i > 0; i--)
    {
        // I know it is not perfect.
        int j = rand() % (i + 1);
        char temp = str[i];
        str[i] = str[j];
        str[j] = temp;
    }
}

int main()
{
    char word[LEN], shuffled[LEN];

    srand(time(NULL));

    printf("Word to shuffle :");
    gets(word);

    strcpy(shuffled, word);
    shuffle(shuffled);

    printf("Initial Word: %s, New Word: %s\n", word, shuffled);
    return 0;
}
