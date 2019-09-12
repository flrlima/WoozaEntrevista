using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wooza.Entrevista.Dominio.Entidades;
using Wooza.Entrevista.Dominio.Enum;
using Wooza.Entrevista.Infraestrutura.Data.Contexto;

namespace Wooza.Entrevista.Infraestrutura.Data
{
    public class PesquisaRepository
    {
        private readonly WoozaEntrevistaContexto _context;
        public PesquisaRepository()
        {
            _context = new WoozaEntrevistaContexto();
        }

        public List<Plano> BuscarPorTipo(TipoPlanoEnum tipo)
        {
            List<Plano> planos = _context.Plano.Where(x => x.Tipo == tipo).ToList();
            return planos;
        }
        
        public List<Plano> BuscarPorOperadora(OperadoraEnum operadora)
        {
            List<Plano> planos = _context.Plano.Where(x => x.Operadora == operadora).ToList();
            return planos;
        }
    }
}
