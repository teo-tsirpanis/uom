#include <math.h>
#include <stdio.h>

int firstTwoDigits (int x) {
    return x / pow(10, ceil(log10((double) x)) - 2);
}

int productCodeToPrice (int x) {
    /* It is nowhere stated that the product code is just four digits long.
    It also works where the product code is two or three digits long.
    Yet it fails when the product code has just one digit, but the exercise's statement
    does not say anything about handling cases with short product codes. */
    return firstTwoDigits(x) + (x % 100);
}

double calculateProductPrice (int quantity, int price) {
    return (double) quantity * (double) price;
}

double calculateDiscount (int quantity, int price) {
    double discountRate = 0.0;
    if (quantity <= 30) {
        discountRate = 0.1;
    } else if (quantity <= 70) {
        discountRate = 0.2;
    } else {
        discountRate = 0.35;
    };
    return calculateProductPrice(quantity, price) * discountRate;
}

int main () {
    int productCode = 0;
    int quantity = 0;

    /* puts() cannot be used, as it appends a newline */
    printf("Dwse ton kwdiko tou proiontos: ");
    scanf("%d", &productCode);
    printf("Dwse ton arithmo twn temaxiwn: ");
    scanf("%d", &quantity);

    int productPrice = productCodeToPrice(productCode);
    double discount = calculateDiscount(quantity, productPrice);
    double finalPrice = calculateProductPrice(quantity, productPrice) - discount;

    printf("H timh pwlhshs toy proiontos einai %d\n", productPrice);
    printf("H ekptwsh einai %0.2f\n", discount);
    printf("H telikh timh ths paragelias einai %0.2f\n", finalPrice);

    return 0;
}