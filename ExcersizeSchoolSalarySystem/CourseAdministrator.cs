using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcersizeSchoolSalarySystem
{
    public class CourseAdministrator : EmployeeBase
    {
        public int NumberOfAcvtiveCourses { get; set; }
        public CourseAdministrator(string name, decimal baseSalary, int numberOfCourses) : base(name, baseSalary)
        {
            NumberOfAcvtiveCourses = numberOfCourses;
        }

        public override decimal CalculateSalary()
        {
            return (BaseSalary + SalaryCalculator.ApplyBonus(NumberOfAcvtiveCourses)) * SalaryCalculator.ApplyTax();
        }

        public override string ToString()
        {
            return $"Course Admin: {Name}, Active Courses: {NumberOfAcvtiveCourses}, Salary: {CalculateSalary():C}";
        }
    }
    
    
}
