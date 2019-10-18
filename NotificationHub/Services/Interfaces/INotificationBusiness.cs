using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Models;

namespace NotificationHub.Interfaces
{
    public interface INotificationBusiness
    {
        //add notification to device
        void addNotificationToDevice(Notification notification, int id);
        //add notification to group
        void addNotificationToGroup(Notification notification, int id);
        //list notifications
        List<Notification> ListNotifications();
        //get notification by id
        Notification GetNotificationById(int id);
        //update notification
        void UpdateNotification(Notification notification, int id);
        //delete notification
        void DeleteNotification(int id);
        //delete notification from device
        void DeleteNotificationFromDevice(int idn, int idd);
        //delete all notifications from device
        void DeleteAllNotificationFromDevice(int idd);
    }
}
