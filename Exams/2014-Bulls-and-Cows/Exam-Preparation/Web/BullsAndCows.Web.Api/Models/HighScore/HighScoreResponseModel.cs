namespace BullsAndCows.Web.Api.Models.HighScore
{
    using System;
    using AutoMapper;
    using BullsAndCows.Data.Models;
    using BullsAndCows.Web.Api.Infrastructure.Mappings;

    public class HighScoreResponseModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Username { get; set; }

        public int Rank { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, HighScoreResponseModel>()
                .ForMember(u => u.Username, opts => opts.MapFrom(u => u.Email));
        }
    }
}
