namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Common;
    using Enums;

    public class Bet
    {
        [Key]
        public int BetId { get; set; }

        public double Amount { get; set; }

        [Required]
        public Prediction Prediction { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }

        public int GameId{ get; set; }
    }
}
