using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Models;
using NotificationHub.Interfaces;
using NotificationHub.Services;
using NotificationHub.Database;

namespace NotificationHub
{
    public class NotificationBusiness : INotificationBusiness
    {
        public NotificationCentreContext context;
        public void addNotification(Notification notification, int id)
        {

            Notification ntf = new Notification(notification.NotificationId, notification.Tip, notification.Message, notification.Scope);

            Device device;
            
            using (context = new NotificationCentreContext())
            {
                device = context.Devices.First(u => u.DeviceId.Equals(id));
                device.Notifications.Add(ntf);
                context.Notifications.Add(ntf);
                context.SaveChanges();
            }
        }
    }
  
}
