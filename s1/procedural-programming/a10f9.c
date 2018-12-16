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
    FILE *infile = fopen("i10f9.dat", "r");
    FILE *outfile = fopen("o10f9.dat", "w");
    NULL_CHECK("Input file cannot be opened\n", infile);
    NULL_CHECK("Output file cannot be opened\n", outfile);

    bool didSeeDotOrComma = false;
    int ch;

    while ((ch = getc(infile)) != EOF)
    {
        if (didSeeDotOrComma && !isspace(ch))
            putc(' ', outfile);
        putc(ch, outfile);
        didSeeDotOrComma = ch == '.' || ch == ',';
    }

    fclose(infile);
    fclose(outfile);
    return 0;
}