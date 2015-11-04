namespace SourceControlSystem.Api.Tests.NetworkIntegrationTests
{
    using Microsoft.Owin.Hosting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [TestClass]
    public class CommitsNetworkIntegrationTests
    {
        [TestMethod]
        public void ByProjectShouldReturnCorrectResponse()
        {
            using (var webApp = WebApp.Start<Startup>("http://localhost:1234"))
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://localhost:1234");

                    var result = httpClient.GetAsync("api/Commits/ByProject/1").Result;

                    Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
                }

                webApp.Dispose();
            }
        }
    }
}
