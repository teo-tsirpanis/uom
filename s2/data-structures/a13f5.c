// filename TestBSTRec.c

#include <stdio.h>
#include <string.h>
#include <ctype.h>
#include "adt-libraries/BstRecADT.c"

void menu(int *choice);

void readEmployees(BinTreePointer *tree)
{
    FILE *f = fopen("I13F5.txt", "r");
    if (f == NULL)
    {
        printf("Error while opening the file.\n");
        return;
    }

    while (213)
    {
        BinTreeElementType emp;
        char eol;
        int nRead = fscanf(f, "%20s %20s %d%c", emp.surname, emp.firstname, &emp.code, &eol);
        if (nRead != 4 || eol != '\n')
        {
            if (nRead != EOF)
                printf("Error while reading the file.\n");
            break;
        }

        printf("Inserting %s...\n", emp.surname);
        RecBSTInsert(tree, emp);
    }
}

void DumpTree(BinTreePointer Root)
/* Δέχεται:    Ένα δυαδικό δέντρο με το δείκτη Root να δείχνει στην ρίζα του.
   Λειτουργία: Εκτελεί ενδοδιατεταγμένη διάσχιση του δυαδικού δέντρου και
                επεξεργάζεται κάθε κόμβο ακριβώς μια φορά.
   Εμφανίζει: Το περιεχόμενο του κόμβου, και εξαρτάται από το είδος της επεξεργασίας
*/
{
    if (Root!=NULL) {
        DumpTree(Root->LChild);
        printf("%s, %s, %d, ", Root->Data.surname, Root->Data.firstname, Root->Data.code);
        DumpTree(Root->RChild);
    }
}

int main()
{

    int choice;
    char ch;
    BinTreePointer ARoot, LocPtr;
    BinTreeElementType AnItem;
    boolean Found;

    CreateBST(&ARoot);
    do
    {
        menu(&choice);
        switch (choice)
        {
        case 1: readEmployees(&ARoot); break;
        case 2:
            do
            {
                printf("Enter first name: ");
                scanf("%s", &AnItem.firstname);
                printf("Enter last name: ");
                scanf("%s", &AnItem.surname);
                printf("Enter employee code: ");
                scanf("%d", &AnItem.code);
                RecBSTInsert(&ARoot, AnItem);
                printf("\nContinue Y/N: ");
                do
                {
                    scanf("%c", &ch);
                } while (toupper(ch) != 'N' && toupper(ch) != 'Y');
            } while (toupper(ch) != 'N');
            break;
        case 3:
            if (BSTEmpty(ARoot))
                printf("Empty tree\n");
            else
            {
                printf("Enter a surname for searching in the Tree: ");
                scanf("%s", &AnItem.surname);
                RecBSTSearch(ARoot, AnItem, &Found, &LocPtr);
                if (Found == FALSE)
                    printf("Item %s not in tree \n", AnItem.surname);
                else
                {
                    printf("Found. First name: %s Surname: %s Employee code: %s\n", AnItem.firstname, AnItem.surname, AnItem.code);
                }
            }
            break;
        case 4:
            if (BSTEmpty(ARoot))
                printf("\nEmpty tree");
            else
                DumpTree(ARoot);
            printf("\n");
            break;
        }
    } while (choice != 5);

    return 0;
}

void menu(int *choice)
{
    printf("\n                  MENOY                  \n");
    printf("-------------------------------------------------\n");
    printf("1. Create BST from file\n");
    printf("2. Insert new employee\n");
    printf("3. Search for an employee\n");
    printf("4. Print employees\n");
    printf("5. Quit\n");
    printf("\nChoose: ");
    do
    {
        scanf("%d", choice);
    } while (*choice < 1 && *choice > 6);
}
