#include <stdio.h>
#include "simpio.h"

#define promptForAge() printf("Dwse ilikia: "), GetInteger()

int main()
{
    int min, max, x;

    x = min = max = promptForAge();

    if (x != -1)
    {
        /* While a negative age is an absurdity, the program still stops exactly
        when the age is equal to -1, because that was what the excercise requires. */
        while ((x = promptForAge()) != -1)
        {
            if (x > max)
                max = x;
            if (x < min)
                min = x;
        }
        printf("H megalyterh ilikia einai %d\n", max);
        printf("H mikroterh ilikia einai %d\n", min);
    }
    else
        printf("Den dothike kamia ilikia\n");
}