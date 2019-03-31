#include <stdio.h>
#include "adt-libraries/L_ListADT.c"

void Search(ListPointer freePtr, // UNUSED
            ListPointer list,
            NodeType nodes[NumberOfNodes],
            ListElementType itemToFind,
            boolean *found,
            ListPointer *prevPtr)
{
  *found = FALSE;
  if (EmptyLList(list))
    return;
  *prevPtr = NilValue;
  ListPointer n = nodes[*prevPtr].Next;
  while (n != NilValue)
  {
    if (nodes[n].Data >= itemToFind)
    {
      *found = nodes[n].Data == itemToFind;
      return;
    }
    *prevPtr = n;
    n = nodes[*prevPtr].Next;
  }
}
