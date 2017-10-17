using GarageSmille.Domain.Entities;
using GarageSmille.Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSmille.Infrastructure.Repositories
{
    public class PerfilUsuarioRepository : RepositoryBase<PerfilUsuario>, IPerfilUsuarioRepository
    {
        public List<Usuario> RetornaUsuairosDoPerfil(int perfilUsuarioId)
        {
            var Perfil = _garageContext.PerfilUsuarios.Where(x => x.PerfilUsuarioId == perfilUsuarioId).FirstOrDefault();
            return Perfil.Usuarios.ToList();
        }
    }
}
