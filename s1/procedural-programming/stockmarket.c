/* Stock Market Analysis
 */

#include <stdio.h>

#define FOR(to) for (int i = 0; i < to; i++)

#define DECLARE_PRICES(name, length, ...) \
    float name ## _prices[length] = {__VA_ARGS__}; \
    float max_ ## name = getMax(length, name ## _prices);

float getMax(unsigned int length, float data[length])
{
    float m = data[0];
    for (int i = 1; i < length; i++)
        if (data[i] > m)
            m = data[i];
    return m;
}

unsigned int getValuesLargerThanN(unsigned int length, float data[length], float interesting[length], float N)
{
    unsigned int count = 0;
    FOR(length)
        if (data[i] > N)
            interesting[count++] = data[i];
    return count;
}

#define FIND_INTERESTING(length, x) \
    float interesting_ ## x [length]; \
    int ni_ ## x = getValuesLargerThanN(length, x ## _prices, interesting_ ## x, max_ ## x / 2);

void printPrices(char *title, float max, unsigned int dataLength, float data[dataLength], unsigned int interestingLength, float interesting[interestingLength])
{
    printf("%s Prices.\n", title);
    printf("------------------------------\n");

    printf("Max Price:: %4.2f \n", max);

    FOR(dataLength)
        printf("%s(%3.2f) ", (max == data[i] ? "-Max-" : ""), data[i]);
    printf("\n");

    FOR(interestingLength)
        printf(" [%4.2f] ", interesting[i]);
    printf("\n");

    printf("----------\n");
}

#define PRINT_PRICES(title, length, x) \
    printPrices(title, max_ ## x, length, x ## _prices, ni_ ## x, interesting_ ## x)

int main(){
   /* Declaring arrays & Calculating Max Values */
   DECLARE_PRICES(stock, 10, 34.5, 22.4, 77.8, 22.1, 10.0, 11.25, 12, 13, 16, 20.5);
   DECLARE_PRICES(deriv, 5, 30.5, 21.4, 89.8, 20.1, 10.0);
   DECLARE_PRICES(cds, 11, 38.5, 33.4, 67.8, 12.1, 16.0, 10.25, 11, 23, 36, 10.1 ,30.4);

   int risk[11] = {90,10,20,30,50,60,30,30,30,10,10};

   /* Finding Interesting Values */
   FIND_INTERESTING(10, stock);
   FIND_INTERESTING(11, cds);

   /* Printing */

   PRINT_PRICES("Stock", 10, stock);
   printPrices("Derivative", max_deriv, 5, deriv_prices, 0, NULL);
   PRINT_PRICES("CDS", 11, cds);

   return 0;
}
