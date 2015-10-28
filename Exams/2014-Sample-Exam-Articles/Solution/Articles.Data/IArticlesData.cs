using Articles.Data.Repositories;
using Articles.Models;
using System;
namespace Articles.Data
{
    public interface IArticlesData
    {
        IRepository<Article> Articles { get; }
        IRepository<Category> Categories { get; }
        IRepository<Like> Likes { get; }
        IRepository<Tag> Tags { get; }
        IRepository<Comment> Comments { get; }
        int SaveChanges();
    }
}
