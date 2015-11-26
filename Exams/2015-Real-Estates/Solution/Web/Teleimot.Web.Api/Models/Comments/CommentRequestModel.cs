namespace Teleimot.Web.Api.Models.Comments
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mappings;

    public class CommentRequestModel: IMapFrom<Comment>
    {
        public int RealEstateId { get; set; }
        
        [Required]
        [MinLength(CommentConstants.ContentMinLength)]
        [MaxLength(CommentConstants.ContentMaxLength)]
        public string Content { get; set; }
    }
}
