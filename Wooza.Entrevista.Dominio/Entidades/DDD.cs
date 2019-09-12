using System;
using System.Collections.Generic;

namespace Wooza.Entrevista.Dominio.Entidades
{
    public class DDD
    {
        public Guid DddId { get; set; }
        public string DddDigito { get; set; }
        public string DddEstadoSigla { get; set; }
        public string DddCidade { get; set; }

        public virtual ICollection<Plano> Planos { get; set; }

        public DDD()
        {
            this.Planos = new List<Plano>();
        }
    }
}
