using GarageSmille.Domain.Entities;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace GarageSmille.Domain.Interface.Domain
{
   public interface IServicoDeUsuarioDomain
    {
        Usuario LogaUsuario(string email,string senha);
        Usuario ResuperaUsuarioPorEmail(string email);
        List<Usuario> RecuperaUsuariosDoPerfil(int PerfiId);
        List<PerfilUsuario> RecuperaTodosPerfisAtivos();
        void CadastrarUsuario(Usuario usuario);
    }
}
