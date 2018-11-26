#include <stdio.h>
#include <stdlib.h>

#define LEN 282

void shuffle

int main()
{
    char word[LEN], shuffled[LEN];

    printf("Word to shuffle :");
    gets(word);

    memcpy(shuffled, word, LEN);
}
