using Desafio.Domain.Entities;
using System.Threading.Tasks;

namespace Desafio.Application.Contracts
{
    public interface IApplicationBase<TEntity> where TEntity : Entity
    {        
        Task<int> SaveChanges();
    }
}
