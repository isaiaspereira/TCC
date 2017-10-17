using GarageSmille.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSmille.Infrastructure.Configuration.Initializer
{
    public class UserDatabaseInitializer
    {
        public static List<ModuloAcesso> GetModulos()
        {
            var Modulos = new List<ModuloAcesso>
            {
                new ModuloAcesso
                {
                    ModuloId=1,
                    FlAtivo=true,
                    NomeMenuAcesso="Administrativo",
                    NomeModulo="Administrador",
                    URL="#",
                    DataCadastro=DateTime.Now,
                    ModuloPai=1
                },
                 new ModuloAcesso
                {
                    ModuloId=2,
                    FlAtivo=true,
                    NomeMenuAcesso="Financeiro",
                    NomeModulo="Financeiro",
                    URL="#",
                    ModuloPai=1
                }
            };
            return Modulos;
        }
        public static List<PerfilUsuario> GetPerfilUsuario()
        {
            var PerfilUsuario = new List<PerfilUsuario>
            {
                new PerfilUsuario
                {
                    PerfilUsuarioId=1,
                    DataCadastro=DateTime.Now,
                    AdminMaster=true,
                    Ativo=true,
                    NomePerfil="Administrador Master",
                    ModuloAcessos=GetModulos()
                }
            };
            return PerfilUsuario;
        }

    }
}
