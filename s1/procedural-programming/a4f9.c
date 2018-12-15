#include <stdio.h>
#include <stdlib.h>

#define STR_LEN 25 + 1

#define NULL_CHECK(msg, x)  \
    if (x == NULL)          \
    {                       \
        fputs(msg, stderr); \
        exit(1);            \
    }

long getKickback(int code, long price)
{
    double percentage;

    switch (code)
    {
        case 11:
            percentage = 0.03;
            break;

        case 12:
            percentage = 0.05;
            break;

        case 13:
            percentage = 0.08;
            break;

        case 14:
            percentage = 0.11;
            break;

        default:
            percentage = 1.0;
            break;
    }
    return (long)((double) price * percentage);
}

int main()
{
    NULL_CHECK("Input file cannot be opened\n", freopen("i4f9.dat", "r", stdin));
    NULL_CHECK("Output file cannot be opened\n", freopen("o4f9.dat", "w", stdout));

    int nscan = 0;
    int line = 0;
    int code = 0;
    char name[STR_LEN];
    long price = 0;
    char termch = 0;

    while ((nscan = scanf("%d,%25[^,],%ld%c", &code, name, &price, &termch)) != EOF)
    {
        line++;
        if (nscan != 4 || termch != '\n')
        {
            fprintf(stderr, "Error in line %d. Program terminated.\n", line);
            return 1;
        }

        printf("%-25s%-6d\n", name, getKickback(code, price));
    }

    return 0;
}
