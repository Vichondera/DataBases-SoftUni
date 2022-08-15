namespace Trucks.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Despatcher
    {
        public Despatcher()
        {
            Trucks = new List<Truck>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40,MinimumLength = 2)]
        public string Name { get; set; }

        public string Position { get; set; }

        public ICollection<Truck> Trucks { get; set; }
    }
}
