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
    double weeklySalary = 0.0;

    printf("Dwse ton kwdiko:");
    scanf("%ld", &employeeCode);

    if (employeeCode < 1000) {
        int hours = 0;
        double wage = 0.0;

        printf("Dwse tis wres ebdomadiaias ergasias:");
        scanf("%d", &hours);
        printf("Dwse thn amoibh ana wra:");
        scanf("%lf", &wage);

        weeklySalary = calculateWeeklySalaryByWage(hours, wage);

    } else {
        double salary = 0.0;

        printf("Dwse ton ethsio mistho:");
        scanf("%lf", &salary);

        weeklySalary = calculateWeeklySalaryByYear(salary);
    }

    printf("H ebdomadiaia amoibh einai %0.2f\n", weeklySalary);

    return 0;
}
