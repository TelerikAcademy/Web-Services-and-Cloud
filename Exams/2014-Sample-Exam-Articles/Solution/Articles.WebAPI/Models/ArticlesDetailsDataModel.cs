using Articles.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Articles.WebAPI.Models
{
    public class ArticleDetailsDataModel
    {
        public ArticleDetailsDataModel(Article article)
        {
            this.ID = article.ID;
            this.Title = article.Title;
            this.Content = article.Content;
            this.Category = article.Category.Name;
            this.DateCreated = article.DateCreated;
            this.Tags = article.Tags.Select(t => t.Name).ToArray();
            this.Comments = article.Comments.AsQueryable()
                .Select(CommentDataModel.FromComment).ToArray();
            this.Likes = article.Likes.AsQueryable()
                .Select(LikeDataModel.FromLike).ToArray();
        }

        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        [Required]
        public string Category { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<string> Tags { get; set; }

        public ICollection<CommentDataModel> Comments { get; set; }

        public ICollection<LikeDataModel> Likes { get; set; }
    }
}