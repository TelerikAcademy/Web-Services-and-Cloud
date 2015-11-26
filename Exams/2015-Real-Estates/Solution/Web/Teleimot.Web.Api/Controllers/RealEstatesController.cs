namespace Teleimot.Web.Api.Controllers
{
    using System.Collections;
    using System.Linq;
    using System.Web.Http;
    using AutoMapper;
    using Common.Constants;
    using Infrastructure.Validation;
    using Services.Data.Contracts;
    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models.RealEstates;

    public class RealEstatesController : ApiController
    {
        private readonly IRealEstatesService realEstates;

        public RealEstatesController(IRealEstatesService realEstates)
        {
            this.realEstates = realEstates;
        }

        [ValidateTake]
        public IHttpActionResult Get(
            int skip = RealEstateConstants.DefaultRealEstateSkip,
            int take = RealEstateConstants.DefaultRealEstateTake)
        {
            var result = this.realEstates
                .GetAll(skip, take)
                .ProjectTo<ListedRealEstateResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var query = this.realEstates.GetById(id);
            RealEstateDetailsResponseModel result;
            if (this.User.Identity.IsAuthenticated)
            {
                result = query
                    .ProjectTo<AuthenticatedRealEstateDetailsResponseModel>()
                    .FirstOrDefault();
            }
            else
            {
                result = query
                    .ProjectTo<RealEstateDetailsResponseModel>()
                    .FirstOrDefault();
            }

            return this.Ok(result);
        }

        [Authorize]
        [ValidateModel]
        public IHttpActionResult Post(RealEstateRequestModel model)
        {
            var newRealEstate = Mapper.Map<RealEstate>(model);
            var id = this.realEstates.AddNew(newRealEstate, this.User.Identity.GetUserId());

            var result = this.realEstates
                .GetById(id)
                .ProjectTo<ListedRealEstateResponseModel>()
                .FirstOrDefault();

            return this.Created($"/api/RealEstates/{id}", result);
        }
    }
}
