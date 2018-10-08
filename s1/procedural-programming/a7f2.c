#include <stdio.h>

double calculateWeeklySalaryByWage (int hours, double wage) {
    double weeklyWageRaw = (double) hours * wage;
    if (hours > 40) {
        weeklyWageRaw += (double) (hours - 40) * wage;
    }
    return weeklyWageRaw;
}

double calculateWeeklySalaryByYear (double salary) {
    return salary / 52.0;
}

int main() {
    long employeeCode = 0;
    printf("Dwse ton kwdiko:");
    scanf("%ld", &employeeCode);

    if (employeeCode < 1000) {
        int hours = 0;
        double wage = 0.0;

        printf("Dwse tis wres ebdomadiaias ergasias:");
        scanf("%d", &hours);
        printf("Dwse thn amoibh ana wra:");
        scanf("%f", &wage);

        double weeklySalary = calculateWeeklySalaryByWage(hours, wage);

        printf("H ebdomadaia amoibh einai %0.2f\n", weeklySalary);
    } else {
        double salary = 0.0;

        printf("Dwse ton ethsio mistho:");
        scanf("%f", &salary);

        double weeklySalary = calculateWeeklySalaryByYear(salary);

        printf("H ebdomadiaia amoibh einai %0.2f\n", weeklySalary);
    }
    return 0;
}
