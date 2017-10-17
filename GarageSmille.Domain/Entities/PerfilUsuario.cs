using System;
using System.Collections;
using System.Collections.Generic;

namespace GarageSmille.Domain.Entities
{
    public class PerfilUsuario
    {
        public PerfilUsuario()
        {
            this.ModuloAcessos = new List<ModuloAcesso>();
            this.Usuarios = new List<Usuario>();
        }
        public int PerfilUsuarioId { get; set; }
        public string NomePerfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool AdminMaster { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<Usuario> Usuarios{ get; set; }
        public virtual ICollection<ModuloAcesso> ModuloAcessos{ get; set; }
    }
}