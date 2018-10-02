#include <stdio.h>

#define TWO_MONTHS 61.0 / 365.0

void calculateIt(unsigned long kathara, unsigned long mikta, double *dt, double *df)
{
    *dt = (double)kathara * 1.33 * TWO_MONTHS;
    *df = (double)mikta * 0.13 * TWO_MONTHS;
}

int main()
{
    unsigned long kathara, mikta;
    double dt, df;

    printf("Dwse ta ka8ara tm tou spitiou? ");
    scanf("%lu", &kathara);
    printf("Dose ta mikta tm tou spitiou ? ");
    scanf("%lu", &mikta);

    calculateIt(kathara, mikta, &dt, &df);

    printf("Ta DT einai : %0.2f\n", dt);
    printf("O DF einai: %0.2f\n", df);

    return 0;
}
