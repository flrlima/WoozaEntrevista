using System.Data.Entity.ModelConfiguration;
using Wooza.Entrevista.Dominio.Entidades;

namespace Wooza.Entrevista.Infraestrutura.Data.EntityConfig
{
    public class PlanoConfiguration : EntityTypeConfiguration<Plano>
    {
        public PlanoConfiguration()
        {
            HasKey(p => p.PlanoId);

            HasMany(s => s.Ddds)
                .WithMany(c => c.Planos)
                .Map(cs =>
                {
                    cs.MapLeftKey("PlanoId");
                    cs.MapRightKey("DDDId");
                    cs.ToTable("PlanoDDD");
                });


            ToTable("Planos");
        }
    }
}
