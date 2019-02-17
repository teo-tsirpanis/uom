#include <ctype.h>
#include <stdbool.h>
#include <stdio.h>
#include <string.h>
#include "adt-libraries/SetADT.c"

typos_synolou numbers, signs, letters, idents;
bool isInitialized = false;

void initializeSets()
{
    if (isInitialized)
        return;

    isInitialized = true;

    Dimiourgia(numbers);
    for (char c = '0'; c <= '9'; c++)
        Eisagogi(c, numbers);

    Dimiourgia(signs);
    Eisagogi('+', signs);
    Eisagogi('-', signs);

    Dimiourgia(letters);
    for (char c = 'a'; c <= 'z'; c++)
    {
        Eisagogi(c, letters);
        Eisagogi(toupper(c), letters);
    }

    Dimiourgia(idents);
    EnosiSynolou(letters, numbers, idents);
    Eisagogi('_', idents);
}

bool isValidInteger(char *s)
{
    int len = strlen(s);
    if (!isInitialized || len < 1)
        return false;

    if (!(Melos(s[0], signs) && len > 1) && !Melos(s[0], numbers))
        return false;

    bool areIntegers = true;
    for (int i = 1; i < len; i++)
        areIntegers &= Melos(s[i], numbers);

    return areIntegers;
}

bool isValidIdentifier(char *s)
{
    int len = strlen(s);
    if (!isInitialized || len < 1 || !Melos(s[0], letters))
        return false;

    bool areIdents = true;
    for (int i = 1; i < len; i++)
        areIdents &= Melos(s[i], idents);

    return areIdents;
}

bool shouldContinue()
{
    printf("na synexiso? (Y/N) ");
    char s[10];
    gets(s);

    char c = tolower(s[0]);
    return c != 'n';
}

int main()
{
    initializeSets();
    char s[640 + 1];
    bool cont = true;

    while (cont)
    {
        printf("dose akeraio: ");
        gets(s);

        if (!isValidInteger(s))
            printf("den ");
        printf("einai akeraios.\n");

        cont = shouldContinue();
    }

    cont = true;
    while (cont)
    {
        printf("dose anagnoristiko: ");
        gets(s);

        if (!isValidIdentifier(s))
            printf("den ");
        printf("einai anagnoristiko.\n");

        cont = shouldContinue();
    }

    return 0;
}
