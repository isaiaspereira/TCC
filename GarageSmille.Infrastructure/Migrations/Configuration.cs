namespace GarageSmille.Infrastructure.Migrations
{
    using GarageSmille.Infrastructure.Configuration.Initializer;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.GarageContext context)
        {
            if(context.PerfilUsuarios.Where(x=>x.NomePerfil=="Administrador Master").Count()==0)
            UserDatabaseInitializer.GetPerfilUsuario().ForEach(c => context.PerfilUsuarios.Add(c));

            //deletar todos os stored procs, views
            foreach (var file in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug", ""), "Sql\\Seed"), "*.sql"))
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(file), new object[0]);       
            }

            //adicionando um stored procidores
            foreach (var file in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug", ""), "Sql\\StoredProcs"), "*.sql"))
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(file), new object[0]);
            }
        }
    }
}
