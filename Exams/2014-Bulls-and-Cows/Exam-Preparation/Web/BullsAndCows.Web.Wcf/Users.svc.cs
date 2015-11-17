using BullsAndCows.Web.Wcf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BullsAndCows.Web.Wcf
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Users : BaseService, IUsers
    {
        public IEnumerable<ListedUserModel> GetAll(string page)
        {
            // TODO: validate
            var pageAsNumber = int.Parse(page);

            return this.Users
                .All()
                .OrderBy(u => u.Email)
                .Skip(pageAsNumber * 10)
                .Take(10)
                .Select(u => new ListedUserModel
                {
                    Id = u.Id,
                    Username = u.Email
                })
                .ToList();
        }
    }
}
