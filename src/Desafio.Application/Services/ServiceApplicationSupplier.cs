using Desafio.Application.Contracts;
using Desafio.Domain.Contracts.Repository;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Application.Services
{
    public class ServiceApplicationSupplier : ServiceApplicationBase<Supplier>, IApplicationSupplier
    {
        private readonly IServiceSupplier _serviceSupplier;
        private readonly IRepositorySupplier _repositorySupplier;
        private readonly IRepositoryAddress _repositoryAddress;
        public ServiceApplicationSupplier(IServiceSupplier serviceSupplier,
                                          IRepositorySupplier repositorySupplier,
                                          IRepositoryAddress repositoryAddress)
                                          : base(serviceSupplier)
        {
            _serviceSupplier = serviceSupplier;
            _repositorySupplier = repositorySupplier;
            _repositoryAddress = repositoryAddress;
        }

        public async Task Add(Supplier supplier)
        {
            if (_serviceSupplier.ValidateSupplierAdd(supplier) && !_serviceSupplier.HasNotification())
            {
                _serviceSupplier.AddAddress(supplier.Address);
                _serviceSupplier.Add(supplier);
                await _serviceSupplier.SaveChanges();
            }
        }

        public async Task Delete(Guid id)
        {
            var supplier = await _serviceSupplier.GetByIdAsync(id);
            if (await _serviceSupplier.ValidateSupplierDelete(supplier) && !_serviceSupplier.HasNotification())
            {
                _serviceSupplier.Delete(supplier);
                await _serviceSupplier.SaveChanges();
            }
        }

        public Task<IEnumerable<Supplier>> GetAll()
            => _repositorySupplier.GetAllAsync();

        public Task<Supplier> GetSuppliersWithAddress(Guid id)
            => _repositorySupplier.GetSuppliersWithAddress(id);

        public Task<Supplier> GetSuppliersWithProductAddress(Guid id)
            => _repositorySupplier.GetSuppliersWithProductAddress(id);


        public async Task Update(Supplier supplier)
        {
            var resultSupplier = await _repositorySupplier.GetByIdAsync(supplier.Id);
            var resultAddress = await _repositoryAddress.GetByIdAsync(supplier.AddressId);

            if (resultSupplier == null)
                _serviceSupplier.Notificate("Fornecedor não localizado");

            if (resultAddress == null)
                _serviceSupplier.Notificate("Endereço não localizado");

            if (_serviceSupplier.ValidateSupplierUpdate(supplier) && !_serviceSupplier.HasNotification())
            {                
                resultAddress.SetAddress(supplier.Address);
                resultSupplier.SetSupplier(supplier);
                _repositoryAddress.Update(resultAddress);
                _serviceSupplier.Update(resultSupplier);
                await _repositorySupplier.SaveChanges();
            }
        }
    }
}
