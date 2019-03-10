#include <stdio.h>
#include "adt-libraries/QueueADT.c"

#define MOVE(q1, q2, doPrint) \
    while (!EmptyQ(*q1))      \
    {                         \
        QueueElementType x;   \
        RemoveQ(q1, &x);      \
        if (doPrint)          \
            printf("%d ", x); \
        AddQ(q2, x);          \
    }

void DisplayQA(QueueType *Q)
{
    QueueType Q2;
    CreateQ(&Q2);

    MOVE(Q, &Q2, TRUE);
    MOVE(&Q2, Q, FALSE);
}

void DisplayQB(QueueType Q)
{
    for (int i = Q.Front; i != Q.Rear; i = (i + 1) % QueueLimit)
        printf("%d ", Q.Element[i]);
}

#define DISPLAY_Q(x, q)                                       \
    {                                                         \
        printf("Displaying the queue with DisplayQ" #x ": "); \
        DisplayQ##x(q);                                       \
        printf("\n");                                         \
    }

int main()
{
    QueueType q;
    CreateQ(&q);

    for (int i = 1; i < 100; i += 2)
        AddQ(&q, i);

    DISPLAY_Q(A, &q)
    DISPLAY_Q(B, q)
}
