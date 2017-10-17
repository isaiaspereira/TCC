using GarageSmille.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSmille.Infrastructure.Configuration.ConfigMap
{
    public class ModuloAcessoMap : EntityTypeConfiguration<ModuloAcesso>
    {
        public ModuloAcessoMap()
        {
            ToTable("ModuloAcesso", "dbo");

            HasKey(p => p.ModuloId);

            Property(p => p.NomeModulo)
                .IsRequired();

            Property(p => p.NomeMenuAcesso)
                    .IsRequired();

            Property(p => p.URL)
                .IsRequired()
                .HasMaxLength(300);

            HasMany(m => m.PerfilUsuarios)
                .WithMany(m => m.ModuloAcessos)
                .Map(m =>
                {
                    m.ToTable("PerfilModulos", "dbo");
                    m.MapLeftKey("ModuloId");
                    m.MapRightKey("PerfilUsuarioId");
                });
        }
    }
}
