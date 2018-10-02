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
    scanf("%d", &wage);
    printf("Dwse to pososto dwrou: ");
    scanf("%f", &rate);

    double gift = calculateIt(days, wage, rate);

    printf("To dwro einai %f", gift);

    return 0;
}