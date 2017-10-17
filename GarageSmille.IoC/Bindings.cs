using GarageSmille.Domain.Interface.Domain;
using GarageSmille.Domain.Interface.Infrastructure;
using GarageSmille.Domain.Interface.Repositories;
using GarageSmille.Domain.Service;
using GarageSmille.Infrastructure.Configuration;
using GarageSmille.Infrastructure.Repositories;
using Microsoft.Practices.ServiceLocation;
using SimpleInjector;
using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   
using System.Web.Services.Description;

namespace GarageSmille.IoC
{
    public class Bindings
    {
        public static void Start(Container container)
        {
            //Infraestrutura 
            container.Register<IGerenciadorDeRepositorio, GerenciadorDeRepositorio>();
            container.Register<IUnidadeDeTrabalho, UnidadeDeTrabalhoEF>();
            container.Register(typeof(IRepositoryBase<>),typeof(RepositoryBase<>),Lifestyle.Scoped);
            container.Register(typeof(IUsuarioRepository), typeof(UsuarioRepository), Lifestyle.Scoped);
            container.Register(typeof(IPerfilUsuarioRepository), typeof(PerfilUsuarioRepository), Lifestyle.Scoped);

            //Dominio
            container.Register(typeof(IServicoDeUsuarioDomain), typeof(ServicoDeUsuarioDomain), Lifestyle.Scoped);

            //Application

            //service locator
            //ServiceLocator.SetLocatorProvider();
        }
    }
}
