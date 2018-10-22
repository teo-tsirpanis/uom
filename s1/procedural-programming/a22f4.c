#include "simpio.h"
#include <stdio.h>

int getVATCategoryToRate (int cat, float* VATRate)
{
    switch (cat) {
        case 1: *VATRate = 0.00; break;
        case 2: *VATRate = 0.06; break;
        case 3: *VATRate = 0.13; break;
        case 4: *VATRate = 0.19; break;
        default: return 0;
    }
    return 1;
}

float calculateVAT (int price, float VAT)
{
    return (float) price * VAT;
}

/* The price is an integer, as the exercise mandates. */
int calculatePrice (int pricePerProduct, int quantity)
{
    return pricePerProduct * quantity;
}

#define

int main()
{
    int totalPrice = 0;
    float totalVAT = 0.0;

    int i;
    for (i = 0; i < NUM_TIMES; i++)
    {
        printf("Dwse to plithos temaxiwn apo to proion %d: ", i);
        int quantity = GetInteger();
        printf("Dwse timi gia to proion %d: ", i);
        int price = GetInteger();

    }
}
