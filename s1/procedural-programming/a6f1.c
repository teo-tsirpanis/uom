#include <stdio.h>

double calculateIt(int days, long wage, double rate)
{
    return (double)days * (double)wage * rate;
}

int main()
{
    int days;
    long wage;
    double rate;

    printf("Dwse tis imeres ergasias tou etous: ");
    scanf("%d", &days);
    printf("Dwse thn hmerisia amoibh: ");
    scanf("%ld", &wage);
    printf("Dwse to pososto dwrou: ");
    scanf("%lf", &rate);

    double gift = calculateIt(days, wage, rate);

    /* In the exercise, with the parameters being 354, 5445, and 0.25, it says that the gift is 484883 instead of 484882.5.
    I would have rounded the result to an integer, had its type being a double not been explicitly stated. */
    printf("To dwro einai %0.2f\n", gift);

    return 0;
}
