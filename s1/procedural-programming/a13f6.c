#include "simpio.h"
#include <stdio.h>

#define UL unsigned long

void decompose(UL x, UL *digitsCount, double *digitsAvg, UL *maxDigit)
{
    UL dc = 0, md = 0;
    double da = 0;
    while (x != 0)
    {
        UL digit = x % 10;
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
    UL x = (unsigned long)GetLong();

    UL digitsCount, maxDigit;
    double digitsAvg;
    decompose(x, &digitsCount, &digitsAvg, &maxDigit);

    printf("Digits: %lu, Average: %.3f, Max: %lu\n", digitsCount, digitsAvg, maxDigit);
    return 0;
}
