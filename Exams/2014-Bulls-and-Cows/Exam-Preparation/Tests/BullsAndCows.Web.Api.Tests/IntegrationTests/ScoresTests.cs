namespace BullsAndCows.Web.Api.Tests.IntegrationTests
{
    using Models.HighScore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using System.Net;
    using System.Net.Http;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class ScoresTests
    {
        private static IServerBuilder server;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            server = MyWebApi.Server().Starts<Startup>();
        }

        [TestMethod]
        public void ScoresShouldReturnCorrectResponse()
        {
            server
                .WithHttpRequestMessage(req => req
                    .WithMethod(HttpMethod.Get)
                    .WithRequestUri("/api/Scores"))
                .ShouldReturnHttpResponseMessage()
                .WithStatusCode(HttpStatusCode.OK)
                .WithResponseModelOfType<List<HighScoreResponseModel>>()
                .Passing(model =>
                {
                    Assert.AreEqual(10, model.Count);

                    var current = model.First().Rank;
                    for (int i = 1; i < model.Count; i++)
                    {
                        Assert.IsTrue(model[i].Rank <= current);
                        current = model[i].Rank;
                    }
                });
        }

        [ClassCleanup]
        public static void Clean()
        {
            MyWebApi.Server().Stops();
        }
    }
}
