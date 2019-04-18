#include <stdio.h>
#include <string.h>
#include "adt-libraries/BstRecADT.c"

int max(int x1, int x2) {
    if (x1 > x2)
        return x1;
    else
        return x2;
}

int BSTDepth(const BinTreePointer tree) {
    if (BSTEmpty(tree))
        return 0;
    else
        return max(BSTDepth(tree->LChild), BSTDepth(tree->RChild)) + 1;
}

int main()
{
    BinTreePointer tree;

    CreateBST(&tree);

    char *c = "PROCEDURE";
    int len = strlen(c);

    for (int i = 0; i < len; i++)
        RecBSTInsert(&tree, c[i]);

    int depth = BSTDepth(tree);

    printf("The depth of the tree containing \"PROCEDURE\" is %d\n", depth);

    return 0;
}
