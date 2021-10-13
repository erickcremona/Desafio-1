using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Application.Contracts
{
    public interface IApplicationSupplier: IApplicationBase<Supplier>
    {
        Task Add(Supplier supplier);
        Task Update(Supplier supplier);
        Task Delete(Guid id);
        Task<Supplier> GetSuppliersWithProductAddress(Guid id);
        Task<Supplier> GetSuppliersWithAddress(Guid id);
        Task<IEnumerable<Supplier>> GetAll();
    }
}
