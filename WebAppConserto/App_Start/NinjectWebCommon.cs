[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(GarageSmille_Ui.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(GarageSmille_Ui.App_Start.NinjectWebCommon), "Stop")]

namespace GarageSmille_Ui.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using GarageSmille.Domain.Interface.Repositories;
    using GarageSmille.Infrastructure.Repositories;
    using GarageSmille.Domain.Interface.Domain;
    using GarageSmille.Domain.Service;
    using GarageSmille.Domain.Interface.Infrastructure;
    using GarageSmille.Infrastructure.Configuration;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
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

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind(typeof(IUsuarioRepository)).To(typeof(UsuarioRepository));
            kernel.Bind(typeof(IServicoDeUsuarioDomain)).To(typeof(ServicoDeUsuarioDomain));
            kernel.Bind(typeof(IGerenciadorDeRepositorio)).To(typeof(GerenciadorDeRepositorio));
            kernel.Bind(typeof(IPerfilUsuarioRepository)).To(typeof(PerfilUsuarioRepository));
            kernel.Bind(typeof(IUnidadeDeTrabalho)).To(typeof(UnidadeDeTrabalhoEF));
        }        
    }
}
