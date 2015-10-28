using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BullsAndCows.Entities
{
    public class Guess
    {
        public int Id { get; set; }
        
        [Required]
        public int Value { get; set; }

        [Required]
        public virtual User User { get; set; }

        [Required]
        public virtual Game Game { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }
    }
}