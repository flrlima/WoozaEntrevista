using System.Data.Entity;
using Wooza.Entrevista.Dominio.Entidades;
using Wooza.Entrevista.Infraestrutura.Data.EntityConfig;

namespace Wooza.Entrevista.Infraestrutura.Data.Contexto
{
    public class WoozaEntrevistaContexto : DbContext
    {
        public WoozaEntrevistaContexto()
            : base("WoozaEntrevista_Desenvolvimento")
        {

        }
        public DbSet<Plano> Plano { get; set; }
        public DbSet<DDD> DDD { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new PlanoConfiguration());
            modelBuilder.Configurations.Add(new DDDConfiguration());
        }

    }
}
