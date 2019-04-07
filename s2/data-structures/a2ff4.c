#include <stdio.h>
#include "adt-libraries/ListPADT.c"

void DeleteLastLL(ListPointer *List)
{
    if (EmptyList(*List))
        return;

    ListPointer prev = NULL;
    ListPointer curr = *List;

    while (curr->Next != NULL)
    {
        prev = curr;
        curr = prev->Next;
    }

    LinkedDelete(List, prev);
}
