namespace BullsAndCows.PublicRestApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    using BullsAndCows.PublicRestApi.Models;

    [ServiceContract]
    public interface IScoresService
    {
        [WebInvoke(Method = "GET", UriTemplate = "")]
        [OperationContract]
        IEnumerable<UserScoreModel> GetAll();        
    }
}
