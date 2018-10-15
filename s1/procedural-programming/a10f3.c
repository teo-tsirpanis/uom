#include <stdio.h>

#define print(x) printf("%4d", x)

int main()
{
    for (int i = 1; i <= 10; i++)
    {
        print(i);
        for (int j = 1; j <= 10; j++)
            print(i * j);
        printf("\n");
        /* Better than puts("").
        As seen in https://godbolt.org/z/4Jfvbv, with -O3,
        the compiler optimizes the printf down to a
        mov     edi, 10
        add     r12d, 1
        call    putchar
        which writes just a single Line Feed character to stdout.
        */
    }
    return 0;
}