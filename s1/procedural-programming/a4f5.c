#include <stdio.h>

int sales[4][5] =
{
    {10, 4, 5, 6, 7},
    {7, 0, 12, 1, 3},
    {4, 9, 5, 0, 8},
    {3, 2, 1, 5, 6}
};

int prices[5] = {25000, 15000, 32000, 21000, 9200};

int main()
{
    int incomePerEmployee[4] = {0, 0, 0, 0};
    int i;
    for (i = 0; i < 4; i++)
        for (j = 0; j < 5; j++)
            incomePerEmployee[i] += sales[i][j] + prices[j];
    printf("Synoliko Poso Eispraksis / Pwlhth: %d %d %d %d\n", incomePerEmployee[0], incomePerEmployee[1], incomePerEmployee[2], incomePerEmployee[3]);
    printf("Synoliko");
}
