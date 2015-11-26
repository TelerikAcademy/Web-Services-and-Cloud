namespace Teleimot.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Range(UserConstants.RatingMinValue, UserConstants.RatingMaxMavue)]
        public int Value { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
