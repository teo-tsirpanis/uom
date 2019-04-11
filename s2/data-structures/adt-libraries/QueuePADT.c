// QueuePADT.c
                        /*ΥΛΟΠΟΙΗΣΗ ΟΥΡΑΣ ΔΥΝΑΜΙΚΑ ΜΕ ΔΕΙΚΤΕΣ*/
                        
#include <stdio.h>
#include <stdlib.h>

#ifndef USE_CUSTOM_QUEUE_PADT_TYPE
typedef int QueueElementType;
#endif

typedef struct QueueNode *QueuePointer;

typedef struct QueueNode
{
	QueueElementType Data;
    QueuePointer Next;
} QueueNode;

typedef struct
{
    QueuePointer Front;
    QueuePointer Rear;
} QueueType;

typedef enum {
    FALSE, TRUE
} boolean;

void CreateQ(QueueType *Queue)
/* Λειτουργία: Δημιουργεί μια κενή συνδεδεμένη ουρά. 
   Επιστρέφει: Μια κενή συνδεδεμένη ουρά 
*/
{
	Queue->Front = NULL;
	Queue->Rear = NULL;
}

boolean EmptyQ(QueueType Queue)
/* Δέχεται:    Μια συνδεδεμένη ουρά. 
   Λειτουργία: Ελέγχει αν η συνδεδεμένη ουρά είναι κενή. 
   Επιστρέφει: True αν η ουρά είναι κενή, false  διαφορετικά 
*/
{
	return (Queue.Front==NULL);
}

void AddQ(QueueType *Queue, QueueElementType Item)
/* Δέχεται:    Μια συνδεδεμένη ουρά Queue και ένα  στοιχείο Item.
   Λειτουργία: Προσθέτει το στοιχείο Item στο τέλος της συνδεδεμένης ουράς Queue.
   Επιστρέφει: Την τροποποιημένη ουρά
*/
{
	QueuePointer TempPtr;

    TempPtr= (QueuePointer)malloc(sizeof(struct QueueNode));
    TempPtr->Data = Item; 
    TempPtr->Next = NULL;
    if (Queue->Front==NULL) 
        Queue->Front=TempPtr;
    else
        Queue->Rear->Next = TempPtr;
    Queue->Rear=TempPtr;
}

void RemoveQ(QueueType *Queue, QueueElementType *Item)
/* Δέχεται:    Μια συνδεδεμένη ουρά. 
   Λειτουργία: Αφαιρεί το στοιχείο Item από την  κορυφή της συνδεδεμένης ουράς, 
                αν δεν είναι  κενή. 
   Επιστρέφει: Το στοιχείο Item και την τροποποιημένη συνδεδεμένη ουρά. 
   Έξοδος:     Μήνυμα κενής ουράς, αν η ουρά είναι  κενή 
*/
{
    QueuePointer TempPtr;
    
    if (EmptyQ(*Queue)) {
   	    printf("EMPTY Queue\n");
    }
   else
   {
        TempPtr = Queue->Front;
        *Item=TempPtr->Data;
        Queue->Front = Queue->Front->Next;     
        free(TempPtr);
        if (Queue->Front==NULL) Queue->Rear=NULL;
    }   
}



