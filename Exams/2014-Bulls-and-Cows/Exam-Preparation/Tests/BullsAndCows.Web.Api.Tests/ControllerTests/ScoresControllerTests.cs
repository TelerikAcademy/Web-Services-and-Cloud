namespace BullsAndCows.Web.Api.Tests.ControllerTests
{
    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using BullsAndCows.Web.Api.Tests.Setups;
    using System.Collections.Generic;
    using System.Linq;
    using Models.HighScore;

    [TestClass]
    public class ScoresControllerTests
    {
        private IControllerBuilder<ScoresController> controller;

        [TestInitialize]
        public void Init()
        {
            this.controller = MyWebApi
                .Controller<ScoresController>()
                .WithResolvedDependencies(Services.GetHighScoreService());
        }

        [TestMethod]
        public void GetShouldReturnCorrectHighScore()
        {
            controller
                .Calling(c => c.Get())
                .ShouldReturn()
                .Ok()
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
    }
}
