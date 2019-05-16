#include "adt-libraries/BstRecADT.c"

int RightNodeCount(BinTreePointer Root)
{
    if (Root == NULL)
        return 0;
    else
        return RightNodeCount(Root->LChild) + RightNodeCount(Root->RChild) + (Root->RChild != NULL);
}

int main()
{
    BinTreePointer tree;
    CreateBST(&tree);

    printf("Enter numbers to insert into tree (-1 to stop)\n");
    while (TRUE)
    {
        printf("Enter number: ");

        int choice;
        scanf("%d", &choice);

        if (choice != -1)
            RecBSTInsert(&tree, choice);
        else
            break;
    }

    printf("RightNodeCount = %d\n", RightNodeCount(tree));

    return 0;
}
