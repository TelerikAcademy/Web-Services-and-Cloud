using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Articles.WebAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Articles.Models;

namespace Articles.WebAPI.DataModels
{
    public class ArticleDataModel
    {
        public ArticleDataModel()
        {
            this.Tags = new HashSet<TagDataModel>();
        }

        public static Expression<Func<Article, ArticleDataModel>> FromArticle
        {
            get
            {
                return a => new ArticleDataModel
                {
                    ID = a.ID,
                    AuthorName = a.Author.UserName,
                    Title = a.Title,
                    Content = a.Content,
                    Category = a.Category.Name,
                    DateCreated = a.DateCreated,
                    Tags = a.Tags.AsQueryable()
                        .Select(TagDataModel.FromTag)
                };
            }
        }

        public int ID { get; set; }

        public string AuthorName { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Category { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<TagDataModel> Tags { get; set; }
    }
}