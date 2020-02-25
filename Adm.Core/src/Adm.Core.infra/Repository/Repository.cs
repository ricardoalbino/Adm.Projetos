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

        //Injeção
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = dataContext.Set<TEntity>();

        }

        public async Task adicionarAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public async  Task Atualizar(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Dispose()
        {
            _dataContext?.Dispose();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            
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

        public async  Task<int> SaveChanges()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }
}
