using Desafio.Application.Contracts;
using Desafio.Domain.Contracts.Repository;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Application.Services
{
    public class ServiceApplicationCategory : ServiceApplicationBase<Category>, IApplicationCategory
    {
        IServiceCategory _serviceCategory;
        IRepositoryCategory _repositoryCategory;

        public ServiceApplicationCategory(IServiceCategory serviceCategory,
                                          IRepositoryCategory repositoryCategory) :
                                          base(serviceCategory)
        {
            _serviceCategory = serviceCategory;
            _repositoryCategory = repositoryCategory;
        }

        public void Add(Category category)
        {
            if (_serviceCategory.ValidateCategory(category))
            {
                category = category.CategoryVerifier(category);
                _serviceCategory.Add(category);
                _serviceCategory.SaveChanges();
            }
        }

        public async Task Delete(Category category)
        {            
            if (category.Products.Any())
            {
                _serviceCategory.Notificate("Não é possível excluir Categoria com Produtos cadastrados");
                return;
            }
            _serviceCategory.Delete(category);
            await _serviceCategory.SaveChanges();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
            => await _repositoryCategory.GetAllAsync();
        
        public async Task<Category> GetById(Guid id)
            => await _repositoryCategory.GetByIdAsync(id);
        
        public async Task<Category> GetCategoryWithProduct(Guid id)
            => await _repositoryCategory.GetCategoryWithProduct(id);

        public async Task<IEnumerable<Category>> GetCategoryWithProduct()
            => await _repositoryCategory.GetCategoryWithProduct();

        public void Update(Category category)
        {
            if (_serviceCategory.ValidateCategory(category))
            {
                category = category.CategoryVerifier(category);
                _serviceCategory.Update(category);
                _serviceCategory.SaveChanges();
            }
        }             
    }
}
