namespace Teleimot.Web.Api.Tests
{
    using Common.Constants;
    using Data.Models;
    using Data.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Setups;

    [TestClass]
    public class TestInit
    {
        [AssemblyInitialize]
        public static void Init(TestContext testContext)
        {
            NinjectConfig.DependenciesRegistration = kernel =>
            {
                kernel.Bind<IRepository<Comment>>().ToConstant(Repositories.CommentsRepository);
            };

            AutoMapperConfig.RegisterMappings(Assemblies.WebApi);
            MyWebApi.IsRegisteredWith(WebApiConfig.Register);
        }
    }
}
