#include <stdio.h>

typedef struct result_t
{
    double profit;
    double saleAmount;
} result_t;

/* We cannot return two values from a function, so it has to be done in a different way. */
result_t calculateIt(long purchaseAmount, long rate)
{
    result_t result;
    result.profit = (double)purchaseAmount * (double)rate / 100.0;
    result.saleAmount = (double)purchaseAmount + result.profit;
    return result;
}

int main()
{
    long purchaseAmount;
    int rate;

    /* INPUT */
    printf("Dwse thn katharh axia: ");
    scanf("%ld", &purchaseAmount);
    printf("Dwse to pososto kerdous: ");
    scanf("%d", &rate);

    /* COMPUTATION */
    result_t result = calculateIt(purchaseAmount, rate);

    /* OUTPUT */
    printf("To kerdos einai %0.2f\n", result.profit);
    printf("To synoliko poso einai %0.2f\n", result.saleAmount);

    /* Without this, Code::Blocks displays that "Process terminated with status <something other than zero>." */
    return 0;
}