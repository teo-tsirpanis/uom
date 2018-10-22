#include "simpio.h"
#include <stdio.h>

int max(int x1, int x2)
{
    return x1 > x2 ? x1 : x2;
}

int gr(int x1, int x2, int x3)
{
    int x = x1;
    if (x2 > x)
        x = x2;
    if (x3 > x)
        x = x3;
    return x;
}

#define calculateY(a, b, c) ((2 * max(a, b) + 3 * gr(a, b, c)) / 4)

#define PROMPT_FOR(SYM)        \
    printf("Dwse " #SYM ": "); \
    int SYM = GetInteger()

int main()
{
    PROMPT_FOR(a);
    PROMPT_FOR(b);
    PROMPT_FOR(c);

    printf("Y = %d\n", calculateY(a, b, c));

    return 0;
}
