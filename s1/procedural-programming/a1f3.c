#include <math.h>
#include <stdio.h>

#define EXERCISE_1A /* Uncomment for Exercise 1b. */

unsigned int findFirstGeormetricProgressionTermLargerThan (double a, double ratio, double limit)
{
    /* A simple inequality manipulation can lead to a solution without any loops whatsoever. */
    return ceil(log(limit / a) / log(ratio));
}

/* The problem of finding the year when the number of cars exceed a given number is essentially
a problem of finding the first term of a geometric progression which is larger than a given number. */
#define getYearOfExcessiveCars(initialCars, yearlyCarsGrowthPercent, carsLimit) findFirstGeormetricProgressionTermLargerThan(initialCars, 1.0 + yearlyCarsGrowthPercent / 100.0, carsLimit)

unsigned int getCarsAtYear (unsigned int initialCars, double ratio, unsigned int year)
{
    unsigned int a = initialCars;
    for (int i = 0; i < year; i++)
    {
        a = ceil(a * (1.0 + ratio / 100.0));
    }
    return a;
}

#define INITIAL_CARS 80000
#define RATE_PERCENT 7
#define LIMIT 160000

int main()
{
    
    unsigned int cars = INITIAL_CARS;
    double ratePercent = RATE_PERCENT;
    unsigned int limit = LIMIT;

    #ifndef EXERCISE_1A
    printf("Dwse ton arxiko arithmo autokinhtwn: ");
    scanf("%u", &cars);
    printf("Dwse ton ethsio rythmo ayxhshs: ");
    scanf("%lf", %ratePercent);
    printf("Dwse to orio: ");
    scanf("%u", &limit);
    #endif

    unsigned int year = getYearOfExcessiveCars(cars, ratePercent, limit);

    printf("%u\n", year);
    printf("%u\n", getCarsAtYear(cars, ratePercent, year));

    return 0;
}
