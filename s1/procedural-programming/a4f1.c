#include <stdio.h>

void calculateIt(long amount, long profitRate, double* profit, double* total) {
    *profit = amount * profitRate / 100.0;
    *total = (double) amount + *profit;
}

main() {
    long amount, profitRate;
    double profit, total;

    printf("Give the total amount: ");
    scanf("%d", &amount);
    printf("Give the profit rate: ");
    scanf("%d", &profitRate);

    calculateIt(amount, profitRate, &profit, &total);

    printf("The profit is %f and the total sale amount is %f.", profit, total);

}