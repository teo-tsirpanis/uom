#include "simpio.h"
#include <stdio.h>

void decompose(long x, long *digitsCount, double *digitsAvg, long *maxDigit)
{
    long dc = 0, md = 0;
    double da = 0;
    while (x != 0)
    {
        long digit = x % 10;
        dc++;
        da += (double)digit;
        if (digit > md)
            md = digit;
        x /= 10;
    }
    da /= dc != 0 ? (double) dc : 1.0;
    *digitsCount = dc;
    *digitsAvg = da;
    *maxDigit = md;
}

int main()
{
    printf("Please insert non-negative number:");
    long x = GetLong();

    long digitsCount, maxDigit;
    double digitsAvg;
    decompose(x, &digitsCount, &digitsAvg, &maxDigit);

    printf("Digits: %ld, Average: %.3f, Max: %ld\n", digitsCount, digitsAvg, maxDigit);
    return 0;
}
