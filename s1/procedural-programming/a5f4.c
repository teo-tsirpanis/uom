#ifndef REAL_ARMSTRONG_NUMBERS
#include <assert.h>
#endif
#include <math.h>
#include <stdio.h>

/* Per Wikipedia an Armstrong Number is a number that is the sum of
its own digits each raised to the power of the number of digits.
Which means that. But the exercise does not want us to do that.
Uncomment the following line for the actual definition of the Armstrong Numbers. */

/* #define REAL_ARMSTRONG_NUMBERS */

#define cube(x) pow(x, 3)

int isArmstrong(unsigned int x)
{
    unsigned int sum = 0;
#ifdef REAL_ARMSTRONG_NUMBERS
    unsigned int digitsCount = ceil(log10(x));
#else
    unsigned int digitsCount = 3;
    assert(x <= 999);
#endif
    unsigned int i = x;
    while (i)
    {
        /* The omission of the floor would make 5^3 equal to 124.
        TODO: Ask Stack Overflow about that. */
        sum += floor(pow(i % 10, digitsCount));
        i /= 10;
    }
    return sum == x;
}

#define MAX_NUMBER 999

int main()
{
    unsigned int i;
    for (i = 1; i < MAX_NUMBER; i++)
        if (isArmstrong(i))
            printf("%u\n", i);

    return 0;
}
