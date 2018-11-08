#include <math.h>
#include "simpio.h"
#include <stdio.h>

void readData(unsigned int cities, unsigned int samplesPerDay, double data[cities][samplesPerDay])
{
    for (unsigned int i = 0; i < cities; i++)
        for (unsigned int j = 0; j < samplesPerDay; j++)
            data[i][j] = GetReal();
}

double average(unsigned int count, double data[count])
{
    double result = 0.0;
    for (unsigned int i = 0; i < count; i++)
    {
        result += data[i];
    }
    return result / (double)count;
}

double getMaxDeviation(unsigned int samplesPerDay, double cityTemps[samplesPerDay], double nationalAvg)
{
    double maxDeviation = abs(cityTemps[0] - nationalAvg);
    for (unsigned int i = 1; i < samplesPerDay; i++)
    {
        double d = abs(cityTemps[i] - nationalAvg);
        if (d > maxDeviation)
            maxDeviation = d;
    }
    return maxDeviation;
}

#define CITIES 10
#define SAMPLES_PER_DAY 3

int main()
{
    double data[CITIES][SAMPLES_PER_DAY];
    readData(CITIES, SAMPLES_PER_DAY, data);
    /* To reuse code, the 2D array can be reinterpreted as a 1D one. */
    double nationalAvg = average(CITIES * SAMPLES_PER_DAY, data);
    printf("%f\n", nationalAvg);
    for (unsigned int i = 0; i < CITIES; i++)
    {
        double localAvg = average(SAMPLES_PER_DAY, data[i]);
        double maxDeviation = getMaxDeviation(SAMPLES_PER_DAY, data[i], nationalAvg);
        printf("%g %g\n", localAvg, maxDeviation);
    }
}
