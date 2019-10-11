using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Services.Interfaces;
using NotificationHub.Models;
using AutoMapper;
using NotificationHub.Controllers;
using NotificationHub.Database;

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
            Group grp = new Group(group.GroupId, group.GroupName);
           // grp.Devices.Add
           // grp.Devices.Add[DeviceContext.Devices];
            //GroupDB groupDB = ConvertGroupToGroupDB(grp);
            //List<DeviceDB> dvd = DeviceController.deviceBusiness.GetDevices();
            //groupDB.Devices.Add(dvd[3]);

            using (context = new NotificationCentreContext())
            {
                context.Database.EnsureCreated();
                context.Add(group);
                //context.Groups.Add(groupDB);
                context.SaveChanges();
            }
        }

        public Group GetGroupById(int GroupId)
        {
            Group group;

            using (context = new NotificationCentreContext())
            {
                group = context.Groups.First(u => u.GroupId.Equals(GroupId));
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

         public void addDeviceToGroup(Device device, int GroupId) {

            Device dvc = new Device(device.DeviceId, device.DeviceName);

            Group grp;

             using (context = new NotificationCentreContext())
             {
              
                grp = context.Groups.First(u => u.GroupId.Equals(GroupId));
                grp.Devices.Add(dvc);
                context.SaveChanges();
             }
      
        }

        public List<Group> GetGroups()
        {
           
            using (context = new NotificationCentreContext())
            {
                groups = context.Groups.ToList();

            }

            return groups;
        }


        public void DeleteDeviceFromGroup(int idd, int idg)
        {

            using (context = new NotificationCentreContext())
            {

                Group grp = context.Groups.First(u => u.GroupId.Equals(idg));
                Device dev = context.Devices.First(u => u.DeviceId.Equals(idd));

                grp.Devices.Remove(dev);

                context.SaveChanges();
            }

        }




    
    }
}
