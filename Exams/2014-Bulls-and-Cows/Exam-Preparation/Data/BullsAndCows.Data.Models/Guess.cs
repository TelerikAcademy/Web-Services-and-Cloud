namespace BullsAndCows.Data.Models
{
    using Common.Constants;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Guess
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GameConstants.GuessNumberLength)]
        [MaxLength(GameConstants.GuessNumberLength)]
        public string Number { get; set; }

        public DateTime DateMade { get; set; }

        public int BullsCount { get; set; }

        public int CowsCount { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
