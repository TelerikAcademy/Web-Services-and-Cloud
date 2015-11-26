namespace Teleimot.Web.Api.Models.RealEstates
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class RealEstateDetailsResponseModel : ListedRealEstateResponseModel, IHaveCustomMappings
    {
        public DateTime CreatedOn { get; set; }

        public int ConstructionYear { get; set; }

        public string Address { get; set; }

        public string RealEstateType { get; set; }

        public string Description { get; set; }

        public virtual void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<RealEstate, RealEstateDetailsResponseModel>()
                .ForMember(m => m.RealEstateType, opts => opts.MapFrom(r => r.Type.ToString()));
        }
    }
}
