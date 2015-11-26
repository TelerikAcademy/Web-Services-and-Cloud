namespace Teleimot.Web.Wcf
{
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using Models;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Users : BaseService, IUsers
    {
        public IEnumerable<UserResponseModel> GetAll()
        {
            return this.Users
                .All()
                .OrderByDescending(c => c.Ratings.Average(r => r.Value))
                .Take(10)
                .Select(u => new UserResponseModel
                {
                    UserName = u.UserName,
                    Rating = u.Ratings.Average(r => r.Value)
                })
                .ToList();
        }
    }
}
