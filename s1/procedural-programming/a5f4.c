#include <math.h>
#include <stdio.h>

/* Per Wikipedia an Armstrong Number is a number that is the sum of
its own digits each raised to the power of the number of digits.
Which means that */
int isArmstrong (unsigned int x)
{
    unsigned int digitsCount = ceil(log10(x));
    unsigned int sum = 0;
    unsigned int i = x;
    while (i)
    {
        sum += pow(i % 10, digitsCount);
        i /= 10;
    }
    return sum == x;
}

#define MAX_NUMBER 999

int main()
{
    unsigned int i;
    for (i = 1; i < 999; i++)
        if (isArmstrong(i))
            printf("%u\n", i);

    return 0;
}
