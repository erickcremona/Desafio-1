using Desafio.Domain.Contracts.Repository;
using Desafio.Domain.Entities;
using Desafio.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Infra.Data.Repository
{
    public class RepositoryProduct : RepositoryBase<Product>, IRepositoryProduct
    {
        public RepositoryProduct(Context context) : base(context)
        {

        }

        public async Task<IEnumerable<Product>> GetAllProductWithSupplierCategory()
                => await _dbSet.AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToListAsync();

        public async Task<Product> GetProductWithSupplierCategory(Guid id)
                => await _dbSet.AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.Id == id);
    }
}
