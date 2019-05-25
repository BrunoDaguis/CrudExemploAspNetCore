using FluentValidation.Results;
using System.Collections.Generic;

namespace SistemaLembrete.Core.Notifications.Interfaces
{
    public interface INotificationContext
    {
        void Add(string key, string message);
        
        void Add(Notification notification);
        
        void Add(IEnumerable<Notification> notifications);
        
        void Add(IReadOnlyCollection<Notification> notifications);
        
        void Add(IList<Notification> notifications);
        

        void Add(ICollection<Notification> notifications);
        
        void Add(ValidationResult validationResult);
        
    }
}
