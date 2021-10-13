using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Application.Contracts
{
    public interface IApplicationCategory: IApplicationBase<Category>
    {
        void Add(Category category);
        void Update(Category category);
        Task Delete(Category category);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetById(Guid id);
        Task<Category> GetCategoryWithProduct(Guid id);
        Task<IEnumerable<Category>> GetCategoryWithProduct();
    }
}
