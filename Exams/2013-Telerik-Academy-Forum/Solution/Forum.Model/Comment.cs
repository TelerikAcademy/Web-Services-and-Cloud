using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Forum.Model
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName="ntext")]
        public string Content { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
