using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Models;

namespace Tests.Data
{
    public class TestsDbContext : DbContext
    {
        public TestsDbContext()
            :base("DefaultConnection")
        {
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Question> Questions { get; set; }

        public IDbSet<Answer> Answers { get; set; }
    }
}
