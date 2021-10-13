using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Desafio.Api.ControllersMain
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotification _notification;

        public MainController(INotification notification)
        {
            _notification = notification;
        }

        protected bool ValidOperation()
        {
            return !_notification.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notification.GetNotifications().Select(n => n.Message)
            });
        }

       

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyInvalidModelError(modelState);
            return CustomResponse();
        }

        protected void NotifyInvalidModelError(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(errorMsg);
            }
        }

        protected void NotifyError(string message)
        {
            _notification.Handle(new Notification(message));
        }
    }
}
