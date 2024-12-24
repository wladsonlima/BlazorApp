using System.Collections.Generic;
using Flunt.Notifications;

namespace Global.Shared.Entities
{
    public class InvalidCommandData
    { 
        public InvalidCommandData(IReadOnlyCollection<Notification> errors)
        {
            Errors = errors;
        }

        public IReadOnlyCollection<Notification> Errors { get; }
        
    }
}