#include <stdio.h>
#include "simpio.h"

typedef struct
{
    int width;
    int height;
    int depth;
    int area;
    int volume;
} box_t;

#define PROMPT_BOX(descr, field)                         \
    {                                                    \
        printf("Dose to " descr " tou koutiou se cm: "); \
        box->field = GetInteger();                       \
    }

void readBox(box_t *box)
{
    PROMPT_BOX("mikos", width);
    PROMPT_BOX("ypsos", height);
    PROMPT_BOX("vathos", depth);
    box->area = 0;
    box->volume = 0;
}

void calculateArea(box_t *box)
{
    box->area = box->width * box->height + box->height * box->depth + box->depth * box->width;
    box->area *= 2;
}

void calculateVolume(box_t *box)
{
    box->volume = box->width * box->height * box->depth;
}

int main()
{
    box_t box;

    readBox(&box);
    calculateArea(&box);
    calculateVolume(&box);

    printf("To emvadon tou koutiou einai %d cm2\n", box.area);
    printf("O ogos tou koutiou einai %d cm3\n", box.volume);

    return 0;
}
