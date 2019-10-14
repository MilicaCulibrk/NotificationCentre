using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Models;
using NotificationHub.Interfaces;
using NotificationHub.Services;
using NotificationHub.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace NotificationHub
{
    public class NotificationBusiness : INotificationBusiness
    {
        public NotificationCentreContext context;
        public List<Notification> notifications;
        public List<Device> devices;
        public void addNotificationToDevice(Notification notification, int id)
        {


            Device device;
            
            using (context = new NotificationCentreContext())
            {
          
                device = context.Devices.First(u => u.DeviceId.Equals(id));
                context.NotificationDevices.Add(new NotificationDevice { notification = notification, device = device});
                context.Notifications.Add(notification);
                context.SaveChanges();
            }
        }

        public void addNotificationToGroup(Notification notification, int id)
        {

            Group group;

            using (context = new NotificationCentreContext())
            {
                var devices = context.Devices
                  .Where(x => x.Group.GroupId == id);

                foreach (Device d in devices)
                {
                    context.NotificationDevices.Add(new NotificationDevice { notification = notification, device = d });
                }

                /* devices = context.Devices.(u => u.Group.GroupId.Equals(id)).ToList();

                 foreach(Device d in devices)
                 {
                     context.NotificationDevices.Add(new NotificationDevice { notification = notification, device = d });
                 }*/

                context.Notifications.Add(notification);
                context.SaveChanges();
            }
        }
        

        public List<Notification> ListNotifications()
        {
            
            using (context = new NotificationCentreContext())
            {

                notifications = context.Notifications.Include(a => a.NotificationDevices).ToList();


            }

            return notifications;
        }

        public Notification GetNotificationById(int id)
        {
            Notification notification;

            using (context = new NotificationCentreContext())
            {
                notification = context.Notifications.FirstOrDefault(u => u.NotificationId.Equals(id));
            }

            if (notification == null)
            {
                return null;
            }
            else
            {
                return notification;
            }


        }

        //update notification
        public void UpdateNotification(Notification notification, int id)
        {
            Notification ntf;

            using (context = new NotificationCentreContext())
            {
                ntf = context.Notifications.First(u => u.NotificationId.Equals(id));

         
                ntf.Tip = notification.Tip;
                ntf.Message = notification.Message;
                notification.Scope = notification.Scope;
                context.SaveChanges();
            }
        }

        //delete notification
        public void DeleteNotification(int id)
        {
            using (context = new NotificationCentreContext())
            {
              

                var nds = context.NotificationDevices
                .Where(x => x.NotificationId == id);

                
               context.NotificationDevices.RemoveRange(nds);
   
         
                context.Remove(context.Notifications.Single(a => a.NotificationId.Equals(id)));
                context.SaveChanges();
            }
        }

        //delete notification from device
        public void DeleteNotificationFromDevice(int idn, int idd)
        {
            using (context = new NotificationCentreContext())
            {


                context.Remove(context.NotificationDevices.Single(a => a.NotificationId.Equals(idn) && a.DeviceId.Equals(idd)));
       
                context.SaveChanges();
            }
        }

        //delete all notification from device
        public void DeleteAllNotificationFromDevice(int idd)
        {
            using (context = new NotificationCentreContext())
            {


                context.Remove(context.NotificationDevices.Single(a => a.DeviceId.Equals(idd)));

                context.SaveChanges();
            }
        }

        //delete notification from group
        public void DeleteAllNotificationFromGroup(int idg)
        {
            using (context = new NotificationCentreContext())
            {
                var nds = context.NotificationDevices
              .Where(x => x.device.Group.GroupId == idg);


                context.NotificationDevices.RemoveRange(nds);



                //context.Remove(context.NotificationDevices.Single(a => a.DeviceId.Equals(idd)));

                context.SaveChanges();
            }
        }


    }

}
