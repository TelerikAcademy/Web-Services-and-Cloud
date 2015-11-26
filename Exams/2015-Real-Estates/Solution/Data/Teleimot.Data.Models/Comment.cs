namespace Teleimot.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(CommentConstants.ContentMinLength)]
        [MaxLength(CommentConstants.ContentMaxLength)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int RealEstateId { get; set; }

        public virtual RealEstate RealEstate { get; set; }
        
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
