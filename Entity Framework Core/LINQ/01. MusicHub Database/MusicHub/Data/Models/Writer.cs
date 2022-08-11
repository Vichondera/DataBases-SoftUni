namespace MusicHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Writer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name  { get; set; }

        public string Pseudonym  { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
    
}
