using GarageSmille.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSmille.Infrastructure.Configuration.ConfigMap
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario", "dbo");

            HasKey(k => k.UsuarioId);

            Property(p => p.Nome)
                .IsRequired();

            Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_LoginNameUser", 1) { IsUnique = true })
                        );
            Property(p => p.DataCadastro)
                .HasColumnType("dateTime2");
            Property(p => p.Senha)
                .IsRequired()
                .HasMaxLength(2048);

            HasRequired(p => p.PerfilUsuario)
                .WithMany(c=>c.Usuarios)
                .HasForeignKey(f => f.PerfilUsuarioId);
        }
    }
}
