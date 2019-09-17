using System;
using System.Collections.Generic;
using Wooza.Entrevista.Dominio.Entidades;
using Wooza.Entrevista.Infraestrutura.Data;
using Wooza.Entrevista.Service.Dto;

namespace Wooza.Entrevista.Infraestrutura.Business.Business
{
    public class PlanoBusiness
    {
        public readonly PlanoRepository _planoRepository;
        public PlanoBusiness()
        {
            _planoRepository = new PlanoRepository();
        }
        public void Salvar(Plano plano)
        {
            _planoRepository.Salvar(plano);
        }
        public Plano Listar(int codigoDoPlano)
        {
            return _planoRepository.Listar(codigoDoPlano);
        }

        public IEnumerable<PlanoDto> ListarTodos()
        {
            var todos = _planoRepository.ListarTodos();
            return DddDomainToDto(todos);
        }

        public void Remover(Guid id)
        {
            _planoRepository.Remover(id);
        }

        public void Atualizar(Guid id, Plano plano)
        {
            _planoRepository.Atualizar(id, plano);
        }

        private IEnumerable<PlanoDto> DddDomainToDto(IEnumerable<Plano> planos)
        {
            List<PlanoDto> lista = new List<PlanoDto>();
            PlanoDto planoDTO;

            foreach (var plano in planos)
            {
                planoDTO = new PlanoDto();

                planoDTO.PlanoDtoId = plano.PlanoId;
                planoDTO.CodigoDoPlano = plano.CodigoDoPlano;
                planoDTO.Minuto = plano.Minuto;
                planoDTO.FranquiaDeInternet = plano.FranquiaDeInternet;
                planoDTO.Valor = plano.Valor;
                planoDTO.Tipo = plano.Tipo.ToString();
                planoDTO.Operadora = plano.Operadora.ToString();
                foreach (var pl in plano.Ddds)
                {

                    planoDTO.DddDigito.Add(pl.DddDigito.ToString());

                }

                lista.Add(planoDTO);
            }
            return lista;

        }
    }
}
