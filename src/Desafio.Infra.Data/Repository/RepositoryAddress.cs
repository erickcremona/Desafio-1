using Desafio.Domain.Contracts.Repository;
using Desafio.Domain.Entities;
using Desafio.Infra.Data.Contexts;

namespace Desafio.Infra.Data.Repository
{
    public class RepositoryAddress: RepositoryBase<Address>, IRepositoryAddress
    {
        public RepositoryAddress(Context context) : base(context)
        {

        }

       
    }
}
