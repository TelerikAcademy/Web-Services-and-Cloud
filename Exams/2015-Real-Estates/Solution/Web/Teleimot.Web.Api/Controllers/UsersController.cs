namespace Teleimot.Web.Api.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Http;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Infrastructure.Validation;
    using Microsoft.AspNet.Identity;
    using Models.Users;
    using Services.Data.Contracts;

    public class UsersController : ApiController
    {
        private readonly IUsersService users;

        public UsersController(IUsersService users)
        {
            this.users = users;
        }

        public IHttpActionResult Get([Required]string id)
        {
            var result = this.users
                .GetByUserName(id)
                .ProjectTo<UserResponseModel>()
                .FirstOrDefault();

            return this.Ok(result);
        }

        [Authorize]
        [HttpPut]
        [Route("api/Users/Rate")]
        [ValidateModel]
        public IHttpActionResult Rate(RatingRequestModel model)
        {
            if (this.User.Identity.GetUserId() == model.UserId)
            {
                return this.BadRequest("You cannot give rating to yourself!");
            }

            var rating = Mapper.Map<Rating>(model);
            this.users.Rate(rating);
            return this.Ok();
        }
    }
}
