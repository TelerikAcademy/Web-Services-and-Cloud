namespace Articles.Data
{
    using Articles.Data.Migrations;
    using Articles.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ArticlesDbContext : IdentityDbContext<ApplicationUser>
    {
        public ArticlesDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArticlesDbContext, Configuration>());
        }

        public static ArticlesDbContext Create()
        {
            return new ArticlesDbContext();
        }

        public IDbSet<Article> Articles { get; set; }
        public IDbSet<Like> Likes { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Category> Categorys { get; set; }
        public IDbSet<Tag> Tags { get; set; }
        public IDbSet<Alert> Alerts { get; set; }
    }
}
