#include <stdio.h>

double calculateNthHarmonicNumber (unsigned long n)
{
    double x = 0.0;
    unsigned long i = 0;
    for (i = 1; i <= n; i++)
        x += 1.0 / i;
    return x;
}

#define N 100

int main()
{
    double h = calculateNthHarmonicNumber(N);
    printf("%f\n", h);
    return 0;
}
