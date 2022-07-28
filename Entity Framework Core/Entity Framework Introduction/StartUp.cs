namespace SoftUni
{
    using SoftUni.Data;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

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
    }
}
