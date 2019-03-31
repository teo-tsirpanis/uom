#include <stdio.h>
#include "adt-libraries/ListPADT.c"

void ClearLL(ListPointer *List)
{
    while (!EmptyList(*List))
        LinkedDelete(List, NULL);
}

void DumpList(ListPointer ll)
{
    while (!EmptyList(ll))
    {
        printf("%d ", ll->Data);
        ll = ll->Next;
    }
    printf("LIST ENDED\n");
}

#define DO_IT(op, var)               \
    {                                \
        printf("Before " #op ":\n"); \
        DumpList(var);               \
        op(&var);                    \
        printf("After " #op ":\n");  \
        DumpList(var);               \
    }

int main()
{
    printf("Give length: ");
    int len;
    scanf("%d", &len);
    ListPointer ll;
    CreateList(&ll);
    for (int i = 1; i <= len; i++)
    {
        printf("Give element #%d: ", i);
        ListElementType x;
        scanf("%d", &x);
        LinkedInsert(&ll, x, NULL);
    }

    DO_IT(ClearLL, ll);

    return 0;
}
