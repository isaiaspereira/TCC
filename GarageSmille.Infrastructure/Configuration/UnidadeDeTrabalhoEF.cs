using CommonServiceLocator;
using GarageSmille.Domain.Interface.Infrastructure;
using GarageSmille.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSmille.Infrastructure.Configuration
{
    public class UnidadeDeTrabalhoEF : IUnidadeDeTrabalho
    {
        private GarageContext _contexto;
        public void Iniciar()
        {
            var gerenciardor = ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorio>()
                as GerenciadorDeRepositorio;
            _contexto = gerenciardor.Contexto;
        }

        public void Persistir()
        {
            _contexto.SaveChanges();
        }
    }
}
