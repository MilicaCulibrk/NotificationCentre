using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Models;
using NotificationHub.Interfaces;
using NotificationHub.Services;

namespace NotificationHub
{
    public class NotificationBusiness : INotificationBusiness
    {
        public static List<Notification> registerdNotifications = new List<Notification>();  //u ovu listu cu smestati registrovane notifikacije

        public List<Notification> getNotifications()
        {
            if (registerdNotifications.Count == 0)
            {

                registerdNotifications.Add(new Notification(Models.Type.INFO, "Poruka1", Models.Scope.DEVICE));
                registerdNotifications.Add(new Notification(Models.Type.WARNING, "Poruka2", Models.Scope.GROUP));
                registerdNotifications.Add(new Notification(Models.Type.URGENT, "Poruka3", Models.Scope.GROUP));
            }

            return registerdNotifications;
        }

        public Notification getNotificationById(int id)
        {
            foreach (Notification n in registerdNotifications)
            {
                if (n.NotId == id)
                {
                    return n;
                }
            }

            return null;

        }

        public void addNotification(Notification notification)
        {
            Notification notif = new Notification(notification.Type, notification.Message, notification.Scope);
            registerdNotifications.Add(notif);
        }

        public void addNotificationToDevice(Notification notification, int id)
        {
            Notification notif = new Notification(notification.Type, notification.Message, notification.Scope);
            registerdNotifications.Add(notif);

            foreach (Device d in DeviceBusiness.registerdDevices)
            {
                if (d.DeviceId == id)
                {
                    d.Notifications.Add(notification);
                }
            }
        }

        public void addNotificationToGroup(Notification notification, int id)
        {
            Notification notif = new Notification(notification.Type, notification.Message, notification.Scope);
            registerdNotifications.Add(notif);

            foreach (Group g in GroupBusiness.groups)
            {
                if (g.GroupId == id)
                {
                    foreach (Device d in g.Devices)
                    {
   
                         d.Notifications.Add(notif);

                    }
                }
            }
        }

        public void addNotificationToAll(Notification notification)
        {
            Notification notif = new Notification(notification.Type, notification.Message, notification.Scope);
            registerdNotifications.Add(notif);

            foreach (Group g in GroupBusiness.groups)
            {
                foreach (Device d in g.Devices)
                {
                    d.Notifications.Add(notif);
                }
            }

        }

    }
}
