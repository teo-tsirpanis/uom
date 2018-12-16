#include "simpio.h"
#include <stdio.h>
#include <string.h>

#define M 282

typedef struct {
    char name[31];
    int apousies;
} studentT;

FILE *getFile (char *purpose, char *mode)
{
    FILE *f = NULL;
    char fn[282];
    while(f == NULL)
    {
        printf("Dwse to onoma gia to arxeio %s: ", purpose);
        gets(fn);

        f = fopen(fn, mode);
    }
    return f;
}

void readInput(FILE *infile, studentT students[], int *pApousies, int *pStudents)
{
    char name[31], comments[69], termch;
    int apousies, nscan, line;

    line = 0;
    *pApousies = 0;
    *pStudents = 0;

    while(TRUE)
    {
        nscan = fscanf(infile, "%30[^,], %d, %68[^\n]%c", name, &apousies, comments, &termch);
        if (nscan == EOF) break;
        line++;
        if (nscan != 4 || termch != '\n')
        {
            fprintf(stderr, "Error in line %d. Program terminated.\n", line);
            exit(1);
        }

        if (apousies > 100)
        {
            strcpy(students[*pApousies].name, name);
            students[*pApousies].apousies = apousies;
            (*pApousies)++;
        }
        (*pStudents)++;
    }
}

void writeOutput(FILE* outfile, int size, studentT absentStudents[size], int totalStudents)
{
    int i;
    fprintf(outfile, "%-30s%-9s\n", "ONOMATEPWNYMO", "APOUSIES");
    fprintf(outfile, "---------------------------------------\n");

    for(int i = 0; i < size; i++)
        fprintf(outfile, "%-30s%-9d\n", absentStudents[i].name, absentStudents[i].apousies);

    fprintf(outfile, "---------------------------------------\n");

    fprintf(outfile, "%-30s%-9d\n", "SYNOLO MATHITWN:", totalStudents);
    fprintf(outfile, "%-30s%-9d\n", "SYNOLO APONTWN:", size);
}

int main()
{
    FILE *inFile = getFile("eisodou", "r");
    FILE *outFile = getFile("exodou", "w");
    studentT students[100];
    int numOfStudents, numOfApousies;

    readInput(inFile, students, &numOfApousies, &numOfStudents);

    writeOutput(outFile, numOfApousies, students, numOfStudents);

    fclose(inFile);
    fclose(outFile);
    return 0;
}
