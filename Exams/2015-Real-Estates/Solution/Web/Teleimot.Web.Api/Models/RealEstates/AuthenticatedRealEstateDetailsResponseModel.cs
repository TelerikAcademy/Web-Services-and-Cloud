namespace Teleimot.Web.Api.Models.RealEstates
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Comments;
    using Common.Constants;
    using Data.Models;

    public class AuthenticatedRealEstateDetailsResponseModel : RealEstateDetailsResponseModel
    {
        public string Contact { get; set; }

        public IEnumerable<CommentResponseModel> Comments { get; set; } 

        public override void CreateMappings(IConfiguration configuration)
        {
            base.CreateMappings(configuration);

            configuration.CreateMap<RealEstate, AuthenticatedRealEstateDetailsResponseModel>()
                .ForMember(r => r.Comments, opts => opts.MapFrom(r => r.Comments.OrderBy(c => c.CreatedOn).Take(CommentConstants.DefaultCommentTake)));
        }
    }
}
