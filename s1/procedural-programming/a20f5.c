#include "simpio.h"
#include <string.h>

#define REPEAT for (int i = 0; i < 5; i++)

int main()
{
    int data[5];

    REPEAT {printf("Enter number:"); data[i] = GetInteger();};
    int last = data[4];
    memmove(&data[1], &data[0], 4 * sizeof(int));
    data[0] = last;
    REPEAT printf("%d ", data[i]);
    printf("\n");

    return 0;
}
