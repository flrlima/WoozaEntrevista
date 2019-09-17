using System;
using System.Collections.Generic;
using Wooza.Entrevista.Dominio.Entidades;
using Wooza.Entrevista.Dominio.Enum;

namespace Wooza.Entrevista.Service.Dto
{
    public class PlanoDto
    {
        public Guid PlanoDtoId { get; set; }
        public int CodigoDoPlano { get; set; }
        public int Minuto { get; set; }
        public double FranquiaDeInternet { get; set; }
        public double Valor { get; set; }
        public TipoPlanoEnum Tipo { get; set; }
        public OperadoraEnum Operadora { get; set; }
        public virtual ICollection<string> DddDigito { get; set; }

        public PlanoDto()
        {
            this.DddDigito = new List<string>();
        }
    }
    public class CodigoDoPlanoDto
    {
        public int CodigoDoPlano { get; set; }
    }
}