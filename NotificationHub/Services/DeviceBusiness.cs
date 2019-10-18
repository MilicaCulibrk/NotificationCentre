using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotificationHub.Controllers;
using NotificationHub.Database;
using NotificationHub.Interfaces;
using NotificationHub.Models;
using NotificationHub.Services;

namespace NotificationHub
{
    public class DeviceBusiness : IDeviceBusiness
    {
        public NotificationCentreContext context;
        public List<Device> devices;
        public Group grp;
        public Device dvc; 
        List<Notification> notifications = new List<Notification>();

        public DeviceBusiness()   //ako nema u bazi nista, kreiraj
        {
            using (context = new NotificationCentreContext())
            {
                context.Database.EnsureCreated();
            }
        }

        //register new device
        public void RegisterDevice(Device device)
        {
            using (context = new NotificationCentreContext())
            {
                context.Database.EnsureCreated();
                context.Devices.Add(device);

                context.SaveChanges();
            }
        }

        //list available
        public List<Device> ListDevices()
        {
            using (context = new NotificationCentreContext())
            {
                devices = context.Devices.Include(a => a.Group).Include(x => x.NotificationDevices).ToList();
            }
            return devices;
        }

        //get device by id
        public Device GetDeviceById(int DeviceId)
        {
            Device device;

            using (context = new NotificationCentreContext())
            {
                device = context.Devices.FirstOrDefault(u => u.DeviceId.Equals(DeviceId));
            }
            return device;
        }

        //delete deviceb
        public void DeleteDevice(int id)
        {
            using (context = new NotificationCentreContext())
            {
                var nds = context.NotificationDevices
               .Where(x => x.DeviceId == id);

                context.RemoveRange(nds);

                context.Remove(context.Devices.Single(a => a.DeviceId.Equals(id)));
                context.SaveChanges();
            }
        }

        //update device
        public void UpdateDevice([FromBody] Device device, int id)
        {
            Device dev;

            using (context = new NotificationCentreContext())
            {
                {
                    dev = context.Devices.First(u => u.DeviceId.Equals(id));
                    dev.DeviceName = device.DeviceName;
                    context.SaveChanges();
                }
            }
        }

        public List<Notification> ListNotificationsFromDevice(int id)
        {

            using (context = new NotificationCentreContext())
            {
                var nd = context.NotificationDevices.Where(x => x.DeviceId == id); //nasli smo sve veze izmedju tog devica i njegovih notifikacija
                notifications.Clear();

                foreach (var notdev in nd)
                {
                    Notification ntf = context.Notifications.FirstOrDefault(x => x.NotificationId == notdev.NotificationId); //sve notifikacije dodaj u listu
                    if (ntf.Received.Equals(false))
                    {
                        notifications.Add(ntf);
                        ntf.Received = true;
                        context.SaveChanges();
                    }
                }
            }
            return notifications;
        }
    }
}
