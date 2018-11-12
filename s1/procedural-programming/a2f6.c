#include <stdio.h>

int GetInteger();

#define PROMPT() printf("? "), GetInteger()

int main()
{
    printf("Enter the elements of the array, one per line.\n");
    printf("Use -1 to signal the end of the list.\n");

    int min, max;

    int i = PROMPT();
    min = max = i;

    
    return 0;
}