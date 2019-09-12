using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wooza.Entrevista.Dominio.Entidades;
using Wooza.Entrevista.Dominio.Enum;
using Wooza.Entrevista.Infraestrutura.Data;

namespace Wooza.Entrevista.Infraestrutura.Business.Business
{
    public class PesquisaBusiness
    {
        public readonly PesquisaRepository _pesquisaRepository;
        public PesquisaBusiness()
        {
            _pesquisaRepository = new PesquisaRepository();
        }

        public List<Plano> BuscarPorTipo(TipoPlanoEnum tipo)
        {            
            return _pesquisaRepository.BuscarPorTipo(tipo);
        }
        public List<Plano> BuscarPorOperadora(OperadoraEnum operadora)
        {
            return _pesquisaRepository.BuscarPorOperadora(operadora);
        }
    }
}
