using GarageSmille.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSmille.Infrastructure.Configuration.ConfigMap
{ 
    public class PerfilUsuarioMap : EntityTypeConfiguration<PerfilUsuario>
    {
        public PerfilUsuarioMap()
        {
            ToTable("PerfilUsuario", "dbo");

            HasKey(k => k.PerfilUsuarioId);

            Property(p => p.NomePerfil)
                .IsRequired();
            Property(p => p.DataCadastro)
                .HasColumnType("dateTime2");
        }
    }
}
