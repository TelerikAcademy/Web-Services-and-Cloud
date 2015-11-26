namespace Teleimot.Web.Api.Tests.ControllerTests
{
    using System.Collections.Generic;
    using System.Net.Http;
    using Common.Constants;
    using Controllers;
    using Infrastructure.Validation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Comments;
    using MyTested.WebApi;
    using Setups;

    [TestClass]
    public class CommentsControllerTests
    {
        private static IControllerBuilder<CommentsController> controller;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            controller = MyWebApi
                .Controller<CommentsController>()
                .WithResolvedDependencies(Services.CommentsService);
        }

        [TestMethod]
        public void CommentsControllerShouldHaveAuthorizedHttpGetRouteAndValidateTakeAttribute()
        {
            controller
                .Calling(c => c.ByUser(With.Any<string>(), With.Any<int>(), With.Any<int>()))
                .ShouldHave()
                .ActionAttributes(attrs => attrs
                    .RestrictingForRequestsWithMethod(HttpMethod.Get)
                    .ChangingRouteTo("api/Comments/ByUser/{id}")
                    .ContainingAttributeOfType<ValidateTakeAttribute>());
        }

        [TestMethod]
        public void CommentsControllerShouldOkWithCorrectResponseModelsWithDefaultSkipAndTake()
        {
            controller
                .Calling(c => c.ByUser(
                    "TestUser",
                    CommentConstants.DefaultCommentSkip,
                    CommentConstants.DefaultCommentTake))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<CommentResponseModel>>()
                .Passing(c => c.Count == CommentConstants.DefaultCommentTake);
        }
    }
}
