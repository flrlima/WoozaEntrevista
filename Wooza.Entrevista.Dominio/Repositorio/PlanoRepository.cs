using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Wooza.Entrevista.Dominio.Entidades;
using Wooza.Entrevista.Infraestrutura.Data.Contexto;

namespace Wooza.Entrevista.Dominio.Repositorio
{
    public class PlanoRepository
    {
        private readonly WoozaEntrevistaContexto _context;
        public PlanoRepository()
        {
            _context = new WoozaEntrevistaContexto();
        }
        public void Salvar(Plano plano)
        {
            plano.PlanoId = Guid.NewGuid();
            _context.Plano.Add(plano);
            _context.SaveChanges();
        }

        public Plano Listar(Guid id)
        {
            var plano = _context.Plano.Find(id);
            return plano;
        }

        public IEnumerable<Plano> ListarTodos()
        {
            return _context.Plano.ToList();
        }

        public void Atualizar(Guid id, Plano plano)
        {
            plano.PlanoId = id;
            _context.Entry(plano).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remover(Guid id)
        {
            var plano = _context.Plano.Find(id);
            _context.Plano.Remove(plano);
        }
    }
}
