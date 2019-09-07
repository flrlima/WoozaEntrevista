using System.Data.Entity;
using Wooza.Entrevista.Dominio.Entidades;

namespace Wooza.Entrevista.Infraestrutura.Data.Contexto
{
    public class WoozaEntrevistaContexto : DbContext
    {
        public WoozaEntrevistaContexto()
            : base("WoozaEntrevista_Desenvolvimento")
        {

        }
        public DbSet<Plano> Plano { get; set; }
    }
}
