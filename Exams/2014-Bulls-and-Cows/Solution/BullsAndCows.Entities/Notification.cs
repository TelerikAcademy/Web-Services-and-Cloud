using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Entities
{
    public class Notification
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Message { get; set; }

        [Required]
        public NotificationType NotificationType { get; set; }

        [Required]
        public NotificationState NotificationState { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public int GameId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
    }
}
