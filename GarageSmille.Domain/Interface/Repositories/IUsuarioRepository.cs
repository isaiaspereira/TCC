using GarageSmille.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSmille.Domain.Interface.Repositories
{
   public interface IUsuarioRepository:IRepositoryBase<Usuario>
    {
        Usuario RecuperarUsuarioPorEmail(string email);
        Usuario LogarUsuario(string email,string senha);
        void CadastraUsuario(Usuario usuario);
    }
}
