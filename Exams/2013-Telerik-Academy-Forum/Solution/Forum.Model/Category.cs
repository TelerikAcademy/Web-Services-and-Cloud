using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Thread> Threads { get; set; }
        public Category()
        {
            this.Threads = new HashSet<Thread>();
        }
    }
}
