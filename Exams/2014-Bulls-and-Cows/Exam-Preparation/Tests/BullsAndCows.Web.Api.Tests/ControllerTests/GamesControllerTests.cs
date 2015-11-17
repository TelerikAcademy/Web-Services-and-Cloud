namespace BullsAndCows.Web.Api.Tests.ControllerTests
{
    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BullsAndCows.Web.Api.Tests.Setups;
    using MyTested.WebApi;
    using Models.Games;
    using System.Collections.Generic;
    using Common.Constants;

    [TestClass]
    public class GamesControllerTests
    {
        [TestMethod]
        public void GetShouldReturnWaitingForOponentGamesWithoutAuthenticatedUser()
        {
            MyWebApi
                .Controller<GamesController>()
                .WithResolvedDependencies(Services.GetGamesService(), Services.GetGuessService())
                .Calling(c => c.Get("1"))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<ListedGameResponseModel>>()
                .Passing(model => model.Count == GameConstants.GamesPerPage);
        }

        [TestMethod]
        public void GetShouldReturnWaitingForOponentGamesWithoutAuthenticatedUserAndPaging()
        {
            MyWebApi
                .Controller<GamesController>()
                .WithResolvedDependencies(Services.GetGamesService(), Services.GetGuessService())
                .Calling(c => c.Get("100"))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<ListedGameResponseModel>>()
                .Passing(model => model.Count == 0);
        }
    }
}
