#include <ctype.h>
#include <stdio.h>
#include <string.h>
#include "adt-libraries/SetADT.c"

typos_synolou numbers, signs, letters, idents;
boolean isInitialized = FALSE;

void initializeSets()
{
    if (isInitialized)
        return;

    isInitialized = TRUE;

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

boolean isValidInteger(char *s)
{
    int len = strlen(s);
    if (!isInitialized || len < 1)
        return FALSE;

    if (!(Melos(s[0], signs) && len > 1) && !Melos(s[0], numbers))
        return FALSE;

    boolean areIntegers = TRUE;
    for (int i = 1; i < len; i++)
        areIntegers &= Melos(s[i], numbers);

    return areIntegers;
}

boolean isValidIdentifier(char *s)
{
    int len = strlen(s);
    if (!isInitialized || len < 1 || !Melos(s[0], letters))
        return FALSE;

    boolean areIdents = TRUE;
    for (int i = 1; i < len; i++)
        areIdents &= Melos(s[i], idents);

    return areIdents;
}

boolean shouldContinue()
{
    printf("Should I continue? (Y/N) ");
    char c;
    scanf("%c\n", &c);

    c = tolower(c);
    return c != 'n';
}

int main()
{
    initializeSets();
    char s[640 + 1];
    boolean cont = TRUE;

    while (cont)
    {
        printf("Give an integer: ");
        gets(s);

        if (isValidInteger(s))
            printf("It's an integer.\n");
        else
            printf("It's not an integer.\n");

        cont = shouldContinue();
    }

    cont = TRUE;
    while (cont)
    {
        printf("Give an identifier: ");
        gets(s);

        if (!isValidIdentifier(s))
            printf("It's an integer.\n");
        else
            printf("It's not an integer.\n");

        cont = shouldContinue();
    }

    return 0;
}
