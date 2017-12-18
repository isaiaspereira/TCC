
using Autofac;
using Autofac.Integration.Mvc;
using GarageSmille.Domain.Entities;
using GarageSmille.Domain.Interface.Domain;
using GarageSmille.Domain.Interface.Infrastructure;
using GarageSmille.Domain.Interface.Repositories;
using GarageSmille.Domain.Service;
using GarageSmille.Infrastructure.Configuration;
using GarageSmille.Infrastructure.Repositories;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GarageSmille_Ui
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //AutoMapperConfig.RegisterMapper();


            #region dependencyinjector

            var builder = new ContainerBuilder();
            //register mvc controller
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //registrando as logica de negocio
            //Exemplo de Implementaçao
            //builder.RegisterType<ExemplesBL>().As<IBusinessLogic<Exemple>>.instancePerRequest();

            //Registrando os serviços 
            //builder.RegisterType<ExempleService>().As<IexampleService>().InstancePerRequest();

            builder.RegisterType<IRepositoryBase<Usuario>>().As<RepositoryBase<Usuario>>().InstancePerLifetimeScope();
            builder.RegisterType<RepositoryBase<PerfilUsuario>>().As<IRepositoryBase<PerfilUsuario>>().InstancePerRequest();
            builder.RegisterType<RepositoryBase<ModuloAcesso>>().As<IRepositoryBase<ModuloAcesso>>().InstancePerRequest();
            builder.RegisterType<IUsuarioRepository>().As<UsuarioRepository>().InstancePerRequest();
            builder.RegisterType<IServicoDeUsuarioDomain>().As<ServicoDeUsuarioDomain>().InstancePerRequest();
            builder.RegisterType<IGerenciadorDeRepositorio>().As<GerenciadorDeRepositorio>().InstancePerRequest();
            builder.RegisterType<IPerfilUsuarioRepository>().As<PerfilUsuarioRepository>().InstancePerRequest();
            builder.RegisterType<IUnidadeDeTrabalho>().As<UnidadeDeTrabalhoEF>().InstancePerRequest();

            var conteiner = builder.Build();

            //configurando mvc DI Resolver para o AutoFac Container

            DependencyResolver.SetResolver(new AutofacDependencyResolver(conteiner));
            #endregion
        }
    }
}
