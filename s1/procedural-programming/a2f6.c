#include <stdio.h>

int GetInteger();

#define PROMPT() (printf("? "), GetInteger())
#define MAX_ELEMENTS 100

int inputArray(int data[MAX_ELEMENTS])
{
    int i = 0;
    do
    {
        int f = PROMPT();
        data[i] = f;
    } while (data[i++] != -1 && i < MAX_ELEMENTS);
    return --i;
}

void minMax(int length, int data[length], int *min, int *max)
{
    *min = *max = data[0];
    for (int i = 1; i < length; i++)
    {
        *min = data[i] < *min ? data[i]: *min;
        *max = data[i] > *max ? data[i]: *max;
    }
}

int main()
{
    printf("Enter the elements of the array, one per line.\n");
    printf("Use -1 to signal the end of the list.\n");

    int data[MAX_ELEMENTS], length = inputArray(data);
    int min, max;
    minMax(length, data, &min, &max);

    printf("The range of values is %d-%d", min, max);
    return 0;
}
