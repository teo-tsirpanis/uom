#include <stdio.h>
#include <stdlib.h>

int GetInteger(void);
long GetLong(void);

#define DATA_ARRAY(i, j) (*(data + (i * columns + j)))
#define DATA DATA_ARRAY(i, j)
#define FREE(x) {free(x); x = NULL;}

int main()
{
    printf("Dwse ton arithmo twn grammwn: ");
    int rows = GetInteger();
    printf("Dwse ton arithmo twn sthlwn: ");
    int columns = GetInteger();

    long *data = calloc(rows * columns, sizeof(long));
    long *columnSum = calloc(columns, sizeof(long));

    for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
        {
            printf("Thesi [%d,%d]:", i, j);
            DATA = GetLong();
        }

    printf("Table:\n");
    for (int i = 0; i < rows; i++)
    {
        long rowSum = 0;
        for (int j = 0; j < columns; j++)
        {
            rowSum += DATA;
            columnSum[j] += DATA;
            printf("%4ld", DATA);
        }
        printf("| = %ld\n", rowSum);
    }
    for (int i = 0; i < columns; i++)
        printf("----");
    printf("\n");
    for (int i = 0; i < columns; i++)
        printf("%4ld", columnSum[i]);
    
    if (rows == columns)
    {
        long sumDiag1 = 0;
        long sumDiag2 = 0;
        for (int i = 0; i < columns; i++)
        {
            sumDiag1 += DATA_ARRAY(i, i);
            sumDiag2 += DATA_ARRAY(i, columns - i - 1);
        }
        printf("\nSum Diag 1: %4ld,   Diag 2: %4ld\n", sumDiag1, sumDiag2);
    }

    FREE(data);
    FREE(columnSum);
    return 0;
}
