using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Web.Common;
using SourceControlSystem.Api.Infrastructure;
using SourceControlSystem.Data;
using SourceControlSystem.Common.Constants;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SourceControlSystem.Api.App_Start.NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SourceControlSystem.Api.App_Start.NinjectConfig), "Stop")]

namespace SourceControlSystem.Api.App_Start
{
    public static class NinjectConfig 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                ObjectFactory.Initialize(kernel);
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }
        
        private static void RegisterServices(IKernel kernel)
        {
            kernel
                .Bind<ISourceControlSystemDbContext>()
                .To<SourceControlSystemDbContext>()
                .InRequestScope();

            kernel.Bind(typeof(IRepository<>)).To(typeof(EfGenericRepository<>));

            kernel.Bind(b => b.From(Assemblies.DataServices)
                .SelectAllClasses()
                .BindDefaultInterface());
        }        
    }
}
