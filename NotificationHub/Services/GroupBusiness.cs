using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Services.Interfaces;
using NotificationHub.Models;
using AutoMapper;
using NotificationHub.Controllers;
using NotificationHub.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using static Google.Protobuf.JsonFormatter;
using Newtonsoft.Json;

namespace NotificationHub.Services
{ 
    public class GroupBusiness : IGroupBusiness
    {        
        public NotificationCentreContext context;
        public List<Group> groups;
        public List<Device> dlist = new List<Device>();

        public GroupBusiness()   //ako nema u bazi nista, kreiraj
        {
            using (context = new NotificationCentreContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public void addGroup(Group group)
        {
            using (context = new NotificationCentreContext())
            {   
                context.Groups.Add(group);
                context.SaveChanges();
            }
        }

        public Group GetGroupById(int GroupId)
        {
            Group group;

            using (context = new NotificationCentreContext())
            {
                group = context.Groups.FirstOrDefault(u => u.GroupId.Equals(GroupId));
            }
            if (group == null)
            {
                return null;
            }
            else
            {
                return group;
            }           
        }

        //add device to group
        public void AddDeviceToGroup(Device device, int id)
        {
            Group grp;

            using (context = new NotificationCentreContext())
            {
                if (id == 0)
                {
                    context.Devices.Add(device);
                }
                else
                {
                       grp = context.Groups.FirstOrDefault(u => u.GroupId.Equals(id));
                       grp.Devices.Add(device);
                       context.Devices.Add(device);
                }
                context.SaveChanges();
            }      
        }

        //add existing device to group
        public void addExistingDeviceToGroup(int DeviceId, int GroupId)
        {
            Group grp;

            using (context = new NotificationCentreContext())
            {
                grp = context.Groups.First(u => u.GroupId.Equals(GroupId));
                grp.Devices.Add(context.Devices.First(u => u.DeviceId.Equals(DeviceId)));
                context.SaveChanges();
            }
        }

        public List<Group> GetGroups()
        {           
            using (context = new NotificationCentreContext())
            {
                groups = context.Groups.Include(a => a.Devices).ToList();
            }
            return groups;
        }

        public void DeleteDeviceFromGroup(int idd, int idg)
        {
            using (context = new NotificationCentreContext())
            {
                Group grp = context.Groups.First(u => u.GroupId.Equals(idg));
                Device dev = context.Devices.FirstOrDefault(u => u.DeviceId.Equals(idd));

                dev.Group = null;

                grp.Devices.Remove(dev);

                context.SaveChanges();
            }
        }

        public void DeleteGroup(int id)
        {
            Group grp;

            using (context = new NotificationCentreContext())
            {
                grp = context.Groups.FirstOrDefault(u => u.GroupId.Equals(id));

                var devices = context.Devices
                    .Where(x => x.Group.GroupId == id);

                foreach (Device d in devices)
                {
                    d.Group = null;
                }

                int n = grp.Devices.Count();

                for (int i = 0; i < n; i++) {
                    grp.Devices.ElementAt(0).Group = null;
                    grp.Devices.RemoveAt(0);
                }

                context.Remove(context.Groups.Single(a => a.GroupId.Equals(id)));
                context.SaveChanges();
            }
        }

        public List<Device> ListDevices(int id)
        {
            Group grp;

            using (context = new NotificationCentreContext())
            {
              grp = context.Groups.Include(a => a.Devices).First(u => u.GroupId.Equals(id));

            }
            return grp.Devices;
        }

        //update group
        public void UpdateGroup(Group group, int id)
        {
            Group grp;

            using (context = new NotificationCentreContext())
            {
                grp = context.Groups.First(u => u.GroupId.Equals(id));

                grp.GroupName = group.GroupName;
                context.SaveChanges();
            }
        }
    }
}
