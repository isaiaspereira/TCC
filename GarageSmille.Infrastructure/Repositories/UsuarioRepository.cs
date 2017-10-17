using GarageSmille.Domain.Entities;
using GarageSmille.Domain.Interface.Repositories;
using ProjetoDDD.Infrastructure.Data.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSmille.Infrastructure.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public void CadastraUsuario(Usuario usuario)
        {
            usuario.Senha = Crypto.EncryptStringAES(usuario.Senha,usuario.SenhaKey);
            _garageContext.Usuarios.Add(usuario);
            _garageContext.SaveChanges();
        }

        public Usuario LogarUsuario(string email, string senha)
        {
            var LogInUsuario = _garageContext.Usuarios.Where(x => x.Email == email).FirstOrDefault();
            if (LogInUsuario == null)
                return null;
            string passDecrypt = Crypto.DecryptStringAES(LogInUsuario.Senha, LogInUsuario.SenhaKey);
            if (passDecrypt == senha)
                return LogInUsuario;
            else
                return null;
        }

        public Usuario RecuperarUsuarioPorEmail(string email)
        {
            var usuario = _garageContext.Usuarios.Where(x => x.Email == email).FirstOrDefault();
            return usuario;
        }
    }
}
