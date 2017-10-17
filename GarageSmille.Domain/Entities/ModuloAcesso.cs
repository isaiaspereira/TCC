using System;
using System.Collections.Generic;

namespace GarageSmille.Domain.Entities
{
    public class ModuloAcesso
    {
        public ModuloAcesso()
        {
            this.PerfilUsuarios = new List<PerfilUsuario>();

        }
        public int ModuloId { get; set; }
        public string NomeModulo { get; set; }
        public string NomeMenuAcesso { get; set; }
        public string URL { get; set; }
        public bool FlAtivo { get; set; }
        public DateTime DataCadastro{ get; set; }
        public int? ModuloPai { get; set; }
        public virtual ModuloAcesso ModuloAcessos { get; set; }
        public virtual ICollection<PerfilUsuario> PerfilUsuarios { get; set; }

    }
}