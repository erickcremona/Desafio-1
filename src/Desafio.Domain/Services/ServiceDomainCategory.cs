using Desafio.Domain.Contracts.Repository;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using Desafio.Domain.Validations;

namespace Desafio.Domain.Services
{
    public class ServiceDomainCategory: ServiceDomainBase<Category>, IServiceCategory
    {
        private readonly IRepositoryCategory _repositoryCategory;

        public ServiceDomainCategory(IRepositoryCategory repositoryCategory,
            INotification notification) : base (repositoryCategory, notification)
            => _repositoryCategory = repositoryCategory;

        public void Add(Category category)
            => _repositoryCategory.Add(category);
        

        public void Delete(Category category)
            => _repositoryCategory.Delete(category);
        

        public void Update(Category category)
            => _repositoryCategory.Update(category);
        

        public bool ValidateCategory(Category category) 
            => RunValidation(new CategoryValidation(), category);                      
    }
}
