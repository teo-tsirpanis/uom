/*
    This source file is the product of a
    joint collaborative effort between
    * Sotiris Sotiriou (dai19052)
    * Theodore Tsirpanis (dai19090)
    which was born when the latter came late
    and sat next to the former's computer.
*/

#include <stdio.h>
#include <math.h>
#include "genlib.h"
#include "simpio.h"

#define SALESMEN 4
#define PRODUCTS 5

#define FOR(i, l) for (int i = 0; i < l; i++)

void calculateSales(int salesmen, int products, int price[products], int salesTable[salesmen][products], int sp[salesmen])
{
    FOR(i, salesmen)
    {
        sp[i] = 0;
        FOR(j, products)
            sp[i] += salesTable[i][j] * price[j];
    }
}

void calculateProductSales(int salesmen, int productcount, int salesTable[salesmen][productcount], int products[productcount])
{
    FOR(i, productcount)
    {
        products[i] = 0;
        FOR(j, salesmen)
            products[i] += salesTable[j][i];
    }
}

int maxArray(int length, int data[length])
{
    int m = 0;
    for (int i = 1; i < length; i++)
        if (data[i] > data[m])
            m = i;
    return m;
}

void printArray(char* element1, char* element2, int length, int data[length])
{
    printf("%s-%s\n", element1, element2);
    FOR(i, length)
        printf("  %d      %d\n", i, data[i]);
    int max = maxArray(length, data);
    printf("Best %s was %d with %d %s\n", element1, max, data[max], element2);
}

int main()
{
    int pricePerProduct[PRODUCTS] = {250,150,320,210,920};
    int sales[SALESMEN][PRODUCTS] = {
        {10,  4,  5,  6,  7},
        { 7,  0, 12,  1,  3},
        { 4, 19,  5,  0,  8},
        { 3,  2,  1,  5,  6}};

    int salesPerPerson[SALESMEN];
    int productSale[PRODUCTS];

    calculateSales(SALESMEN, PRODUCTS, pricePerProduct, sales, salesPerPerson);
    calculateProductSales(SALESMEN, PRODUCTS, sales, productSale);

    printArray("SalesMan", "Sales", SALESMEN, salesPerPerson);
    printArray("Product", "Items", PRODUCTS, productSale);

    return 0;
}
