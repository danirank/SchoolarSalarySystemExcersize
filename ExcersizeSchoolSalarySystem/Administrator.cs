using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcersizeSchoolSalarySystem
{
    public class Administrator : EmployeeBase
    {
        public string Department { get; set; }
        public Administrator(string name, decimal baseSalary, string department) : base(name, baseSalary)
        {
            Department = department;
            CalculatedSalary = CalculateSalary();
        }

        public override decimal CalculateSalary()
        {
            decimal baseSalary = BaseSalary;
            return ( baseSalary + SalaryCalculator.ApplyBonus(1) ) * SalaryCalculator.ApplyTax() ;
        }
        public override string ToString()
        {
            return $"Admin: {Name}, Department: {Department}, Base salary: {BaseSalary:C}, Salary after bonuses and taxes: {CalculatedSalary:C}";
        }
    }
}
