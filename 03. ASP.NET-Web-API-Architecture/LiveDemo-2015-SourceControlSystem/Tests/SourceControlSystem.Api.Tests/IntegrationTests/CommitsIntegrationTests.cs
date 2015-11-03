namespace SourceControlSystem.Api.Tests.IntegrationTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Controllers;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;

    [TestClass]
    public class CommitsIntegrationTests
    {
        [TestMethod]
        public void ByProjectShouldReturnCorrectResponse()
        {
            // Required by the HttpServer to find controller in another assembly
            var controller = typeof(CommitsController);

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
            );

            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            var httpServer = new HttpServer(config);
            var httpInvoker = new HttpMessageInvoker(httpServer);

            using (httpInvoker)
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://test.com/api/Commits/ByProject/1"),
                    Method = HttpMethod.Get
                };

                var result = httpInvoker.SendAsync(request, CancellationToken.None).Result;

                Assert.IsNotNull(result);
                Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            }
        }
    }
}
