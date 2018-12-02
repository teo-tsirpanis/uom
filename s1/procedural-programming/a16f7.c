#include <ctype.h>
#include <stdio.h>
#include <string.h>

// Can't do much things, since the length is specified...
#define LEN 282 - 182

void printSumOfDigits(char *str)
{
    int len = strlen(str);
    unsigned int sum = 0;
    int hasAlreadyEncounteredNumber = 0;
    for (int i = 0; i < len; i++)
        if (isdigit(str[i]))
        {
            int num = str[i] - '0';
            if (hasAlreadyEncounteredNumber)
                printf(" + ");
            hasAlreadyEncounteredNumber = 1;
            putchar(str[i]);
            sum += num;
        }
    printf(" = %u", sum);
}

int main()
{
    char str[LEN];
    printf("Dose ena alfarithmitiko: ");

    gets(str);
    printSumOfDigits(str);

    return 0;
}