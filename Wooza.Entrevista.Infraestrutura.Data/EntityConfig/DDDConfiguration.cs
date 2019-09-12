using System.Data.Entity.ModelConfiguration;
using Wooza.Entrevista.Dominio.Entidades;

namespace Wooza.Entrevista.Infraestrutura.Data.EntityConfig
{
    public class DDDConfiguration : EntityTypeConfiguration<DDD>
    {
        public DDDConfiguration()
        {
            HasKey(d => d.DddId);

            Property(d => d.DddDigito)
                .IsRequired()
                .HasMaxLength(2);

            Property(d => d.DddEstadoSigla)
                .IsRequired()
                .HasMaxLength(2);
                       
            Property(d => d.DddEstadoSigla)
                .IsRequired()
                .HasMaxLength(80);

            ToTable("DDD");
        }
    }
}
