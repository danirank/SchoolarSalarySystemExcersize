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
            
        }

        public override decimal CalculateSalary()
        {
            return ( BaseSalary + SalaryCalculator.ApplyBonus(1) ) * SalaryCalculator.ApplyTax() ;
        }
        public override string ToString()
        {
            return $"Admin: {Name}, Department: {Department}, Salary: {CalculateSalary():C}";
        }
    }
}
