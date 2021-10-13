using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Domain.Contracts.Repository
{
    public interface IRepositoryCategory: IRepositoryBase<Category>
    {
        Task<IEnumerable<Category>> GetCategoryWithProduct();
        Task<Category> GetCategoryWithProduct(Guid id);
    }
}
