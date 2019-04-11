#include "adt-libraries/StackPADT.c"

boolean shouldLoad(StackPointer truck, StackElementType item, double value)
{
    if (value < 0.0)
        return FALSE;
    else if (!EmptyStack(truck) && truck->Data >= item)
        return TRUE;
    else
        return shouldLoad(truck->Next, item, value - 300.0 * truck->Data);
}

double getTotalWeight(StackPointer x)
{
    if (EmptyStack(x))
        return 0.0;
    else
        return x->Data + getTotalWeight(x->Next);
}

void copy(StackPointer *src, StackPointer *dest)
{
    while (!EmptyStack(*src))
    {
        StackElementType x;
        Pop(src, &x);
        Push(dest, x);
    }
}

void dumpStack(StackPointer s)
{
    while (!EmptyStack(s))
    {
        printf("%f ", s->Data);
        s = s->Next;
    }
    printf("STACK ENDED\n");
}

StackPointer load(StackPointer truck, StackElementType item)
{
    StackPointer platform;
    CreateStack(&platform);
    while (!EmptyStack(truck) && truck->Data < item)
    {
        StackElementType x;
        Pop(&truck, &x);
        Push(&platform, x);
    }
    Push(&truck, item);

    printf("Platform: ");
    dumpStack(platform);
    printf("Truck: ");
    dumpStack(truck);

    copy(&platform, &truck);

    return truck;
}

int main()
{
    double value, weight;
    StackPointer truck;
    CreateStack(&truck);
    Push(&truck, 3.0);
    Push(&truck, 2.0);
    Push(&truck, 1.0);
    Push(&truck, 0.5);
    Push(&truck, 0.4);

    while (637)
    {
        printf("Give the weight: ");
        scanf("%lf", &weight);
        printf("Give the value: ");
        scanf("%lf", &value);
        if (weight < 0.0 || value < 0.0)
            break;

        if (shouldLoad(truck, weight, value))
        {
            if (getTotalWeight(truck) + weight <= 10.0)
                truck = load(truck, weight);
            else
                printf("Insufficient weight!\n");
        }
        else
            printf("Not enough value!\n");
    }

    return 0;
}
