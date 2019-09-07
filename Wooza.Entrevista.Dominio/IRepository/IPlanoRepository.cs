using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wooza.Entrevista.Dominio.IRepository
{
    public interface IPlanoRepository<TEntity>
    {
        void Salvar(TEntity entity);
        IEnumerable<TEntity> ListarTodos();
        TEntity Listar(Guid id);
        void Remover(Guid id);
        void Atualizar(TEntity entity);
    }
}
