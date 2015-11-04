namespace SourceControlSystem.Api.Tests.ControllerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Controllers;
    using System.Web.Http.Results;
    using Models.Commits;
    using System.Collections.Generic;
    using Services.Data.Contracts;
    using System.Net.Http;
    using System.Net;
    using System.Web.Http;
    using TestObjects;
    using MyWebApi;

    [TestClass]
    public class CommitsControllerTests
    {
        private ICommitsService commitsService;

        [TestInitialize]
        public void Init()
        {
            this.commitsService = TestObjectFactory.GetCommitsService();
        }

        [TestMethod]
        public void GetByProjectIdShouldReturnOkResultWithData()
        {
            var controller = new CommitsController(this.commitsService);

            var result = controller.GetByProjectId(1);

            var okResult = result as OkNegotiatedContentResult<List<ListedCommitResponseModel>>;

            Assert.IsNotNull(okResult);

            Assert.AreEqual(1, okResult.Content.Count);
        }

        [TestMethod]
        public void UserHasCommitsShouldReturnUnauthorizedStatusCodeWithNoRequestHeader()
        {
            var controller = new CommitsController(this.commitsService);
            controller.Request = new HttpRequestMessage();

            var result = controller.UserHasCommits("Some username");

            Assert.AreEqual(HttpStatusCode.Unauthorized, result.StatusCode);
        }

        [TestMethod]
        public void UserHasCommitsShouldReturnFoundStatusCodeWithRequestHeader()
        {
            //MyWebApi
            //    .Controller<CommitsController>()
            //    .WithResolvedDependencyFor(this.commitsService)
            //    .WithHttpRequestMessage(req => req.WithHeader("MyCustomHeader", "MyValue"))
            //    .WithAuthenticatedUser()
            //    .ShouldHave()
            //    .Attributes(attr => attr.ChangingRoutePrefixTo("api/Commits"));

            //MyWebApi
            //    .Controller<CommitsController>()
            //    .WithResolvedDependencyFor(this.commitsService)
            //    .WithHttpRequestMessage(req => req.WithHeader("MyCustomHeader", "MyValue"))
            //    .WithAuthenticatedUser()
            //    .Calling(c => c.UserHasCommits("User with commit"))
            //    .ShouldReturn()
            //    .HttpResponseMessage()
            //    .ContainingHeader("Location", "http://telerikacademy.com")
            //    .WithContentOfType<ObjectContent<bool>>();

            var controller = new CommitsController(this.commitsService);
            var request = new HttpRequestMessage();
            request.Headers.Add("MyCustomHeader", "MyValue");
            controller.Request = request;
            controller.Configuration = new HttpConfiguration();
            controller.User = new MockedIPrinciple();

            var result = controller.UserHasCommits("User with commit");

            Assert.AreEqual(HttpStatusCode.Found, result.StatusCode);

            var resultAsBool = result.Content as ObjectContent<bool>;
            var contentAsBool = resultAsBool.ReadAsAsync<bool>().Result;

            Assert.AreEqual(true, contentAsBool);

            var responseHeaderLocation = result.Headers.Location;

            Assert.AreEqual("http://telerikacademy.com", responseHeaderLocation.OriginalString);
        }
    }
}
