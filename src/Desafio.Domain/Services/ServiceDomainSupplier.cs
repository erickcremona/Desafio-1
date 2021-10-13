using Desafio.Domain.Contracts.Repository;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using Desafio.Domain.Validations;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Domain.Services
{
    public class ServiceDomainSupplier : ServiceDomainBase<Supplier>, IServiceSupplier
    {
        private readonly IRepositorySupplier _repositorySupplier;
        private readonly IRepositoryAddress _repositoryAddress;

        public ServiceDomainSupplier(IRepositorySupplier repositorySupplier, INotification notification, IRepositoryAddress repositoryAddress) : base(repositorySupplier, notification)
        {
            _repositorySupplier = repositorySupplier;
            _repositoryAddress = repositoryAddress;
        }

        public void Add(Supplier supplier)
            => _repositorySupplier.Add(supplier);

        public void AddAddress(Address address)
            => _repositoryAddress.Add(address);

        public void Delete(Supplier supplier)
            => _repositorySupplier.Delete(supplier);
        

        public void Update(Supplier supplier)
            => _repositorySupplier.Update(supplier);

        public void UpdateAddress(Address address)
            => _repositoryAddress.Update(address);

        public bool ValidateSupplierAdd(Supplier supplier)
        {
            if (!RunValidation(new SupplierValidation(), supplier)
                || !RunValidation(new AddressValidation(), supplier.Address)) return false;

            if (_repositorySupplier.GetAsync(s => s.Document == supplier.Document).Result.Any())
            {
                Notificate("Já existe um fornecedor com este documento informado.");
                return false;
            }

            return true;
        }

        public async Task<bool> ValidateSupplierDelete(Supplier supplier)
        {
            if (_repositorySupplier.GetSuppliersWithProductAddress(supplier.Id).Result.Products.Any())
            {
                Notificate("O fornecedor possui produtos cadastrados!");
                return false;
            }

            var address = await _repositoryAddress.GetByIdAsync(supplier.AddressId);

            if (address != null)
            {
                _repositoryAddress.Delete(address);
            }

            return true;
        }

        public bool ValidateSupplierUpdate(Supplier supplier)
        {
            if (!RunValidation(new SupplierValidation(), supplier)
                || !RunValidation(new AddressValidation(), supplier.Address)) return false;

            if (_repositorySupplier.GetAsync(s => s.Document == supplier.Document && s.Id != supplier.Id).Result.Any())
            {
                Notificate("Já existe um fornecedor com este documento informado.");
                return false;
            }

            return true;
        }
    }
}
