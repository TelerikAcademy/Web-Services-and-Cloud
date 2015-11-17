using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Tests.Api.Models;

namespace Tests.Api.ServiceContracts
{
    [ServiceContract]
    public interface ISearchService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "/search?pattern={pattern}")]
        IQueryable<SearchResultResponseModel> Search(string pattern);

        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "/search-question?pattern={pattern}")]
        IQueryable<SearchResultResponseModel> SearchQuestions(string pattern);

        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "/search-category?pattern={pattern}")]
        IQueryable<SearchResultResponseModel> SearchCategories(string pattern);
    }
}
