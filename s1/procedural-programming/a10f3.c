#include <stdio.h>

int main()
{
    for (int i = 1; i <= 10; i++)
    {
        printf("%4d", i);
        for (int j = 1; j <= 10; j++)
            printf("%4d", i * j);
        puts("");
    }
    return 0;
}