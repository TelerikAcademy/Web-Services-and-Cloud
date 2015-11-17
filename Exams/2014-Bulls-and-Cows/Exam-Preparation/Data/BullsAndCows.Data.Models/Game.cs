namespace BullsAndCows.Data.Models
{
    using Common.Constants;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        private ICollection<Guess> guesses;

        public Game()
        {
            this.guesses = new HashSet<Guess>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GameConstants.GameNameMaxLength)]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        [Index]
        public GameState GameState { get; set; }

        public GameResultType GameResult { get; set; }
        
        public string RedUserNumber { get; set; }

        public string BlueUserNumber { get; set; }

        public string RedUserId { get; set; }

        public virtual User RedUser { get; set; }

        public string BlueUserId { get; set; }
        
        public virtual User BlueUser { get; set; }

        public virtual ICollection<Guess> Guesses
        {
            get { return this.guesses; }
            set { this.guesses = value; }
        }
    }
}
