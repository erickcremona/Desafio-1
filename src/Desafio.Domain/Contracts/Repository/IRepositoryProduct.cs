using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Domain.Contracts.Repository
{
    public interface IRepositoryProduct: IRepositoryBase<Product>
    {
        Task<Product> GetProductWithSupplierCategory(Guid id);
        Task<IEnumerable<Product>> GetAllProductWithSupplierCategory();
    }
}
