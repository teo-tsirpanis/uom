#include <stdio.h>

int GetInteger(void);

#define N 5
#define GENDERS 2
#define FIELDS 4

#define FOR(i, count) for (int i = 0; i < count; i++)
#define PROMPT(fieldName, fieldPos)       \
    {                                     \
        printf("Dwse %s: ", fieldName);   \
        data[i][fieldPos] = GetInteger(); \
    }

void readData(int data[N][FIELDS])
{
    FOR(i, N)
    {
        PROMPT("fylo", 0);
        PROMPT("baros", 1);
        PROMPT("ypsos", 2);
        PROMPT("ilikia", 3);
        printf("-----\n");
    }
}

void calculateAverage(int data[N][FIELDS], double averages[GENDERS], int fieldIndex)
{
    int counts[GENDERS];
    FOR(i, GENDERS)
    {
        counts[i] = 0;
        averages[i] = 0.0;
    }
    FOR(i, N)
    {
        counts[data[i][0] % GENDERS]++;
        averages[data[i][0] % GENDERS] += data[i][fieldIndex % FIELDS];
    }
    FOR(i, GENDERS)
        averages[i] /= (double)counts[i];
}

static char *gendersToString[GENDERS] = {"andrwn", "gynaikwn"};

/*
    The exercise wants the results to be printed from main, not a function.
    But this is not a function.
    I did this to avoid duplicating code.
*/
#define PRINT_AVERAGES(name, fieldIndex)                                             \
    {                                                                                \
        double averages[GENDERS];                                                    \
        calculateAverage(data, averages, fieldIndex);                                \
        FOR(i, GENDERS)                                                              \
            printf("Mesos oros %s %s: %g\n", name, gendersToString[i], averages[i]); \
        printf("\n");                                                                \
    }

int main()
{
    int data[N][FIELDS];

    readData(data);

    PRINT_AVERAGES("barous", 1);
    PRINT_AVERAGES("ypsous", 2);
    PRINT_AVERAGES("hlikias", 3);
}
