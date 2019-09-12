namespace Wooza.Entrevista.Dominio.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Wooza.Entrevista.Infraestrutura.Data.Contexto.WoozaEntrevistaContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //ContextKey = "Wooza.Entrevista.Infraestrutura.Data.Contexto.WoozaEntrevistaContexto";
        }

        protected override void Seed(Wooza.Entrevista.Infraestrutura.Data.Contexto.WoozaEntrevistaContexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
