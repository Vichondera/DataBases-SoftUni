namespace Footballers.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Coach
    {
        public Coach()
        {
            Footballers = new List<Footballer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40,MinimumLength =2)]
        public string Name { get; set; }

        [Required]
        public string Nationality { get; set; }

        public  ICollection<Footballer> Footballers { get; set; }
    }
}
