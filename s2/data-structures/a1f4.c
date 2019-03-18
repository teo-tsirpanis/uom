#include <stdio.h>
#include "adt-libraries/L_ListADT.c"

void Search(ListPointer freePtr, // UNUSED
            ListPointer list,
            NodeType nodes[NumberOfNodes],
            ListElementType itemToFind,
            boolean *found,
            ListPointer *prevPtr)
{
    *prevPtr = NilValue;
    ListPointer n = nodes[*prevPtr].Next;
    while (n != NilValue) {
        if (nodes[n].Data == itemToFind)
        {
            *found = TRUE;
            return;
        }
        *prevPtr = n;
        n = nodes[*prevPtr].Next;
    }
}
