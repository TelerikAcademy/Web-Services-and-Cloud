namespace BullsAndCows.PublicRestApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BullsAndCows.Data.UoWs;
    using BullsAndCows.PublicRestApi.Models;
    using BullsAndCows.RestApi.Wcf;

    public class UsersService : BaseService, IUsersService
    {

        private const int PageSize = 10;
        public UsersService()
            : base()
        {
        }

        public UsersService(IBullsAndCowsData data)
            : base(data)
        {
        }

        public UserDetailsModel GetDetails(string id)
        {
            var user = this.Data.Users.Find(id);
            return UserDetailsModel.FromUser(user);
        }

        public IEnumerable<UserModel> GetPage(string page)
        {
            if (string.IsNullOrEmpty(page))
            {
                page = "0";
            }
            var pageNumber = int.Parse(page);

            return this.Data.Users.All()
                .OrderBy(user => user.UserName.ToLower())
                .Skip(pageNumber * PageSize)
                .Take(PageSize)
                .Select(UserModel.FromUser);
        }
    }
}