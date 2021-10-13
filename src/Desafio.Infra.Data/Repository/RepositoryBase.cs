using Desafio.Domain.Contracts.Repository;
using Desafio.Domain.Entities;
using Desafio.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Desafio.Infra.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        private readonly Context _context;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(Context context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity) 
            => _dbSet.Add(entity);
        

        public void Delete(TEntity entity) 
            => _dbSet.Remove(entity);
        

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _dbSet.ToListAsync();
        

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
            => await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        

        public async Task<TEntity> GetByIdAsync(object id)
            => await _dbSet.FindAsync(id);


        public async Task<int> SaveChanges()
            => await _context.SaveChangesAsync();


        public void Update(TEntity entity)
            => _dbSet.Update(entity);
        
    }
}
