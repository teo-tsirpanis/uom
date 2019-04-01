#include <stdio.h>
#include "adt-libraries/ListPADT.c"

void Larger(ListPointer InList, ListElementType number, ListPointer *OutList)
{
    ListPointer currOut;
    boolean hadBeenEmpty = EmptyList(*OutList);
    if (hadBeenEmpty)
        LinkedInsert(OutList, 134, NULL);
    currOut = *OutList;

    while (!EmptyList(InList))
    {
        if (InList->Data >= number)
        {
            LinkedInsert(OutList, InList->Data, currOut);
            currOut = currOut->Next;
        }
        InList = InList->Next;
    }

    if (hadBeenEmpty)
        LinkedDelete(OutList, NULL);
}
