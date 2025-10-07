namespace ExcersizeSchoolSalarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //List<EmployeeBase> employees = new List<EmployeeBase>()
            //{
            //    new Teacher("Alice", 30000, "Math", 5),
            //    new CourseAdministrator("Bob", 35000, 3),
            //    new Administrator("Charlie", 40000, "HR"),
            //    new Teacher("David", 32000, "Science", 4),
            //    new CourseAdministrator("Eve", 36000, 2),
            //    new Administrator("Frank", 45000, "IT"),
            //    new Teacher("Grace", 3100, "English", 6),
            //    new CourseAdministrator("Hannah", 37000, 4),
            //    new Administrator("Ian", 42000, "Finance"),
            //    new Teacher("Jack", 33000, "History", 3),
            //    new Teacher("Karen", 34000, "Art", 2)
            //};

            List<EmployeeBase> employees = TxtHandler.LoadFromTxt("employees.txt");

            bool run = true;

            while (run)
            {
                Console.Clear();
                Console.WriteLine("[1] Show all employees");
                Console.WriteLine("[2] Add employee");
                Console.WriteLine("[3] Pay salaries and show total salry expenses");
                Console.WriteLine("[4] Find employee");
                Console.WriteLine("[5] Remove employee");
                Console.WriteLine("[6] Save employees to txt file");
                Console.WriteLine("[7] Exit");
                Console.Write("Select 1,2 or 3: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        SorterMethod(employees);
                        ListAllEmployees(employees);
                        PressAnyKey();
                        break;
                    case "2":
                        AddEmployee(employees);
                        PressAnyKey();
                        break;
                    case "3":
                        SalaryCalculator.PaySalaries(employees);
                        PressAnyKey();
                        Console.WriteLine($"Total Salary Expense: {SalaryCalculator.TotalSalaryExpense(employees):C}");
                        PressAnyKey();
                        break;
                    case "4":
                        //SearchEmployee(employees);
                        UpdateSalary(employees);
                        TxtHandler.SaveToTxt("employees.txt", employees);   
                        employees = TxtHandler.LoadFromTxt("employees.txt");
                        PressAnyKey();

                        break;

                    case "5":
                        RemoveEmployee(employees);
                        PressAnyKey();

                        break;
                        case "6":
                        Console.WriteLine("Save to txt");
                        TxtHandler.SaveToTxt("employees.txt", employees);
                        employees = TxtHandler.LoadFromTxt("employees.txt");
                        PressAnyKey();
                        break;
                   
                    case "7":

                        Console.WriteLine("ByeBye");

                        run = false;
                        break;


                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2 or 3.");
                        break;
                }


            }
        }

        public static void ListAllEmployees(List<EmployeeBase> employees)
        {
            Console.WriteLine("---All Employees---\n");

            foreach (var emp in employees)
            {
                Console.WriteLine(emp.ToString());
            }
        }
        public static void AddEmployee(List<EmployeeBase> employees)
        {

            Console.WriteLine("---Add employee---\n");
            Console.WriteLine("[1] Teacher");
            Console.WriteLine("[2] CourseaAdmin");
            Console.WriteLine("[3] Admin");
            Console.Write("Enter your role (1/2/3): ");

            string role = Console.ReadLine();
            var (name, baseSalary) = NameAndSalary();
            switch (role)
            {
                case "1":


                    Console.Write("Subject: ");
                    string subject = Console.ReadLine();
                    Console.Write("Number of classes: ");
                    int numberOfClasses = ValidInt();
                    employees.Add(new Teacher(name, baseSalary, subject, numberOfClasses));
                    break;
                case "2":
                    decimal caBaseSalary = ValidDecimal();
                    Console.Write("Number of active courses: ");
                    int numberOfCourses = ValidInt();
                    employees.Add(new CourseAdministrator(name, baseSalary, numberOfCourses));

                    break;

                case "3":
                    string department = Console.ReadLine();
                    employees.Add(new Administrator(name, baseSalary, department));

                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select 1, 2 or 3.");
                    break;
            }

            Console.WriteLine("Employee" + name + "added, press any key to continue");
            Console.ReadKey();

        }

        public static (string, decimal) NameAndSalary()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Base Salary: ");
            decimal baseSalary = ValidDecimal();

            return (name, baseSalary);
        }
        public static decimal ValidDecimal()
        {
            decimal value;
            while (!decimal.TryParse(Console.ReadLine(), out value) || value < 0)
            {
                Console.Write("Invalid input. Please enter a valid positive decimal number: ");
            }
            return value;
        }
        public static int ValidInt()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value < 0)
            {
                Console.Write("Invalid input. Please enter a valid positive integer: ");
            }
            return value;
        }
        public static EmployeeBase SearchEmployee(List<EmployeeBase> employees)
        {
            Console.Write("Enter employee name to search: ");
            string name = Console.ReadLine();
            var employee = employees.FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (employee != null)
            {
                Console.WriteLine(employee.ToString());
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
            return employee;
        }

        public static void RemoveEmployee(List<EmployeeBase> employees)
        {
            Console.Write("Enter employee name to remove: ");
            string removeName = Console.ReadLine();
            var employee = employees.FirstOrDefault(e => e.Name.Equals(removeName, StringComparison.OrdinalIgnoreCase));
            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine($"Employee {removeName} removed.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void SortByName(List<EmployeeBase> emp)
        {
            emp = emp.OrderBy(e => e.Name).ToList();
        }

        public static void SortBySalary(List<EmployeeBase> emp)
        {
            emp = emp.OrderBy(e => e.CalculateSalary()).ToList();
        }

        public static void SorterMethod(List<EmployeeBase> emp)
        {
            Console.WriteLine("Sort by: [1] Name [2] Salary [3] None");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    SortByName(emp);
                    break;
                case "2":
                    SortBySalary(emp);
                    break;
                    case "3":
                        break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        public static void UpdateSalary(List<EmployeeBase> emp)
        {
            Console.WriteLine("---Update employee base salary---");
            var employee = SearchEmployee(emp);
            if (employee == null)
            {
                return;
            }
            Console.WriteLine();
            Console.Write("Enter new salary (before tax and bonus): ");
            decimal newSalary = ValidDecimal();

            employee.BaseSalary = newSalary;
            employee.CalculatedSalary = employee.CalculateSalary();

            Console.WriteLine($"{employee.Name}s base salary has been updated to {employee.BaseSalary} ({employee.CalculatedSalary:C} aftter taxes and bonus) ");



        }
    }
}
