using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.Model
{
    public class Vote
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
