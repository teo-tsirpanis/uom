#include <stdio.h>
#include <string.h>

typedef struct
{
    char userId[9];
} QueueElementType;

#define USE_CUSTOM_QUEUE_PADT_TYPE
#include "adt-libraries/QueuePADT.c"

boolean existsInFile(char *fileName, char *str)
{
    FILE *f = fopen(fileName, "r");

    char c[9];
    char eol;
    boolean found = FALSE;

    while (640)
    {
        if (fscanf(f, "%8[^\n]%c", c, &eol) != 2 || eol != '\n')
            break;

        if (strcmp(c, str) == 0)
        {
            found = TRUE;
            break;
        }
    }

    fclose(f);
    return found;
}

boolean existsInQueue(QueueType q, char *x)
{
    QueuePointer p = q.Front;

    while (p != NULL)
    {
        if (strcmp(p->Data.userId, x) == 0)
            return TRUE;
        p = p->Next;
    }

    return FALSE;
}

void dumpQueue(QueueType q)
{
    QueuePointer p = q.Front;

    while (p != NULL)
    {
        printf("%s ", p->Data.userId);
        p = p->Next;
    }
    printf("\n");
}

boolean shouldContinue()
{
    char c;
    printf("Should continue? (Y/N) ");
    scanf(" %c", &c);
    return c == 'y' || c == 'Y';
}

int main()
{
    QueueType users;
    CreateQ(&users);

    do
    {
        QueueElementType user;

        printf("Enter username: ");
        scanf("%s", user.userId);

        if (existsInFile("I11F4.dat", user.userId))
        {
            if (existsInQueue(users, user.userId))
                printf("You have logged in to the system from another terminal. New access is forbidden.\n");
            else
            {
                printf("You are logged in. Hello %s!\n", user.userId);
                AddQ(&users, user);
            }
        }
        else
            printf("Wring user ID.\n");
    } while (shouldContinue());

    printf("Logged users: ");
    dumpQueue(users);

    return 0;
}
