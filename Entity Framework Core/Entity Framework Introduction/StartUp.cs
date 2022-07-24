namespace EntityFrameWorkCore.DBFirst
{
    using System;
    using System.Linq;
    using System.Text;
    
    using EntityFrameWorkCore.DBFirst.Data;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            
            // Task 1
            var output = GetEmployeesFullInformation(context);
            //
            
            // Task 2
            output = GetEmployeesWithSalaryOver50000(context);
            //

            // Task 3
            output = GetEmployeesFromResearchAndDevelopment(context);
            //

            // Task 4

            //

            // Task 

            //

            // Task 

            //
            Console.WriteLine(output);
        }

        // Task 1
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            foreach (var emp in context.Employees.OrderBy(e => e.EmployeeId))
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:f2}");
            }

            return sb.ToString();
        }
        //

        // Task 2
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
        //

        // Task 3
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
        
        //

        // Task 4

        //

        // Task 

        //

        // Task 

        //
    }
}
