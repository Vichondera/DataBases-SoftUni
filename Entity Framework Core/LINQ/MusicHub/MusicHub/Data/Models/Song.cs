namespace MusicHub.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;

	public class Song
    {
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(GlobalConstsants.SongNameMaxLength)]
		public string Name { get; set; }

		[Required]
		public TimeSpan Duration { get; set; }

		[Required]
		public DateTime CreatedOn { get; set; }

		[Required]
		public Genre Genre { get; set; }

		[Required]
		public Album Album { get; set; }

		[ForeignKey(nameof(Writer))]
		public int WriterId { get; set; }

		public virtual Writer Writer { get; set; }

		public decimal Price { get; set; }

		public virtual ICollection<SongPerformer> SongPerformers { get; set; }

	}
}
