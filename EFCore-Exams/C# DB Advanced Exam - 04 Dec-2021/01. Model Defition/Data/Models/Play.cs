namespace Theatre.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enums;

    public class Play
    {
        public Play()
        {
            Tickets = new List<Ticket>();
            Casts = new List<Cast>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50,MinimumLength = 4)]
        public string Title  { get; set; }

        [Required]
        [Column(TypeName = "time")]
        public TimeSpan Duration { get; set; }

        [Range(typeof(float), "0.00","10.00")]
        public float Rating { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        [Required]
        [StringLength(30,MinimumLength = 4)]
        public string Screenwriter { get; set; }

        public List<Ticket> Tickets { get; set; }

        public List<Cast> Casts { get; set; }
    }
}
