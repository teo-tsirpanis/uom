#include <stdio.h>

/* We cannot return two values from a function, so it has to be done the pointer way. */
void calculateIt(long amount, long profitRate, double *profit, double *total)
{
    *profit = amount * profitRate / 100.0;
    *total = (double)amount + *profit;
}

int main()
{
    long amount, profitRate;
    double profit, total;

    /* INPUT */
    printf("Give the total amount: ");
    scanf("%d", &amount);
    printf("Give the profit rate: ");
    scanf("%d", &profitRate);

    /* COMPUTATION */
    calculateIt(amount, profitRate, &profit, &total);

    /* OUTPUT */
    printf("The profit is %0.2f and the total sale amount is %0.2f.\n", profit, total);

    /* Code::Blocks displays that "Process terminated with exit code <something other than zero>." */
    return 0;
}