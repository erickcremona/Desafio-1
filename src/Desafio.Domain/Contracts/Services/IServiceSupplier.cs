using Desafio.Domain.Entities;
using System.Threading.Tasks;

namespace Desafio.Domain.Contracts.Services
{
    public interface IServiceSupplier: IServiceBase<Supplier>
    {
        void Add(Supplier supplier);
        void AddAddress(Address address);
        void UpdateAddress(Address address);
        void Update(Supplier supplier);
        void Delete(Supplier supplier);
        bool ValidateSupplierAdd(Supplier supplier);
        bool ValidateSupplierUpdate(Supplier supplier);
        Task<bool> ValidateSupplierDelete(Supplier supplier);
    }
}
