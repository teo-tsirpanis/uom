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

#define SWAP(type, x1, x2) {type temp = x1; (x1) = x2; (x2) = temp;}

typedef enum {
    LEAVING = -1,
    COMING = +1
} scheduleEvent_t;

typedef struct {
    /* The assignment statement's hours are all whole, with no minutes. */
    unsigned int startingHour;
    scheduleEvent_t event;
} scheduleEntry_t;

typedef scheduleEntry_t *scheduleEntry_p;

int compareScheduleEntries(const void *x1, const void *x2) {
    unsigned int hour1 = ((scheduleEntry_p) x1)->startingHour;
    unsigned int hour2 = ((scheduleEntry_p) x2)->startingHour;
    if (hour1 < hour2)
        return -1;
    else if (hour1 > hour2)
        return 1;
    else
        return 0;
}

unsigned int getBestHour(const size_t length, const unsigned int data[length][2]) {
    int entriesLength = length * 2;
    scheduleEntry_t entries[entriesLength];
    for (int i = 0; i < length; i++) {
        entries[i * 2].startingHour = data[i][0];
        entries[i * 2].event = COMING;

        entries[i * 2 + 1].startingHour = data[i][1];
        entries[i * 2 + 1].event = LEAVING;
    }

    /*
     * To avoid a quicksort worst-case scenario, the first element of
     * the list (the quicksort's pivot) will be swapped with a random element.
     * In the announcement, the starting hour of the first performer (18:00) is indeed the earliest one.
     * There's no reason to become fully rigorous by shuffling the entire array with the Fisher-Yates algorithm.
     * The modulo operator in the rand() function is not perfectly equidistributed, but it doesn't matter that much.
     */
    SWAP(scheduleEntry_t, entries[0], entries[rand() % (entriesLength - 1) + 1]); // NOLINT(cert-msc50-cpp)
    qsort((void *) data, length, sizeof(scheduleEntry_t), compareScheduleEntries);

    int currentMetalArtists = 1, maxMetalArtists = 1;
    unsigned int maxMetalArtistsHour = entries[0].startingHour;
    for (int i = 1; i < entriesLength; i++) {
        currentMetalArtists += (int) entries[i].event;
        if (currentMetalArtists > maxMetalArtists) {
            maxMetalArtists = currentMetalArtists;
            maxMetalArtistsHour = entries[i].startingHour;
        }
    }
    return maxMetalArtistsHour;
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