#include <ctype.h>
#include <stdio.h>
#include <string.h>

#define LEN 282

char *trimWhitespaces(char *str)
{
    char *x = str;
    int len = strlen(x);

    int i = len - 1;
    while (isspace(x[i]) && i >= 0)
        x[i--] = '\0';

    while (isspace(x[0]))
        // There is no need to check for length.
        // It is gurranteed to encouner a null character.
        // If it doesn't, the program is already bugged elsewhere.
        x = &x[1];

    return x;
}

int main()
{
    char address[LEN];

    printf("Please enter an email address: ");
    gets(address);

    char *trimmed = trimWhitespaces(address);

    printf("The address trimmed is: %s\n", trimmed);

    int atPosition = strcspn(trimmed, "@");
    trimmed[atPosition] = '\0';
    printf("Name part: %s\n", trimmed);
    printf("Name part length: %d\n", atPosition);
    trimmed[atPosition] = '@';
    printf("Server part: %s\n", &trimmed[atPosition + 1]);
    return 0;
}
