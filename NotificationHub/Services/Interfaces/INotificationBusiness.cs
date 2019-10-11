using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Models;

namespace NotificationHub.Interfaces
{
    public interface INotificationBusiness
    {
        void addNotification(Notification notification, int id);
    
    }
}
