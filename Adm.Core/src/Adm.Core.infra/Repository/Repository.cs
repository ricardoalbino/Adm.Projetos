using Adm.Core.Domain.Interfaces;
using Adm.Core.infra.Context;
using Microsoft.EntityFrameworkCore;
using RA.School.Proj.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RA.School.Proj.Infra.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly DataContext _dataContext;
        protected readonly DbSet<TEntity> _dbSet;

        public async Task  adicionarAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public async  Task Atualizar(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> buscarAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Dispose()
        {
            
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            //Ajustar
            return await _dbSet.FirstAsync();
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Remover(TEntity entity)
        {
            _dbSet.Remove(new TEntity { Id = entity.Id });
            await SaveChanges();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
