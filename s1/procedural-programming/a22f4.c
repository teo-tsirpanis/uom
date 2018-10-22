#include "simpio.h"
#include <stdio.h>

int tryGetVATCategoryToRate(int cat, float *VATRate)
{
    switch (cat)
    {
    case 1:
        *VATRate = 0.00;
        break;
    case 2:
        *VATRate = 0.06;
        break;
    case 3:
        *VATRate = 0.13;
        break;
    case 4:
        *VATRate = 0.19;
        break;
    default:
        return 0;
    }
    return 1;
}

float calculateVAT(int price, float VAT)
{
    return (float)price * VAT;
}

/* The price is an integer, as the exercise mandates. */
int calculatePrice(int pricePerProduct, int quantity)
{
    return pricePerProduct * quantity;
}

#define NUM_TIMES 5

int main()
{
    int totalPrice = 0;
    float totalVAT = 0.0;

    int i;
    for (i = 1; i <= NUM_TIMES; i++)
    {
        printf("Dwse to plithos temaxiwn apo to proion %d: ", i);
        int quantity = GetInteger();
        printf("Dwse timi gia to proion %d: ", i);
        int pricePerProduct = GetInteger();
        printf("Dwse  katigoria FPA gia to proion %d: ", i);
        int productCategory = GetInteger();

        float VATRate;

        if (tryGetVATCategoryToRate(productCategory, &VATRate))
        {
            int price = calculatePrice(pricePerProduct, quantity);
            totalPrice += price;
            totalVAT += calculateVAT(price, VATRate);
        }
        else
            printf("Lathos katigoria FPA\n");
    }

    printf("Synoliko kostos: %.2f\n", (float)totalPrice + totalVAT);
    printf("Synoliko fpa: %.2f\n", totalVAT);
}
