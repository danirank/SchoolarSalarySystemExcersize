using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcersizeSchoolSalarySystem
{
    public static class SalaryCalculator
    {
        public static decimal ApplyTax()
        {
            decimal taxRate = 0.2m; 
            return  (1 - taxRate);
        } 

        public static decimal ApplyBonus(int bonusParameter)
        {
            decimal bonus = 500 * bonusParameter; 
            return bonus;
        }

        public static void PaySalaries(List<EmployeeBase> employees)
        {
           foreach (var e in employees)
           {

                Console.WriteLine($"Name: {e.Name}, Before taxes: {e.BaseSalary:C}, After taxes: {e.CalculatedSalary:C}");
            }
        } 

        public static decimal TotalSalaryExpense(List<EmployeeBase> employees)
        {
            return employees.Sum(e => e.CalculatedSalary);
        }

        

    }
}
