using Desafio.Domain.Notifications;
using System.Collections.Generic;

namespace Desafio.Domain.Contracts.Services
{
    public interface INotification
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
