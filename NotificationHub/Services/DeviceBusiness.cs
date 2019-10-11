using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
            Device dvc = new Device(device.DeviceId, device.DeviceName);

            using (context = new NotificationCentreContext())
            {
                context.Database.EnsureCreated();
                context.Add(device);

                context.SaveChanges();
            }
        }

        //list available
        public List<Device> ListDevices()
        {
           
            using (context = new NotificationCentreContext())
            {

                devices = context.Devices.ToList();
               

            }

            return devices;
        }

        public Device GetDeviceById(int DeviceId)
        {
            Device device;

            using (context = new NotificationCentreContext())
            {
                device = context.Devices.First(u => u.DeviceId.Equals(DeviceId));
            }

            if (device == null)
            {
                return null;
            }
            else
            {
                return device;
            }


        }

        //delete device
        public void DeleteDevice(int id)
        {
            using (context = new NotificationCentreContext())
            {
                context.Remove(context.Devices.Single(a => a.DeviceId.Equals(id)));



                context.SaveChanges();
            }
        }

    

    }
}
