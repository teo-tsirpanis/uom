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
    return (long)((double)price * percentage);
}

int main()
{
    FILE *infile = fopen("i4f9.dat", "r");
    FILE *outfile = fopen("o4f9.dat", "w");
    NULL_CHECK("Input file cannot be opened\n", infile);
    NULL_CHECK("Output file cannot be opened\n", outfile);

    int nscan = 0;
    int line = 0;
    int code = 0;
    char name[STR_LEN];
    long price = 0;
    char termch = 0;

    while ((nscan = fscanf(infile, "%d,%25[^,],%ld%c", &code, name, &price, &termch)) != EOF)
    {
        line++;
        if (nscan != 4 || termch != '\n')
        {
            fprintf(stderr, "Error in line %d. Program terminated.\n", line);
            return 1;
        }

        fprintf(outfile, "%-25s%-6d\n", name, getKickback(code, price));
    }

    fclose(infile);
    fclose(outfile);
    return 0;
}
