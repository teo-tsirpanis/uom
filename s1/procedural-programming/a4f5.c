#include <stdio.h>

int sales[4][5] =
    {
        {10, 4, 5, 6, 7},
        {7, 0, 12, 1, 3},
        {4, 9, 5, 0, 8},
        {3, 2, 1, 5, 6}};

int prices[5] = {25000, 15000, 32000, 21000, 9200};

int main()
{
    int incomePerEmployee[4] = {0, 0, 0, 0};
    int i, j;
    int quantities[5] = {0, 0, 0, 0, 0};

    for (i = 0; i < 4; i++)
        for (j = 0; j < 5; j++)
        {
            quantities[j] += sales[i][j];
            incomePerEmployee[i] += sales[i][j] * prices[j];
        }

    printf("Synoliko Poso Eispraksis / Pwlhth:");
    for (i = 0; i < 4; i++)
        printf(" %d", incomePerEmployee[i]);
    printf("\n");

    printf("Promitheia / Pwlhth:");
    for (i = 0; i < 4; i++)
        printf(" %.2f", (float)incomePerEmployee[i] / 10.0);
    printf("\n");

    printf("Posothtes Proiontwn:");
    for (i = 0; i < 5; i++)
        printf(" %d", quantities[i]);
    printf("\n");

    return 0;
}
