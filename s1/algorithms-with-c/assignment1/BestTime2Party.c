/**
 * University of Macedonia,
 * Department of Applied Informatics,
 * Semester 1,
 * Algorithms with C,
 * Assignment 1
 * 
 * Created by: Theodore Tsirpanis
 * Professor: Nikolaos Samaras
 */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define HOURS 24

#define VALIDATE_24H(x) { \
    if (x < 1 || x > HOURS) { \
        fprintf(stderr, "The hours number must be between 1 and HOURS, inclusive, but it is %u", x); \
        exit(1); \
    } \
}

unsigned int getBestHour(const size_t length, const unsigned int data[][2]) {
    int hours[HOURS];

    memset(hours, 0, HOURS * sizeof(int));

    for (int i = 0; i < length; i++) {
        VALIDATE_24H(data[i][0])
        hours[data[i][0] - 1] += 1;

        VALIDATE_24H(data[i][1])
        hours[data[i][1] - 1] -= 1;
    }

    unsigned int maxMetalArtistsHour = 0;
    int currentMetalArtists = hours[maxMetalArtistsHour], maxMetalArtists = currentMetalArtists;
    for (unsigned int i = 1; i < HOURS; i++) {
        currentMetalArtists += hours[i];
        if (currentMetalArtists > maxMetalArtists) {
            maxMetalArtists = currentMetalArtists;
            maxMetalArtistsHour = i;
        }
    }
    return maxMetalArtistsHour + 1;
}

#define SAMPLE_DATA_SIZE 15

#define SAMPLE_DATA \
        { \
                {18, 19}, \
                {19, 21}, \
                {22, 24}, \
                {20, 22}, \
                {22, 23}, \
                {23, 24}, \
                {20, 22}, \
                {21, 23}, \
                {19, 22}, \
                {20, 23}, \
                {18, 21}, \
                {19, 20}, \
                {20, 21}, \
                {22, 24}, \
                {19, 23}, \
        };

int main() {
#ifdef READ_DATA_FROM_USER
    fprintf(stderr, "How many metal artists are going to attend? ");
    size_t size = 0;
    scanf("%u", &size);
    fprintf(stderr, "Write the hours each metal star will attend in the following format:");
    fprintf(stderr, "<start hour>-<end hour> (e.g. 0-03)");

    unsigned int data[size][2];
    for (int i = 0; i < size; i++)
        scanf("%u-%u", &data[i][0], &data[i][1]);
#else
    size_t size = SAMPLE_DATA_SIZE;
    unsigned int data[][2] = SAMPLE_DATA;
#endif

    int bestHour = getBestHour(size, data);

    printf("The most metal artists will be there at %u:00, for an hour.", bestHour);
    return 0;
}
