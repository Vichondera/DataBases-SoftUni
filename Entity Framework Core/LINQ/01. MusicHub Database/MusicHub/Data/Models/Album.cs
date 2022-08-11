namespace MusicHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Album
    {
        public Album()
        {
            Songs = new List<Song>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name  { get; set; }

        [Required]
        public DateTime ReleaseDate  { get; set; }

        public decimal Price  { get; set; }

        [ForeignKey(nameof(Producer))]
        public int? ProducerId  { get; set; }

        public Producer Producer { get; set; }

        public ICollection<Song> Songs  { get; set; }
    }
    
}
