#include <stdio.h>
#include "adt-libraries/QueueADT.c"
#include "adt-libraries/StackADT.c"

#define MOVE(q1, t1, remove1, q2, add2) \
    while (!Empty##t1(*q1))             \
    {                                   \
        QueueElementType x;             \
        remove1(q1, &x);                \
        add2(q2, x);                    \
    }

void ReverseQ(QueueType *Q)
{
    StackType S;
    CreateStack(&S);

    MOVE(Q, Q, RemoveQ, &S, Push);
    MOVE(&S, Stack, Pop, Q, AddQ);
}

void DisplayQ(const QueueType *Q)
{
    for (int i = Q->Front; i != Q->Rear; i = (i + 1) % QueueLimit)
        printf("%d ", Q->Element[i]);
    printf("\n");
}

int main()
{
    QueueType q;
    CreateQ(&q);

    for (int i = 2; i <= 30; i += 2)
        AddQ(&q, i);

    DisplayQ(&q);
    ReverseQ(&q);
    DisplayQ(&q);
}