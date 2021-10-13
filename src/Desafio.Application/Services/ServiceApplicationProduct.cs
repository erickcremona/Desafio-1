using Desafio.Application.Contracts;
using Desafio.Domain.Contracts.Repository;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Application.Services
{
    public class ServiceApplicationProduct : ServiceApplicationBase<Product>, IApplicationProduct
    {
        private readonly IServiceProduct _serviceProduct;
        private readonly IRepositoryProduct _repositoryProduct;
        private readonly IRepositoryCategory _repositoryCategory;
        private readonly IRepositorySupplier _repositorySupplier;

        public ServiceApplicationProduct(IServiceProduct serviceProduct,
                                         IRepositoryProduct repositoryProduct,
                                         IRepositoryCategory repositoryCategory,
                                         IRepositorySupplier repositorySupplier) :
                                         base(serviceProduct)
        {
            _serviceProduct = serviceProduct;
            _repositoryProduct = repositoryProduct;
            _repositoryCategory = repositoryCategory;
            _repositorySupplier = repositorySupplier;
        }

        public async Task Add(Product product)
        {
            if (await ValidateSupplierCategory(product) == false) return;

            if (_serviceProduct.ValidateProduct(product) && !_serviceProduct.HasNotification())
            {                     
                _serviceProduct.Add(product);
                await _serviceProduct.SaveChanges();
            }
        }


        private async Task<bool> ValidateSupplierCategory(Product product)
        {
            product.SetCategory(await _repositoryCategory.GetByIdAsync(product.CategoryId));
            product.SetSupplier(await _repositorySupplier.GetByIdAsync(product.SupplierId));
            product.SetProduct(product);

            if (product.Category == null)
                _serviceProduct.Notificate("Id da Categoria informado não consta em nossos registros");

            if (product.Supplier == null)
                _serviceProduct.Notificate("Id do Fornecedor informado não consta em nossos registros");

            return !(product.Category == null || product.Supplier == null);
        }


        public async Task Delete(Guid id)
        {
            var product = await _repositoryProduct.GetByIdAsync(id);

            if (product == null) 
                _serviceProduct.Notificate("Produto não encontrado");                        

            if (!_serviceProduct.HasNotification())
            {
                _serviceProduct.Delete(product);
                await _serviceProduct.SaveChanges();
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductWithSupplierCategory()
                     => await _repositoryProduct.GetAllProductWithSupplierCategory();

        public async Task<Product> GetProductWithSupplierCategory(Guid id)
                     => await _repositoryProduct.GetProductWithSupplierCategory(id);

        public async Task Update(Product product)
        {
            var result = await _repositoryProduct.GetByIdAsync(product.Id);
            
            if (result == null)
            {
                _serviceProduct.Notificate("Produto não encontrado"); return;
            }
            
            if (await ValidateSupplierCategory(product) == false) return;

            result.SetCategory(product.Category);
            result.SetSupplier(product.Supplier);
            result.SetProduct(product);

            if (_serviceProduct.ValidateProduct(result) && !_serviceProduct.HasNotification())
            {
                _serviceProduct.Update(result);
                await _serviceProduct.SaveChanges();
            }            
        }
    }
}
