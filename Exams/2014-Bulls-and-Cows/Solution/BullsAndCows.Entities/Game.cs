namespace BullsAndCows.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Game
    {
        public Game()
        {
            this.DateCreated = DateTime.Now;
            this.Guesses = new HashSet<Guess>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 6)]
        public string Name { get; set; }

        [StringLength(40)]
        public string Password { get; set; }
        
        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public GameState State { get; set; }

        public int? RedUserNumber { get; set; }

        public int? BlueUserNumber { get; set; }

        public virtual User RedUser { get; set; }

        public virtual User BlueUser { get; set; }

        public virtual ICollection<Guess> Guesses { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

    }
}