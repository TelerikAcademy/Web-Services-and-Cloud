using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tests.Api.Models;
using Tests.Models;

namespace Tests.Api
{
    [ServiceContract]
    public interface IQuestionsService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
                    UriTemplate = "/questions",
                    ResponseFormat = WebMessageFormat.Json)]
        IQueryable<QuestionResponseModel> GetAll();

        [OperationContract]
        [WebInvoke(Method = "GET",
                    UriTemplate = "/questions/{id}")]
        QuestionResponseModel GetById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    UriTemplate = "/questions")]
        QuestionResponseModel AddQuestion(QuestionRequestModel question);
    }
}
