using Desafio.Domain.Contracts.Repository;
using Desafio.Domain.Entities;
using Desafio.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Infra.Data.Repository
{
    public class RepositorySupplier : RepositoryBase<Supplier>, IRepositorySupplier
    {
        public RepositorySupplier(Context context) : base(context){ }

        public Task<Supplier> GetSuppliersWithAddress(Guid id)
            => _dbSet.AsNoTracking()
                .Include(p => p.Address)
                .SingleOrDefaultAsync(p => p.Id == id);

        public Task<Supplier> GetSuppliersWithProductAddress(Guid id)
            => _dbSet.AsNoTracking()
                .Include(p => p.Products)
                .Include(p => p.Address)
                .SingleOrDefaultAsync(p => p.Id == id);
    }
}
