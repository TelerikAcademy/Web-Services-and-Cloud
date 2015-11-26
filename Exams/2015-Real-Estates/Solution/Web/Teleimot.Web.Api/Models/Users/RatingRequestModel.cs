namespace Teleimot.Web.Api.Models.Users
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mappings;

    public class RatingRequestModel : IMapFrom<Rating>
    {
        [Required]
        public string UserId { get; set; }

        [Range(UserConstants.RatingMinValue, UserConstants.RatingMaxMavue)]
        public int Value { get; set; }
    }
}
