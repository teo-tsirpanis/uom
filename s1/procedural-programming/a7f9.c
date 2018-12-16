#include <ctype.h>
#include <stdbool.h>
#include <stdio.h>
#include <stdlib.h>

#define NULL_CHECK(msg, x)  \
    if (x == NULL)          \
    {                       \
        fputs(msg, stderr); \
        exit(1);            \
    }

int main()
{
    FILE *infile = fopen("i7f9.dat", "r");
    FILE *outfile = fopen("o7f9.dat", "w");
    NULL_CHECK("Input file cannot be opened\n", infile);
    NULL_CHECK("Output file cannot be opened\n", outfile);

    bool isInsideNumber = false;

    int ch;

    while ((ch = getc(infile)) != EOF)
    {
        if (isdigit(ch))
        {
            putc(ch, outfile);
            isInsideNumber = true;
        }
        else if (isInsideNumber)
        {
            putc('\n', outfile);
            isInsideNumber = false;
        }
    }
    fclose(infile);
    fclose(outfile);
    return 0;
}
