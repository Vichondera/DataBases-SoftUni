namespace Footballers.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        public Team()
        {
            TeamsFootballers = new List<TeamFootballer>();
        }

        [Key]
        public int Id { get; set; }

        //⦁	Name – text with length[3, 40]. May contain letters(lower and upper case), digits, spaces, a dot sign('.') and a dash('-'). (required)
        [Required]
        [StringLength(40,MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(40,MinimumLength = 2)]
        public string Nationality { get; set; }

        [Required]
        public int Trophies { get; set; }

        public ICollection<TeamFootballer> TeamsFootballers  { get; set; }
    }
}
