namespace Teleimot.Web.Api.Models.Users
{
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class UserResponseModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string UserName { get; set; }

        public int RealEstates { get; set; }

        public int Comments { get; set; }

        public double Rating { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, UserResponseModel>()
                .ForMember(u => u.RealEstates, opts => opts.MapFrom(u => u.RealEstates.Count))
                .ForMember(u => u.Comments, opts => opts.MapFrom(u => u.Comments.Count))
                .ForMember(u => u.Rating, opts => opts.MapFrom(u => u.Ratings.Average(r => r.Value)));
        }
    }
}
