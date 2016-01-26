[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TheCodeBookProject.Web.App.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(TheCodeBookProject.Web.App.NinjectWebCommon), "Stop")]

namespace TheCodeBookProject.Web.App
{
    using System;
    using System.Web;
    
    using Data;
    using Data.Repositories.Contracts;
    using Data.Repositories;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;
    using TheCodeBookProject.Common;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static Action<IKernel> DependenciesRegistration = kernel =>
        {
            kernel
                .Bind<ITheCodeBookProjectDbContext>()
                .To<TheCodeBookProjectDbContext>().InRequestScope();

            kernel
                .Bind(typeof(IRepository<>))
                .To(typeof(GenericRepository<>));
        };

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
            DependenciesRegistration(kernel);
            kernel.Bind(b => b
                .From(Assemblies.Services)
                .SelectAllClasses()
                .BindDefaultInterface());
        }
    }
}
