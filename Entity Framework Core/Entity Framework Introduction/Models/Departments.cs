namespace EntityFrameWorkCore.DBFirst.Models
{
    using System.Collections.Generic;

    public partial class Departments
    {
        public Departments()
        {
            Employees = new HashSet<Employees>();
        }

        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public int ManagerId { get; set; }

        public virtual Employees Manager { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
