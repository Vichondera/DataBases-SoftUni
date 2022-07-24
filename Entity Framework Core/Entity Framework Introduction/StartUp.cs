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
            var contex = new SoftUniContext();
            
            // Task 1
            var output = GetEmployeesFullInformation(contex);
            //

            // Task 

            //

            // Task 

            //

            // Task 

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

        // Task 

        //

        // Task 

        //

        // Task 

        //

        // Task 

        //

        // Task 

        //
    }
}
