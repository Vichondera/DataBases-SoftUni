namespace MusicHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Performer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName  { get; set; }

         [Required]
        [StringLength(20)]
        public string LastName  { get; set; }

        [Required]
        public int Age  { get; set; }

        [Required]
        public decimal NetWorth { get; set; }

        public ICollection<SongPerformer> PerformerSongs  { get; set; }
    }
    
}
