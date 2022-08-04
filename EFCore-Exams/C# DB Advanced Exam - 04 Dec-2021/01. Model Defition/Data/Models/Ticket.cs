namespace Theatre.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Range(typeof(decimal), "1.00", "100.00")]
        public decimal Price { get; set; }

        [Range(typeof(sbyte), "1", "10")]
        public sbyte RowNumber { get; set; }

        [Required]
        public int PlayId { get; set; }

        [Required]
        public int TheatreId { get; set; }

        [ForeignKey(nameof(TheatreId))]
        public virtual Theatre Theatre { get; set; }

        [ForeignKey(nameof(PlayId))]
        public virtual Play Play { get; set; }
    }
}
