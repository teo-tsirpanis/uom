#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define FOR(i, count) for (int i = 0; i < count; i++)

int GetInteger();

void populate_data(int rows, int columns, int data[rows][columns])
{
    FOR(i, rows)
        FOR(j, columns)
            data[i][j] = rand() / (RAND_MAX / 100 + 1);
            // A simple rand() % 100 does not provide equidistribution.
}

void change_array(int columns, int data[columns])
{
    int maxPos = 0, maxElem = data[maxPos];

    FOR(i, columns)
        if (data[i] > maxElem)
        {
            maxElem = data[i];
            maxPos = i;
        }

    for (int i = maxPos; i >= 0; i--)
        data[i] = maxElem;
}

void print_array(int rows, int columns, int data[rows][columns])
{
    FOR(i, rows)
    {
        FOR(j, columns)
            printf("%2d ", data[i][j]);
        printf("\n");
    }
}

int main()
{
    srand(time(NULL));

    printf("Dwse ton arithmo twn grammw: ");
    int rows = GetInteger();
    printf("Dwse ton arithmo twn sthlwn: ");
    int columns = GetInteger();

    int data[rows][columns];

    populate_data(rows, columns, data);
    print_array(rows, columns, data);
    printf("\n");
    FOR(i, rows)
        change_array(columns, data[i]);
    print_array(rows, columns, data);

    return 0;
}
