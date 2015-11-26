namespace Teleimot.Web.Api.Tests.RouteTests
{
    using System.Net.Http;
    using Common.Constants;
    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;

    [TestClass]
    public class CommentsTests
    {
        [TestMethod]
        public void ByUserShouldResolveProperlyWithDefaultSkipAndTake()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Comments/ByUser/TestUser")
                .WithHttpMethod(HttpMethod.Get)
                .To<CommentsController>(
                    c => c.ByUser(
                        "TestUser", 
                        CommentConstants.DefaultCommentSkip,
                        CommentConstants.DefaultCommentTake));
        }

        [TestMethod]
        public void ByUserShouldResolveProperlyWithCustomSkip()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Comments/ByUser/TestUser?skip=15")
                .WithHttpMethod(HttpMethod.Get)
                .To<CommentsController>(
                    c => c.ByUser(
                        "TestUser",
                        15,
                        CommentConstants.DefaultCommentTake));
        }

        [TestMethod]
        public void ByUserShouldResolveProperlyWithCustomTake()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Comments/ByUser/TestUser?take=15")
                .WithHttpMethod(HttpMethod.Get)
                .To<CommentsController>(
                    c => c.ByUser(
                        "TestUser",
                        CommentConstants.DefaultCommentSkip,
                        15));
        }

        [TestMethod]
        public void ByUserShouldResolveProperlyWithCustomSkipAndTake()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Comments/ByUser/TestUser?skip=15&take=15")
                .WithHttpMethod(HttpMethod.Get)
                .To<CommentsController>(
                    c => c.ByUser(
                        "TestUser",
                        15,
                        15));
        }

        [TestMethod]
        public void ByUserShouldNotResolveWithoutUsername()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Comments/ByUser")
                .WithHttpMethod(HttpMethod.Get)
                .ToInvalidModelState();
        }
    }
}
