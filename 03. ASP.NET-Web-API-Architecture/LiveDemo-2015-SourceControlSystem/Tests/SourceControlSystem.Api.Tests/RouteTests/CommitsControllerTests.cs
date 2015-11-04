namespace SourceControlSystem.Api.Tests.RouteTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyWebApi;
    using Controllers;
    using System.Web.Http;

    [TestClass]
    public class CommitsControllerTests
    {
        [TestMethod]
        public void ByProjectIdShouldMapToCorrectAction()
        {
            MyWebApi
                .Routes()
                .ShouldMap("/api/Commits/ByProject/1")
                .To<CommitsController>(c => c.GetByProjectId(1));
        }
    }
}
