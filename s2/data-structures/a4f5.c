#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include "adt-libraries/BstADT.c"

char randomChar()
{
    return rand() % 26 + 'A';
}

void insertRandomChars(BinTreePointer *tree, unsigned int n)
{
    for (unsigned int i = 0; i < n; i++)
    {
        char c = randomChar();
        printf("Inserting %c...\n", c);
        BSTInsert(tree, c);
    }
}

void preOrderTraversal(BinTreePointer tree)
{
    if (!EmptyBST(tree))
    {
        printf("%c ", tree->Data);
        preOrderTraversal(tree->LChild);
        preOrderTraversal(tree->RChild);
    }
}

int main()
{
    unsigned int n;
    BinTreePointer tree;

    srand(time(NULL));
    CreateBST(&tree);
    printf("Give the number of letters? ");
    scanf("%u", &n);
    insertRandomChars(&tree, n);

    printf("The resulting tree's in-order representation is: ");
    InorderTraversal(tree);
    printf("\n");
    printf("The resulting tree's pre-order representation is: ");
    preOrderTraversal(tree);

    return 0;
}
