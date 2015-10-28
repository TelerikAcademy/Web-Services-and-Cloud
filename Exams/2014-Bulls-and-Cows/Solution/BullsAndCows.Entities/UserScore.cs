using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Entities
{
    public class UserScore
    {
        public int Id { get; set; }
        public ScoreType ScoreType { get; set; }

        public Game Game { get; set; }

        public User User { get; set; }
    }
}