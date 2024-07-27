using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidPrinciple.LiskovSubstitution;

interface ISalaryCalculator
{
    double CalculateSalary();
}

class Employee{
    public string name;
    public int hoursWorked;
}

class FullTimeEmployee : Employee, ISalaryCalculator
{
    public double CalculateSalary()
    {
        return hoursWorked * 2000;
    }
}


class PartTimeEmployee : Employee, ISalaryCalculator
{
    public double CalculateSalary()
    {
        return hoursWorked * 8;
    }
}


