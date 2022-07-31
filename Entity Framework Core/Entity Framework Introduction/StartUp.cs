namespace SoftUni
{
    using System;
    using System.Linq;
    using System.Text;
    
    using SoftUni.Data;

    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            
            // Change method's name to see result for olther tasks
            Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));
        }

        // TASK 03. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            foreach (var emp in context.Employees.OrderBy(e => e.EmployeeId))
            {
                result.AppendLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:f2}");
            }

            return result.ToString();
        }

        // TASK 04. Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            foreach (var e in context.Employees
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName))
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }
            return sb.ToString();
        }

        // TASK 05. Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            foreach (var e in context.Employees
                .Where(d => d.DepartmentId == 6)
                .OrderBy(s => s.Salary)
                .ThenByDescending(n => n.FirstName))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} " +
                    $"from Research and Development ${e.Salary:f2}");
            }

            return sb.ToString();
        }

        // TASK 06. Adding a New Address and Updating Employee
         public static  string AddNewAddressToEmployee(SoftUniContext context)
        {
            var result = new StringBuilder();

            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            context.Addresses.Add(newAddress);

            Employee nakov = context
                .Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            nakov.Address = newAddress;
            context.SaveChangesAsync();

            var addrText = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToArray();

            foreach (var a in addrText)
            {
                result.AppendLine(a);
            }
            return result.ToString().TrimEnd();
        }

        // 07. Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

var emplWPr = context
                .Employees
                .Where(e => e.EmployeesProjects
                .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    AllProjects = e.EmployeesProjects
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartData = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                        EndDate = ep.Project.EndDate.HasValue ? 
                        ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished"
                    })
                })
                .ToArray();

            foreach (var e in emplWPr)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.FirstName} {e.LastName}");

                foreach (var pr in e.AllProjects)
                {
                    result
                        .AppendLine($"--{pr.ProjectName} - {pr.StartData} - {pr.EndDate}");
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}

