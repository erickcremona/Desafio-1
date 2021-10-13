using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Application.Contracts
{
    public interface IApplicationProduct: IApplicationBase<Product>
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(Guid id);
        Task<Product> GetProductWithSupplierCategory(Guid id);
        Task<IEnumerable<Product>> GetAllProductWithSupplierCategory();
        
    }
}
