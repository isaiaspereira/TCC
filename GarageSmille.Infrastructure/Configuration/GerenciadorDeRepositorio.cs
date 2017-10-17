using GarageSmille.Domain.Interface.Infrastructure;
using GarageSmille.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GarageSmille.Infrastructure.Configuration
{
   public class GerenciadorDeRepositorio:IGerenciadorDeRepositorio
    {
        public const string ContextoHttp = "ContextoHttp";

        public GarageContext Contexto
        {
            get
            {
                if (HttpContext.Current.Items[ContextoHttp] == null)
                    HttpContext.Current.Items[ContextoHttp] = new GarageContext();
                return HttpContext.Current.Items[ContextoHttp] as GarageContext;
            }
        }

        public void Finalizar()
        {
            if (HttpContext.Current.Items[ContextoHttp] != null)
                (HttpContext.Current.Items[ContextoHttp] as GarageContext).Dispose();
        }
    }
}
