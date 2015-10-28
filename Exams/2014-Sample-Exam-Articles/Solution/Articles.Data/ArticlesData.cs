using Articles.Data.Repositories;
using Articles.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Data
{
    public class ArticlesData : IArticlesData
    {
        private DbContext context;
        private Dictionary<Type, object> repositories;

        public ArticlesData(ArticlesDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Article> Articles
        {
            get { return this.GetRepository<Article>(); }
        }
        public IRepository<Category> Categories
        {
            get { return this.GetRepository<Category>(); }
        }
        public IRepository<Tag> Tags
        {
            get { return this.GetRepository<Tag>(); }
        }
        public IRepository<Like> Likes
        {
            get { return this.GetRepository<Like>(); }
        }
        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
