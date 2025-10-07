using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExcersizeSchoolSalarySystem
{
    public abstract class EmployeeBase
    {
        public string Name { get; set; }

        private decimal _baseSalary;
        public decimal BaseSalary
        {
            get 
            { 
                return _baseSalary; 
            }

            set
            {
                if (value < 0)
                {

                    Console.WriteLine("Base salary cannot be negative.");

                    _baseSalary = 0;
                }
                else
                {
                    _baseSalary = value;
                }
            }
        }

        public EmployeeBase(string name, decimal baseSalary)
        {
            Name = name;
            _baseSalary = baseSalary;
            
        }

    
        public abstract decimal CalculateSalary();
        

    }
}
