using Desafio.Domain.Contracts.Repository;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using Desafio.Domain.Validations;

namespace Desafio.Domain.Services
{
    public class ServiceDomainProduct: ServiceDomainBase<Product>, IServiceProduct
    {
        private readonly IRepositoryProduct _repositoryProduct;

        public ServiceDomainProduct(IRepositoryProduct repositoryProduct, 
            INotification notification) : base (repositoryProduct, notification)
             => _repositoryProduct = repositoryProduct;
        

        public void Add(Product product)
            => _repositoryProduct.Add(product);
        

        public void Delete(Product product)
            => _repositoryProduct.Delete(product);


        public void Update(Product product)
            => _repositoryProduct.Update(product);

        public bool ValidateProduct(Product product)
            => RunValidation(new ProductValidation(), product);           
    }
}
