using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wooza.Entrevista.Dominio.Enum;

namespace Wooza.Entrevista.Dominio.Entidades
{
    public class Plano
    {        
        public Guid PlanoId { get; set; }
        public int CodigoDoPlano { get; set; }
        public int Minuto { get; set; }
        public double FranquiaDeInternet { get; set; }
        public double Valor { get; set; }
        public TipoPlanoEnum Tipo { get; set; }
        public OperadoraEnum Operadora { get; set; }
    }
}
