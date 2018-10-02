#include <stdio.h>

typedef struct result_t
{
    double profit;
    double total;
} result_t;

/* We cannot return two values from a function, so it has to be done in a different way. */
result_t calculateIt(long amount, long profitRate)
{
    result_t result;
    result.profit = (double)amount * (double)profitRate / 100.0;
    result.total = (double)amount + result.profit;
    return result;
}

int main()
{
    long amount, profitRate;

    /* INPUT */
    printf("Give the total amount: ");
    scanf("%d", &amount);
    printf("Give the profit rate: ");
    scanf("%d", &profitRate);

    /* COMPUTATION */
    result_t result = calculateIt(amount, profitRate);

    /* OUTPUT */
    printf("The profit is %0.2f and the total sale amount is %0.2f.\n", result.profit, result.total);

    /* Without this, Code::Blocks displays that "Process terminated with exit code <something other than zero>." */
    return 0;
}