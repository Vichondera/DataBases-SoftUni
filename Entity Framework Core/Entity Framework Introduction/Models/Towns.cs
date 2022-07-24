namespace EntityFrameWorkCore.DBFirst.Models
{
    using System.Collections.Generic;

    public partial class Towns
    {
        public Towns()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int TownId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }
    }
}
