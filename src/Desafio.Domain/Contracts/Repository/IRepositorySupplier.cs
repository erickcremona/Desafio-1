using Desafio.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Desafio.Domain.Contracts.Repository
{
    public interface IRepositorySupplier: IRepositoryBase<Supplier>
    {
        Task<Supplier> GetSuppliersWithProductAddress(Guid id);
        Task<Supplier> GetSuppliersWithAddress(Guid id);
    }
}
