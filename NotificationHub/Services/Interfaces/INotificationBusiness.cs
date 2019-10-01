using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Models;

namespace NotificationHub.Interfaces
{
    public interface INotificationBusiness
    {
        List<Notification> getNotifications();
        Notification getNotificationById(int id);
        void addNotification(Notification notification);
        void addExistingNotificationToDevice(int idn, int idd);
        void addNotificationToDevice(Notification notification, int id);
        void addNotificationToGroup(Notification notification, int id);
        void addNotificationToAll(Notification notification);
        void deleteNotificaton(int id);
        void updateNotificaton(Notification notification, int id);
    }
}
