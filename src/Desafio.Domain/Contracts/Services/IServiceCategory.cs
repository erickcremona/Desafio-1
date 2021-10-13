using Desafio.Domain.Entities;
using Desafio.Domain.Validations;
using FluentValidation;

namespace Desafio.Domain.Contracts.Services
{
    public interface IServiceCategory: IServiceBase<Category>
    {
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        bool ValidateCategory(Category category);
    }
}
