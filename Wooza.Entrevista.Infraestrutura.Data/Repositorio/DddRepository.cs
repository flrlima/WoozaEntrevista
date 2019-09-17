using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wooza.Entrevista.Dominio.Entidades;
using Wooza.Entrevista.Infraestrutura.Data.Contexto;

namespace Wooza.Entrevista.Infraestrutura.Data.Repositorio
{
    public class DddRepository
    {
        private readonly WoozaEntrevistaContexto _context;
        public DddRepository()
        {
            _context = new WoozaEntrevistaContexto();
        }
        public void Salvar(DDD ddd)
        {
            ddd.DddId = Guid.NewGuid();
            _context.DDD.Add(ddd);
            _context.SaveChanges();
        }

        public DDD Listar(string DddDigito)
        {
            var ddd = _context.DDD.Where(x => x.DddDigito == DddDigito);
            return ddd.FirstOrDefault();
        }

        public IEnumerable<DDD> ListarTodos()
        {
            return _context.DDD.ToList();
        }

        public void Atualizar(Guid id, DDD ddd)
        {
            ddd.DddId = id;
            _context.Entry(ddd).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remover(Guid id)
        {
            var plano = _context.Plano.Find(id);
            _context.Plano.Remove(plano);
        }
    }
}
