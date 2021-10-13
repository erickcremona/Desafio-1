using Desafio.Application.Contracts;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using System.Threading.Tasks;

namespace Desafio.Application.Services
{
    public class ServiceApplicationBase<TEntity> : IApplicationBase<TEntity> where TEntity : Entity
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public ServiceApplicationBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }
               
        public async Task<int> SaveChanges()
        {
            return await _serviceBase.SaveChanges();
        }
    }
}
