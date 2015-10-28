using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BullsAndCows.Data
{
    public class BullsAndCowsDbContext : IdentityDbContext<User>
    {
        public BullsAndCowsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {            
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCowsDbContext,  BullsAndCows.Data.Migrations.Configuration>());

        }

        public static BullsAndCowsDbContext Create()
        {
            return new BullsAndCowsDbContext();
        }

        //public IDbSet<User> Users { get; set; }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<Guess> Guesses { get; set; }

        public IDbSet<UserScore> Scores { get; set; }

        public IDbSet<Notification> Notifications { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Game>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
