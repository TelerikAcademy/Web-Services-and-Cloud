using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Models;

namespace Tests.Data
{
    public class TestsDbContext : DbContext
    {
        public TestsDbContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Question> Questions { get; set; }

        public IDbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().Property(cat => cat.Name)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(40)
                    .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute()
                    {
                        IsUnique = true
                    }));
        }

    }
}
