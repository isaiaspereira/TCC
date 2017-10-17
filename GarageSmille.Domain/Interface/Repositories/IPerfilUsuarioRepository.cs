using GarageSmille.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSmille.Domain.Interface.Repositories
{
   public interface IPerfilUsuarioRepository:IRepositoryBase<PerfilUsuario>
    {
        List<Usuario> RetornaUsuairosDoPerfil(int PerfilUsuarioId);
    }
}
