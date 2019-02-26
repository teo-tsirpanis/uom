#include <stdio.h>
#define STACK_ELEMENT_TYPE char
#include "adt-libraries/StackADT.c"

void TraverseStack(StackType Stack)
{
    printf("plithos sto stack %d\n", Stack.Top + 1);
    for (int i = 0; i <= Stack.Top; i++)
        printf("%c, ", Stack.Element[i]);
    printf("\n");
}

#define PRINT_STACK(x)         \
    printf("\nStack" #x "\n"); \
    TraverseStack(stack##x);

#define COPY(src, dest)             \
    while (!EmptyStack(stack##src)) \
    {                               \
        StackElementType x;                     \
        Pop(&stack##src, &x);       \
        Push(&stack##dest, x);      \
    }

int main()
{
    StackType stack1, stack2, stack3;
    CreateStack(&stack1);
    CreateStack(&stack2);
    CreateStack(&stack3);

    char *s = "PASCAL";
    for (int i = 0; i < 6; i++)
        Push(&stack1, s[i]);
    PRINT_STACK(1);

    COPY(1, 2);
    PRINT_STACK(2);

    COPY(2, 3);
    PRINT_STACK(3);

    COPY(3, 1);
    PRINT_STACK(1);

    return 0;
}
