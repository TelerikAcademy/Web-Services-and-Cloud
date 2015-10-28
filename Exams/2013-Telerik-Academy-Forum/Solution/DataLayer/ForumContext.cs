using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Model;

namespace DataLayer
{
    public class ForumContext : DbContext
    {
        public ForumContext()
            : base("ForumDb")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(usr => usr.SessionKey)
                .IsFixedLength()
                .HasMaxLength(50);
            base.OnModelCreating(modelBuilder);
        }
    }
}
