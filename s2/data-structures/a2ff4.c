#include <stdio.h>
#include "adt-libraries/ListPADT.c"

void DeleteLastLL(ListPointer *List)
{
    if (EmptyList(*List))
        return;

    ListPointer prev = *List;
    ListPointer curr = prev->Next;

    while (curr != NULL)
    {
        prev = curr;
        curr = prev->Next;
    }

    LinkedDelete(List, prev);
}
