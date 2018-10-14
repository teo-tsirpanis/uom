#include <assert.h>
#include <stdio.h>

/* Using a lookup table, the compiler will not generate
jump assembly instructions, improving performance.
As shown in https://godbolt.org/z/Ar4xI3, GCC yields only two
"jle" instructions, but they are for the purpose of the assertion.
When compiled with "-O3", there is only one "ja" instruction.
So, there is just one jump instruction instead of seven, and the CPU's branch
predictor would have much less opportunities to adversely affect performance. */
static char *daysLookup[7] = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};

char *getDay(int num)
{
    /* The exercise's statement does nowhere specify what would happen if
    the number is not between 1 and 7 (inclusive). But in this case,
    it would cause a nasty out-of-bounds memory access. */
    assert(num >= 1 && num <= 7);
    return daysLookup[num - 1];
}

int main()
{
    int num = 0;

    printf("Dwse enan arithmo apo to 1 eos to 7: ");
    scanf("%d", &num);

    char *day = getDay(num);

    printf("The day is %s", day);

    return 0;
}
