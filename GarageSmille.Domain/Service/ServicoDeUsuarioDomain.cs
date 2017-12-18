using GarageSmille.Domain.Interface.Domain;
using System.Collections.Generic;
using GarageSmille.Domain.Entities;
using GarageSmille.Domain.Interface.Repositories;
using System.Linq;
using System;
using GarageSmille.Domain.Interface.Infrastructure;
using System.Threading.Tasks;

namespace GarageSmille.Domain.Service
{
    public class ServicoDeUsuarioDomain : IServicoDeUsuarioDomain
    {
        private readonly IUsuarioRepository _repositoryUsuario;
        private readonly IPerfilUsuarioRepository _repositoryPerfil;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

        public ServicoDeUsuarioDomain(IUsuarioRepository repository, IPerfilUsuarioRepository repositoryPerfil, IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            _repositoryUsuario = repository;
            _repositoryPerfil = repositoryPerfil;
            _unidadeDeTrabalho = unidadeDeTrabalho;
        }

        public Usuario LogaUsuario(string email, string senha)
        {
            
            return _repositoryUsuario.LogarUsuario(email, senha); 
        }

        public List<PerfilUsuario> RecuperaTodosPerfisAtivos()
        {
            return _repositoryPerfil.GetAll().Where(a => a.Ativo&& !a.AdminMaster).ToList();
        }

        public List<Usuario> RecuperaUsuariosDoPerfil(int PerfilId)
        {
            return _repositoryPerfil.RetornaUsuairosDoPerfil(PerfilId);
        }

        public Usuario ResuperaUsuarioPorEmail(string email)
        {
            return  _repositoryUsuario.RecuperarUsuarioPorEmail(email);
        }
        public void CadastrarUsuario(Usuario usuario)
        {
            try
            {
                _repositoryUsuario.CadastraUsuario(usuario);
                

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
