using System.Collections.Generic;
using Wooza.Entrevista.Dominio.Entidades;

namespace Wooza.Entrevista.Service.Dto
{
    public class DddDto
    {
        //public Guid DddId { get; set; }
        public string DddDigito { get; set; }
        public string DddEstadoSigla { get; set; }
        public string DddCidade { get; set; }

        public virtual ICollection<Plano> Planos { get; set; }

        public DddDto()
        {
            this.Planos = new List<Plano>();
        }
    }
}