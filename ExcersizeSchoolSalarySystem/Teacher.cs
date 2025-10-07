using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcersizeSchoolSalarySystem
{

    public class Teacher : EmployeeBase

    {

        public string Subject { get; set; }
        public int NumberOfClasses { get; set; }

        public Teacher(string name, decimal baseSalary, string subject, int numberOfClasses) : base(name, baseSalary)
        {
            Subject = subject;
            NumberOfClasses = numberOfClasses;
        }

        public override decimal CalculateSalary()
        {
           return ( BaseSalary + SalaryCalculator.ApplyBonus(NumberOfClasses)) * SalaryCalculator.ApplyTax() ;
        }

        public override string ToString()
        {
            return $"Teacher: {Name}, Subject: {Subject}, Classes: {NumberOfClasses}, Salary: {CalculateSalary():C}";
        }
    }
}
