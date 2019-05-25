
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace SistemaLembrete.Core.Notifications
{
    public class NotificationContext
    {
        private readonly List<Notification> _notifications;
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public bool HasNotifications => _notifications.Any();

        public NotificationContext()
        {
            _notifications = new List<Notification>();
        }

        public void Add(string key, string message)
        {
            _notifications.Add(new Notification(key, message));
        }

        public void Add(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void Add(IEnumerable<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void Add(IReadOnlyCollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void Add(IList<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void Add(ICollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void Add(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Add(error.ErrorCode, error.ErrorMessage);
            }
        }
    }
}
