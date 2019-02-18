#include <stdio.h>
#include "adt-libraries/SetADT.c"

#define N 5
#define PS_N 32

int main()
{
    typos_synolou powersets[PS_N];
    for (int i = 0; i < PS_N; i++)
    {
        int k = i;
        Dimiourgia(powersets[i]);
        for (int j = 0; j < N; j++)
        {
            if (k % 2)
                Eisagogi(j, powersets[i]);
            k >>= 1;
        }
    }

    for (int i = 0; i < PS_N; i++)
    {
        for (int j = 0; j < megisto_plithos; j++)
            if (Melos(j, powersets[i]))
                printf("%d ", j + 1);
        printf("\n");
    }

    return 0;
}