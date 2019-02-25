#include <stdio.h>
#include "adt-libraries/StackADT.c"

StackElementType GetTopElementA(StackType *stack)
{
    StackElementType x;
    Pop(stack, &x);
    Push(stack, x);
    return x;
}

StackElementType GetTopElementB(StackType *stack)
{
    return stack->Element[stack->Top];
}

#define PRINT_TOP(x) printf("Showing the top element with GetTopElement" #x ": %d\n", GetTopElement ## x (&stack));

int main()
{
    StackType stack;
    CreateStack(&stack);

    for (int i = 1; i < 100; i += 2)
        Push(&stack, i);

    PRINT_TOP(A);
    PRINT_TOP(B);

    return 0;
}
