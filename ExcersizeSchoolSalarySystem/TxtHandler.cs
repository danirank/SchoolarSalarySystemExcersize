using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcersizeSchoolSalarySystem
{
    
    public static class TxtHandler
    {
        
        public static void SaveToTxt(string filePath, List<EmployeeBase> employees)
        {
            var result = employees.Select(e => e.ToString()).ToList();
            System.IO.File.WriteAllLines(filePath, result);
        }
        public static List<EmployeeBase> LoadFromTxt(string filePath)
        {
            CultureInfo.CurrentCulture = new CultureInfo("sv-SE");
            var result = new List<EmployeeBase>();
            var fileLines = System.IO.File.ReadAllLines(filePath);
            foreach (var line in fileLines)
            {
                var parts = line.Split(",");
                var role = parts[0].Split(":")[0].Trim();
                var name = parts[0].Split(":")[1].Trim();
                decimal salary;

                switch (role)
                {
                    case "Teacher":
                        var subject = parts[1].Split(":")[1].Trim();
                        var classes = int.Parse(parts[2].Split(":")[1].Trim());
                         salary = decimal.Parse(parts[3].Split(":")[1].Trim().Replace("$", ""));
                        result.Add(new Teacher(name, salary, subject, classes));
                        break;
                    case "Course Admin":
                        var courses = int.Parse(parts[1].Split(":")[1].Trim());
                         salary = decimal.Parse(parts[2].Split(":")[1].Trim().Replace("$", ""));
                        result.Add(new CourseAdministrator(name, salary, courses));
                        break;

                    case "Admin":
                        var department = parts[1].Split(":")[1].Trim();
                         salary = decimal.Parse(parts[2].Split(":")[1].Trim().Replace("$", ""));
                        result.Add(new Administrator(name, salary, department));
                        break;
                    default:
                        throw new Exception("Unknown role in file.");
                        break;



                }

            }
                return result;
        }





    }
}
