namespace Theatre.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cast
    {
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(30,MinimumLength = 4)]
        public string FullName { get; set; }

		[Required]
        public bool IsMainCharacter { get; set; }

		[Required]
		[StringLength(15)]
		[RegularExpression(@"^\+44-\d{2}-\d{3}-\d{4}")]
        public string PhoneNumber { get; set; }

		[Required]
        public int PlayId { get; set; }

		[ForeignKey(nameof(PlayId))]
		public virtual Play Play { get; set; }
    }
}
