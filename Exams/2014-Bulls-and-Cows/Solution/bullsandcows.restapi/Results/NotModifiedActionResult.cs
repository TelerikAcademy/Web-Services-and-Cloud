using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BullsAndCows.RestApi.Results
{
    public class NotModifiedActionResult : IHttpActionResult
    {
        public NotModifiedActionResult(HttpRequestMessage request, string message)
        {
            this.Request = request;
            this.Message = message;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(this.ExecuteResult());
        }

        private HttpResponseMessage ExecuteResult()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotModified);
            response.Content = new StringContent(this.Message);
            response.RequestMessage = this.Request;
            return response;
        }

        public HttpRequestMessage Request { get; set; }

        public string Message { get; set; }
    }
}