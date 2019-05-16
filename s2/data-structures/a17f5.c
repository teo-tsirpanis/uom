//                  (*APOKWDIKOPOIHSH KWDIKWN Huffman*)

// filename : HuffmanDecoding;

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct
{
    char data[21];
} BinTreeElementType; /*ΤΥΠΟΣ ΔΕΔΟΜΕΝΩΝ ΠΟΥ ΑΠΟΘΗΚΕΥΟΝΤΑΙ ΣΤΟΥΣ
                                            ΚΟΜΒΟΥΣ ΤΟΥ ΔΕΝΔΡΟΥ Huffman */
typedef struct BinTreeNode *BinTreePointer;
struct BinTreeNode
{
    BinTreeElementType Data;
    BinTreePointer LChild, RChild;
};

typedef enum
{
    FALSE,
    TRUE
} boolean;

void AddToTree(char *ch, char code[], int codelen, BinTreePointer *Root)
/* ΔΕΧΕΤΑΙ: ΕΝΑ ΧΑΡΑΚΤΗΡΑ ch, ΕΝΑ string code, ΕΝΑ ΑΚΕΡΑΙΟ codelen (ΜΗΚΟΣ ΤΟΥ
            string code) ΚΑΙ ΤΟ ΔΕΙΚΤΗ Root ΠΟΥ ΔΕΙΧΝΕΙ ΤΗ ΡΙΖΑ ΤΟΥ ΔΕΝΔΡΟΥ Huffman
  ΛΕΙΤΟΥΡΓΙΑ: ΔΗΜΙΟΥΡΓΕΙ ΕΝΑΝ ΚΟΜΒΟ ΜΕ ΠΕΡΙΕΧΟΜΕΝΟ ΤΟ ΧΑΡΑΚΤΗΡΑ ch
                ΤΟΥ ΟΠΟΙΟΥ Ο ΚΩΔΙΚΟΣ ΕΙΝΑΙ code ΜΗΚΟΥΣ codelen ΚΑΙ ΤΟΝ
                ΠΡΟΣΘΕΤΕΙ ΣΤΟ ΔΕΝΔΡΟ Huffman
  ΕΠΙΣΤΡΕΦΕΙ: ΤΟ ΤΡΟΠΟΠΟΙΗΜΕΝΟ ΔΕΝΔΡΟ Huffman, ΠΟΥ ΔΕΙΚΤΟΔΟΤΕΙΤΑΙ ΑΠΟ ΤΟ ΔΕΙΚΤΗ Root
*/
{
    int i;
    BinTreePointer TempPtr, p;
    i = 0;
    p = *Root;
    while (i < codelen)

        if (code[i] == '0')
        {
            if (p->LChild == NULL)
            {
                TempPtr = (BinTreePointer)malloc(sizeof(struct BinTreeNode));
                TempPtr->LChild = NULL;
                TempPtr->RChild = NULL;
                p->LChild = TempPtr;
            }
            i = i + 1;
            p = p->LChild;
        }
        else if (code[i] == '1')
        {
            if (p->RChild == NULL)
            {
                TempPtr = (BinTreePointer)malloc(sizeof(struct BinTreeNode));
                TempPtr->LChild = NULL;
                TempPtr->RChild = NULL;
                p->RChild = TempPtr;
            }
            i = i + 1;
            p = p->RChild;
        }
    strcpy(p->Data.data, ch);
}

void BuildDecodingTree(BinTreePointer *Root, FILE *CodeFile)
/* ΔΕΧΕΤΑΙ:    ΤΟ ΑΡΧΕΙΟ CodeFile
   ΛΕΙΤΟΥΡΓΘΑ: ΔΙΑΒΑΖΕΙ ΤΟΥΣ ΧΑΡΑΚΤΗΡΕΣ ΚΑΙ ΤΟΥΣ ΚΩΔΙΚΟΥΣ ΤΟΥΣ ΑΠΟ ΤΟ ΑΡΧΕΙΟ
                CodeFile ΚΑΙ ΚΑΤΑΣΚΕΥΑΖΕΙ ΤΟ ΔΕΝΔΡΟ Huffman.
   ΕΠΙΣΤΡΕΦΕΙ: ΤΟ ΔΕΙΚΤΗ Root ΠΟΥ ΔΕΙΧΝΕΙ ΣΤΗ ΡΙΖΑ ΤΟΥ ΔΕΝΔΡΟΥ Huffman.
*/
{
    char termch;
    char ch[21];
    char code[10];
    int nscan;

    (*Root) = (BinTreePointer)malloc(sizeof(struct BinTreeNode));
    (*Root)->LChild = NULL;
    (*Root)->RChild = NULL;
    while (TRUE)
    {
        nscan = fscanf(CodeFile, "%20[^\n] %10[^\n]%c", ch, code, &termch);
        if (nscan == EOF)
            break;
        if (nscan != 3 || termch != '\n')
        {
            printf("Improper file format\n");
            break;
        }
        else
            AddToTree(ch, code, strlen(code), &(*Root));
    }
}

void Decode(BinTreePointer Root, FILE *MessageFile)
/* Δέχεται: Ένα δέντρο Huffman και μια ακολουθία από bits που αναπαριστά ένα μήνυμα,
            το οποίο έχει κωδικοποηθεί με χρήση του δέντρου Huffman.
  Λειτουργία:  Αποκωδικοποιεί το μήνυμα.
  Επιστρέφει: Το αποκωδικοποιημένο μήνυμα.*)
*/
{
    char bit;
    BinTreePointer p;

    while (TRUE)
    {
        p = Root;
        while (p->LChild != NULL || p->RChild != NULL)
        {
            bit = fgetc(MessageFile);
            if (bit != EOF)
            {
                printf("%c", bit);
                if (bit == '0')
                    p = p->LChild;
                else if (bit == '1')
                    p = p->RChild;
                else if (bit != '\n')
                    printf("MH APODEKTO bit: %c\n", bit);
            }
            else
                break;
        }
        if (bit != EOF)
            printf("---%s\n", p->Data.data);
        else
            break;
    }
}

int main()
{
    FILE *CodeFile, *MessageFile;
    BinTreePointer Root;

    CodeFile = fopen("CODESRW.TXT", "r");
    if (CodeFile == NULL)
        printf("Can't open CODESRW.TXT\n");
    else
    {
        BuildDecodingTree(&Root, CodeFile);
        MessageFile = fopen("program.txt", "r");
        if (MessageFile == NULL)
            printf("Can't open program.txt\n");
        else
            Decode(Root, MessageFile);
    }

    return 0;
}
