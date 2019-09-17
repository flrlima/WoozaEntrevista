using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wooza.Entrevista.Dominio.Entidades;
using Wooza.Entrevista.Infraestrutura.Data.Repositorio;
using Wooza.Entrevista.Service.Dto;

namespace Wooza.Entrevista.Infraestrutura.Business.Business
{
    public class DddBusiness
    {
        public readonly DddRepository _dddRepository;
        public DddBusiness()
        {
            _dddRepository = new DddRepository();
        }
        public void Salvar(DDD ddd)
        {
            _dddRepository.Salvar(ddd);
        }
        public DDD Listar(string DddDigito)
        {
            return _dddRepository.Listar(DddDigito);
        }

        public IEnumerable<DddDto> ListarTodos()
        {
            var todos = _dddRepository.ListarTodos();
            return DddDomainToDto(todos);
        }

        public void Remover(Guid id)
        {
            _dddRepository.Remover(id);
        }

        public void Atualizar(Guid id, DDD ddd)
        {
            _dddRepository.Atualizar(id, ddd);
        }

        private IEnumerable<DddDto> DddDomainToDto(IEnumerable<DDD> ddds)
        {
            List<DddDto> lista = new List<DddDto>();
            DddDto dddDTO;

            foreach (var ddd in ddds)
            {
                dddDTO = new DddDto();

                dddDTO.DddId = ddd.DddId;
                dddDTO.DddDigito = ddd.DddDigito;
                dddDTO.DddEstadoSigla = ddd.DddEstadoSigla;
                dddDTO.DddCidade = ddd.DddCidade;
                foreach (var d in ddd.Planos)
                {

                    dddDTO.CodigoDoPlanoDto.Add(d.CodigoDoPlano.ToString());

                }

                lista.Add(dddDTO);
            }
            return lista;

        }
    }
}
