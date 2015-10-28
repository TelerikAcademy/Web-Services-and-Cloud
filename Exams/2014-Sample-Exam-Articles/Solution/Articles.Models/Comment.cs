using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Articles.Models
{
    public class Comment
    {
        public int ID { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorID { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int ArticleID { get; set; }

        public virtual Article Article { get; set; }
    }
}
