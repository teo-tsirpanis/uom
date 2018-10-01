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

    printf("Dose ta kathara tetragonika: ");
    scanf("%u", &kathara);
    printf("Dose ta mikta tetragonika: ");
    scanf("%u", &mikta);

    calculateIt(kathara, mikta, &dt, &df);

    printf("Ta dimotika teli einai: %0.2f\n", dt);
    printf("Ta mikta teli einai: %0.2f\n", df);

    return 0;
}
