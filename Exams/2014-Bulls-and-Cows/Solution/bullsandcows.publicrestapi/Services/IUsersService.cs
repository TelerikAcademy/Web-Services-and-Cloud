using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BullsAndCows.PublicRestApi.Models;

namespace BullsAndCows.PublicRestApi.Services
{
    // NOTE: Red can use the "Rename" command on the "Refactor" menu to change the interface name "IUsersService" in both code and config file together.
    [ServiceContract]
    public interface IUsersService
    {
        [WebGet(UriTemplate="?page={page}")]
        [OperationContract]
        IEnumerable<UserModel> GetPage(string page ="0");
        
        [WebGet(UriTemplate = "/{id}")]
        [OperationContract]
        UserDetailsModel GetDetails(string id);        
    }
}
