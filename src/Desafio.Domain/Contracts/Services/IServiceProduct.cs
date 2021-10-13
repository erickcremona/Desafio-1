using Desafio.Domain.Entities;

namespace Desafio.Domain.Contracts.Services
{
    public interface IServiceProduct: IServiceBase<Product>
    {
        void Add(Product product);
        void Update(Product product);                
        void Delete(Product product);
        bool ValidateProduct(Product product);
    }
}
