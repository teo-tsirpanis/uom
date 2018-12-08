#include <stdio.h>
#include "simpio.h"

typedef struct
{
    char name[282];
    char surname[617];
    double wage;
    unsigned int hours;
    double deductions;
    double gross;
    double tax;
    double net;
} teacher_t;

void get_data(teacher_t *t)
{
    printf("Dose onoma: ");
    gets(t->name);
    printf("Dose eponymo: ");
    gets(t->surname);
    printf("Dose mistho oras: ");
    t->wage = GetReal();
    printf("Dose ores ergasias: ");
    t->hours = GetInteger();
}

void calc_salaries(teacher_t *t)
{
    t->gross = t->wage * (double)t->hours;
    t->deductions = t->gross * 0.15;
    t->tax = (t->gross - t->deductions) * 0.07;
    t->net = t->gross - t->deductions - t->tax;
}

void print_data(const teacher_t *t)
{
    printf("%-16s%-21s%11.2lf%15d%10.2lf%12.2lf%8.2lf%8.2lf\n", t->name, t->surname, t->wage, t->hours, t->gross, t->deductions, t->tax, t->net);
}

#define FOR for (int i = 0; i < len; i++)

int main()
{
    printf("Dose ton arithmo ton kathigiton: ");
    int len = GetInteger();
    teacher_t teachers[len];

    FOR
    {
        printf("\n");
        printf("Dose ta stoixeia tou kathigiti %d\n", i);
        get_data(&teachers[i]);

        calc_salaries(&teachers[i]);
    }

    printf("\n\n");
    printf("Name            Surname              Hourly Rate   Hours Worked     Gross  Deductions     Tax     Net\n");
    printf("-----------------------------------------------------------------------------------------------------\n");
    FOR print_data(&teachers[i]);
}
