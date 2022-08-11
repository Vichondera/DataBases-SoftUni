namespace MusicHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Producer
    {
        public Producer()
        {
            Albums = new List<Album>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name  { get; set; }

        public string Pseudonym  { get; set; }

        public string PhoneNumber  { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
    
}
