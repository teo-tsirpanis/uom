#include <stdio.h>
#include <stdint.h>

typedef uint64_t set_t;

#define SET_EMPTY 0
#define SET_SINGLE(n) (set_t) (1 << (n - 1))
#define SET_FULL(n) (set_t) ((1 << n) - 1)
#define SET_UNION(s1, s2) s1 | s2
#define SET_INTERSECTION(s1, s2) s1 & s2
#define SET_COUNT(s) __builtin_popcountll(s)

set_t find_smallest_set(const set_t x1, const set_t x2) {
    if (SET_COUNT(x1) < SET_COUNT(x2))
        return x1;
    else
        return x2;
}

set_t find_best_combination_impl(const size_t currentEmployeeIndex, const size_t count,
                                 const set_t available_employees[count],
                                 const set_t hired_employees, const set_t currentSkills, const set_t skillsTarget) {
    if (currentSkills == skillsTarget)
        return hired_employees;
    else if (currentEmployeeIndex == count)
        return UINT64_MAX;
    else {
        set_t s1 = find_best_combination_impl(currentEmployeeIndex + 1, count, available_employees, hired_employees,
                                   currentSkills, skillsTarget);
        set_t s2 = find_best_combination_impl(currentEmployeeIndex + 1, count, available_employees,
                                   SET_UNION(hired_employees, SET_SINGLE(currentEmployeeIndex)),
                                   SET_UNION(currentSkills, available_employees[currentEmployeeIndex]),
                                   skillsTarget);
        return find_smallest_set(s1, s2);
    }
}

set_t find_best_combination(const size_t employeesCount, const set_t availableEmployees[employeesCount],
                            const set_t skillsCount) {
    return find_best_combination_impl(0, employeesCount, availableEmployees, SET_EMPTY, SET_EMPTY, SET_FULL(skillsCount));
}

#define SAMPLE1_DATA \
    { \
        0b000011, \
        0b011000, \
        0b101000, \
        0b110000, \
        0b010101, \
        0b000101, \
    }
#define SAMPLE1_DATA_SIZE 6
#define SAMPLE1_DATA_SKILLS_SIZE 6

int main() {
    set_t data[SAMPLE1_DATA_SIZE] = SAMPLE1_DATA;
    printf("%llx\n", find_best_combination(SAMPLE1_DATA_SIZE, data, SAMPLE1_DATA_SKILLS_SIZE));
    return 0;
}