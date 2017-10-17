using GarageSmille.Domain.Entities;
using GarageSmille.Infrastructure.Configuration;
using GarageSmille.Infrastructure.Configuration.ConfigMap;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSmille.Infrastructure.Context
{
    public class GarageContext : DbContext
    {
        public GarageContext() : base("GarageContext")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PerfilUsuario> PerfilUsuarios { get; set; }
        public DbSet<ModuloAcesso> ModulosAcesso { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.Name == p.PropertyType.Name + "Id").Configure(t => t.IsKey());
            modelBuilder.Properties<string>().Configure(c => c.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(200));
            modelBuilder.Properties<DateTime>().Where(p => p.Name == "DataCadastro").Configure(c => c.HasColumnType("dateTime2"));
            modelBuilder.Properties<string>().Where(p => p.Name == "Descricao").Configure(c => c.HasMaxLength(400));
            modelBuilder.Properties<string>().Where(p => p.Name == "UF").Configure(c => c.HasMaxLength(2));

            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new PerfilUsuarioMap());
            modelBuilder.Configurations.Add(new ModuloAcessoMap());

            base.OnModelCreating(modelBuilder);

        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
