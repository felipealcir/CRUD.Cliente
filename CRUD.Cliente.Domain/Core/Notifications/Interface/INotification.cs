using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Cliente.Domain.Core.Notifications.Interface
{
    public interface INotification<TNotification> where TNotification : class
    {
        void AddNotification(DomainNotification message);
        List<DomainNotification> GetNotifications();
        bool HasNotifications();
        void Dispose();
    }
}
