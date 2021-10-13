using Desafio.Domain.Contracts.Repository;
using Desafio.Domain.Entities;
using Desafio.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Infra.Data.Repository
{
    public class RepositoryCategory: RepositoryBase<Category>, IRepositoryCategory
    {
        public RepositoryCategory(Context context) : base(context){}

        public async Task<Category> GetCategoryWithProduct(Guid id)
                                    => await _dbSet.AsNoTracking()
                                    .Include(p => p.Products)
                                    .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Category>> GetCategoryWithProduct()
                                    => await _dbSet.AsNoTracking()
                                    .Include(p => p.Products)
                                    .ToListAsync();
    }
}
