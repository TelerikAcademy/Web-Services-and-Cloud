namespace Articles.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Article
    {
        public Article()
        {
            this.Likes = new HashSet<Like>();
            this.Tags = new HashSet<Tag>();
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorID { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
