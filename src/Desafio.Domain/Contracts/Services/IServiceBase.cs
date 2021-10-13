using Desafio.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Desafio.Domain.Contracts.Services
{
    public interface IServiceBase<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(object id);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);        
        Task<int> SaveChanges();
        void Notificate(ValidationResult validationResult);
        void Notificate(string message);
        bool RunValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity;
        bool HasNotification();       
    }
}
