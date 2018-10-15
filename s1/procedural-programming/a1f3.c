#include <math.h>
/* I think it's time for a concession. Using scanf alone
makes programs way too unreliable, and prone to faulty input.
As a sidenote, C itself is terrible at reading input from the
user, unlike Pascal, for example. Because of binary incompatibility
issues with the Roberts' library, I decided to compile it myself. and use it. */
#include "simpio.h"
#include <stdio.h>

#define EXERCISE_1A /* Uncomment for Exercise 1b. */

unsigned int findFirstGeormetricProgressionTermLargerThan (double a, double ratio, double limit)
{
    /* A simple inequality manipulation can lead to a solution without any loops whatsoever. */
    return ceil(log(limit / a) / log(1.0 + ratio));
}

/* The problem of finding the year when the number of cars exceed a given number is essentially
a problem of finding the first term of a geometric progression which is larger than a given number. */
#define getYearOfExcessiveCars findFirstGeormetricProgressionTermLargerThan

unsigned int getCarsAtYear (unsigned int initialCars, double rate, unsigned int year)
{
    unsigned int a = initialCars;
    int i = 0; /* Code::Blocks says that 'for' loop initial declarations are only allowed in C99 mode */

    for (i = 0; i < year; i++)
    {
        a = ceil(a * (1.0 + rate));
    }
    return a;
}

#define INITIAL_CARS 80000
#define RATE 0.07
#define LIMIT 160000

int main()
{

    unsigned int cars = INITIAL_CARS;
    double rate = RATE;
    unsigned int limit = LIMIT;

    #ifndef EXERCISE_1A
    printf("Dwse ton arxiko arithmo autokinhtwn: ");
    cars = GetInteger();
    printf("Dwse ton ethsio rythmo ayxhshs: ");
    rate = GetReal();
    printf("Dwse to orio: ");
    limit = GetInteger();
    #endif

    unsigned int year = (cars != limit) ? getYearOfExcessiveCars(cars, rate, limit) : 1;

    printf("%u\n", year);
    printf("%u\n", getCarsAtYear(cars, rate, year));

    return 0;
}
