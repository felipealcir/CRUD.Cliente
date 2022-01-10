using CRUD.Cliente.Domain.Core.Notifications.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.Cliente.Domain.Core.Notifications
{
    public class Notification : INotification<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public Notification()
        {
            _notifications = new List<DomainNotification>();
        }

        public void AddNotification(DomainNotification message)
        {
            _notifications.Add(message);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro: {message.Key} - {message.Value}");
        }

        public virtual List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }
        public virtual bool HasNotifications()
        {
            return _notifications.Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}
