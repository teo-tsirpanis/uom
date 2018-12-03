#include <stdio.h>
#include "simpio.h"

#define BRAND_LENGTH 10
#define NAME_LENGTH 22

#define FOR(len) for (int i = 0; i < len; i++)

typedef struct {
    unsigned int id;
    char brand[BRAND_LENGTH];
    unsigned int cc;
    char customerName[NAME_LENGTH];
    unsigned int rentDays;
    double dailyRate;
} carRentalT;

void readCarRental(carRentalT *cr)
{
    printf("Dose marka: ");
    gets(cr->brand);
    printf("Dose kyvika: ");
    cr->cc = GetInteger();
    printf("Dose onoma pelati: ");
    gets(cr->customerName);
    printf("Dose imeres enoikiasis: ");
    cr->rentDays = GetInteger();
    printf("Dose timi ana imera: ");
    cr->dailyRate = GetReal();
    printf("\n");
}

void printCarRental(const carRentalT *cr, double totalPrice)
{
    printf("%-8d%-*s%-*s%-6d%-6d%-6.2f%-6.2f\n", cr->id, NAME_LENGTH - 1, cr->customerName, BRAND_LENGTH + 1, cr->brand, cr->cc, cr->rentDays, cr->dailyRate, totalPrice);
}

int findBestRentalPriceIndex(int len, const double rentalPrices[len])
{
    int maxPriceIdx = 0;
    double maxPrice = rentalPrices[maxPriceIdx];
    for (int i = 1; i < len; i++)
        if (rentalPrices[i] > maxPrice)
        {
            maxPriceIdx = i;
            maxPrice = rentalPrices[i];
        }
    return maxPriceIdx;
}

int main()
{
    printf("Dose ton arithmo ton enoikiaseon: ");
    int len = GetInteger();
    printf("\n");

    carRentalT carRentals[len];
    double rentalPrices[len];
    double priceSum = 0.0;

    FOR(len)
    {
        printf("Dose ta stoixeia tis enoikiasis %d\n", i);
        readCarRental(&carRentals[i]);
        carRentals[i].id = i;
        rentalPrices[i] = (double) carRentals[i].rentDays * carRentals[i].dailyRate;
        priceSum += rentalPrices[i];
    }
    printf("\n");

    int bestRentalIdx = findBestRentalPriceIndex(len, rentalPrices);
    carRentalT *bestRental = &carRentals[bestRentalIdx];

    printf("Number  Name                 Type       CC    Days  Price  Total\n");
    printf("-------------------------------------------------------------------------\n");
    FOR(len)
        printCarRental(&carRentals[i], rentalPrices[i]);
    printf("-------------------------------------------------------------------------\n");
    printf("                                                    Total  %-5.2lf        \n", priceSum);
    printf("Best car: %s %d rented for %.2f Euros.\n", bestRental->brand, bestRental->cc, rentalPrices[bestRentalIdx]);
}
