#include <math.h>
#include "simpio.h"
#include <stdio.h>

double average(double* data, unsigned int count)
{
    unsigned int i;
    double result = 0.0;
    for (i = 0; i < count; i++)
    {
        result += data[i];
    }
    return result / (double) count;
}

#define CITIES 10
#define SAMPLES_PER_DAY 3

int main()
{
    double data[CITIES][SAMPLES_PER_DAY];
    int i, j;
    for (i = 0; i < CITIES; i++)
        for (j = 0; j < SAMPLES_PER_DAY; j++)
            data[i][j] = GetReal();
    double nationalAvg = average(data, CITIES * SAMPLES_PER_DAY);
    printf("%f\n", nationalAvg);
    for (i = 0; i < CITIES; i++)
    {
        double localAvg = average(data[i], SAMPLES_PER_DAY);
        double maxDeviation = abs(data[i][0] - nationalAvg);
        for (j = 1; j < SAMPLES_PER_DAY; j++)
        {
            double d = abs(data[i][0] - nationalAvg);
            if (d > maxDeviation)
                maxDeviation = d;
        }
        printf("%g %g\n", localAvg, maxDeviation);
    }
}
