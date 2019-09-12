using System;
using System.Collections.Generic;
using Wooza.Entrevista.Dominio.Entidades;
using Wooza.Entrevista.Infraestrutura.Data;

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
        public Plano Listar(Guid id)
        {
            return _planoRepository.Listar(id);
        }

        public IEnumerable<Plano> ListarTodos()
        {
            return _planoRepository.ListarTodos();
        }

        public void Remover(Guid id)
        {
            _planoRepository.Remover(id);
        }

        public void Atualizar(Guid id, Plano plano)
        {
            _planoRepository.Atualizar(id, plano);
        }
    }
}
