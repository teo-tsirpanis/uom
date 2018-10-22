#include <stdio.h>

unsigned int total(unsigned int x)
{
    return (1 + x) * x / 2;
}

#define PRINT_TOTAL(x) printf ("Athr 1 ... %-4d = %d\n", x, total(x))

int main()
{
    PRINT_TOTAL(100);
    PRINT_TOTAL(1000);
}