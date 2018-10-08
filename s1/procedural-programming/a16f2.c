#include <stdio.h>

double calculateCost(int sms)
{
    double cents = 0.0;
    if (sms > 10 + 50 + 100)
        cents = 10 * 2.0 + 50 * 1.5 + 100 * 1.2 + (sms - 10 - 50 - 100) * 1.0;
    else if (sms > 10 + 50)
        cents = 10 * 2.0 + 50 * 1.5 + (sms - 10 - 50) * 1.2;
    else if (sms > 10)
        cents = 10 * 2.0 + (sms - 10) * 1.5;
    else
        cents = sms * 2.0;
    return cents / 100; /* The result is in euro */
}

int main()
{
    int sms = 0;

    printf("Dose plithos sms :");
    scanf("%d", &sms);

    double cost = calculateCost(sms);

    printf("Synoliko poso se euro: %0.2f\n", cost);

    return 0;
}
