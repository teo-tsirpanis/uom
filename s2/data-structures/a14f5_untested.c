#include <stdio.h>
#define USE_BST_EMPLOYEE
#include "adt-libraries/BstAdt.c"

#define INPUT_FILE "I14F5.TXT"

void FreeBST(BinTreePointer *tree)
{
    printf("Cleaning the tree...\n");
    while (!EmptyBST(*tree))
        BSTDelete(tree, (*tree)->Data);
}

void printTeacher(const BinTreeElementType *emp)
{
    printf("Teacher found: %s, %s, %d\n", emp->name, emp->telephone, emp->speciality);
}

typedef boolean (*TeacherPredicate)(const BinTreeElementType *, void *);

void InOrderTraversalConditional(BinTreePointer tree, TeacherPredicate pred, void *arg)
{
    if (!EmptyBST(tree))
    {
        InOrderTraversalConditional(tree->LChild, pred, arg);
        if (pred(&tree->Data, arg))
            printTeacher(&tree->Data);
        InOrderTraversalConditional(tree->RChild, pred, arg);
    }
}

void readTeachers(BinTreePointer *tree)
{
    FILE *f = fopen(INPUT_FILE, "r");
    if (f == NULL)
    {
        printf("Error while opening the file.\n");
        return;
    }

    if (!EmptyBST(*tree))
        FreeBST(tree);

    while (213)
    {
        BinTreeElementType emp;
        char eol;
        int nRead = fscanf(f, "%20[^,], %10[^,], %d%c", emp.name, emp.telephone, &emp.speciality, &eol);
        if (nRead != 4 || eol != '\n')
        {
            if (nRead != EOF)
                printf("Error while reading the file.\n");
            break;
        }

        printf("Inserting %s...\n", emp.name);
        BSTInsert(tree, emp);
    }
}

void insertTeacher(BinTreePointer *tree)
{
    BinTreeElementType emp;

    printf("Enter teacher's name (<surname> <first name>): ");
    scanf("%s", emp.name);
    printf("Enter teacher's telephone number: ");
    scanf("%s", emp.telephone);
    printf("Enter teacher's speciality code: ");
    scanf("%d", &emp.speciality);

    BSTInsert(tree, emp);
}

void deleteTeacher(BinTreePointer *tree)
{
    BinTreeElementType emp = {"", "", 0};

    printf("Enter teacher's name (<surname> <first name>): ");
    scanf("%s", emp.name);

    BSTDelete(tree, emp);
}

void lookupTeacher(const BinTreePointer tree)
{
    BinTreeElementType emp = {"", "", 0};

    BinTreePointer result;

    printf("Enter the teacher name to look up for (<surname> <first name>): ");
    scanf("%s", emp.name);

    boolean found;
    BSTSearch(tree, emp, &found, &result);

    if (found)
        printTeacher(&result->Data);
    else
        printf("Teacher NOT found.\n");
}

boolean specialityCodeEquals(const BinTreeElementType *emp, void *sc)
{
    return emp->speciality == *((int *)sc);
}

void searchBySpecialityCode(const BinTreePointer tree)
{
    printf("Enter the speciality code the teachers of which to show: ");
    int sc;
    scanf("%d", &sc);

    InOrderTraversalConditional(tree, specialityCodeEquals, &sc);
}

boolean myYesMan(const BinTreeElementType *_not_used, void *_at_all)
{
    return TRUE;
}

void printAllTeachers(const BinTreePointer tree)
{
    InOrderTraversalConditional(tree, myYesMan, NULL);
}

boolean promptUserAction(boolean isTreeEmpty, int *action)
{
    printf("----------------------------MENU----------------------------\n\n");
    printf("1. Create a new teacher binary search tree with data from " INPUT_FILE);
    if (!isTreeEmpty)
        printf(" (and delete the existing one)");
    printf(".\n");

    printf("2. Insert a new teacher.\n");
    printf("3. Delete a teacher.\n");
    printf("4. Search for a teacher based on his name.\n");
    printf("5. Print all teachers by their speciality code.\n");
    printf("6. Print all teachers.\n");
    printf("7. Quit\n");

    printf("\n");
    do
    {
        printf("Enter your choice: ");
        scanf("%d", action);
    } while (*action < 1 || *action > 7);

    return *action != 7; // Whether to keep running.
}

void routeUserAction(BinTreePointer *tree, int action)
{
    switch (action)
    {
        case 1:
            readTeachers(tree);
            break;
        case 2:
            insertTeacher(tree);
            break;
        case 3:
            deleteTeacher(tree);
            break;
        case 4:
            lookupTeacher(*tree);
            break;
        case 5:
            searchBySpecialityCode(*tree);
            break;
        case 6:
            printAllTeachers(*tree);
            break;
        default:
            break;
    }
}

int main()
{
    BinTreePointer tree;
    CreateBST(&tree);

    int action;
    while (promptUserAction(EmptyBST(tree), &action))
    {
        routeUserAction(&tree, action);
        printf("\n");
    }

    return 0;
}
