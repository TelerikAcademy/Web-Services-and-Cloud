using Articles.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Articles.WebAPI.Models
{
    public class CommentDataModel
    {
        public static Expression<Func<Comment, CommentDataModel>> FromComment
        {
            get
            {
                return c => new CommentDataModel
                {
                    AuthorName = c.Author.UserName,
                    Content = c.Content,
                    DateCreated = c.DateCreated,
                    ID = c.ID
                };
            }
        }

        public int ID { get; set; }
        
        public string AuthorName { get; set; }

        public DateTime DateCreated { get; set; }
        
        public string Content { get; set; }
        [Required]
        public int ArticleID { get; set; }
    }
}
