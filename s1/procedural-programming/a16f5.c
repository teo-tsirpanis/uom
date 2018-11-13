#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int GetInteger();

#define FOR(count) for (int i = 0; i < count; i++)

void populate(int count, int data[count])
{
    FOR(count)
        data[i] = rand() / (RAND_MAX / 10 + 1);
}

#define COUNT 50

int main()
{
    int data[COUNT];
    populate(COUNT, data);
    printf("\n");

    FOR (COUNT)
        printf("%d ", data[i]);
    printf("\n");
    printf("--------------\n");

    printf("Dose arithmo apo to 0 ews to 9: ");
    int num = GetInteger();

    int occurencesOfNum[COUNT], occurencesCount = 0;
    FOR (COUNT)
        if (data[i] == num)
            occurencesOfNum[occurencesCount++] = i;

    printf("o Arithmos %d emfanizetai %d for%s.\nStis Thesis:\n", num, occurencesCount, occurencesCount != 1 ? "es" : "a");
    FOR(occurencesCount)
        printf(" %d ", occurencesOfNum[i]);
    printf("\n-----------------\n");
}
