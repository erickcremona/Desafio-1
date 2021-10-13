using Desafio.Domain.Contracts.Repository;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using Desafio.Domain.Notifications;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Desafio.Domain.Services
{
    public class ServiceDomainBase<TEntity> : IServiceBase<TEntity> where TEntity : Entity
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        private readonly INotification _notification;
             
        public ServiceDomainBase(IRepositoryBase<TEntity> repositoryBase, INotification notification)
        {
            _repositoryBase = repositoryBase;
            _notification = notification;
        }

       

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _repositoryBase.GetAllAsync();
        

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
            => await _repositoryBase.GetAsync(predicate);
        

        public async Task<TEntity> GetByIdAsync(object id)
            => await _repositoryBase.GetByIdAsync(id);
                

        public async Task<int> SaveChanges()
            => await _repositoryBase.SaveChanges();
        


        public void Notificate(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)            
                Notificate(error.ErrorMessage);
        }

        public void Notificate(string message)
            => _notification.Handle(new Notification(message));
        

        public bool RunValidation<TV, TE>(TV validation, TE entity)
            where TV : AbstractValidator<TE>
            where TE : Entity
        {
            var validator = validation.Validate(entity);                     
            Notificate(validator);
            return validator.IsValid;
        }

        public bool HasNotification()
            => _notification.HasNotification();
    }
}
