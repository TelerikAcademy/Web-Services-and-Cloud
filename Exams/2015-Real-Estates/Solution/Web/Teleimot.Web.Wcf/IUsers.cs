namespace Teleimot.Web.Wcf
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using Models;

    [ServiceContract]
    public interface IUsers
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "top.svc")]
        IEnumerable<UserResponseModel> GetAll();
    }
}
