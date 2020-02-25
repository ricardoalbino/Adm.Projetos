using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Adm.Core.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity :  class
    {
        Task adicionarAsync(TEntity  entity);
        Task Atualizar(TEntity entity);
        Task Remover(TEntity entity);
        Task<List<TEntity>> ObterTodos();
        Task<TEntity> ObterPorId(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();

    }
}
