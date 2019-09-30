using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Interfaces;
using NotificationHub.Models;

namespace NotificationHub
{
    public class DeviceBusiness : IDeviceBusiness
    {
        public  static List<Device> registerdDevices = new List<Device>();  //u ovu listu cu smestati registrovane uredjaje
        public  static List<Group> groups = new List<Group>();
     

        public List<Device> showDevices()
        {
            if (registerdDevices.Count == 0)
            {

                registerdDevices.Add(new Device(1, "phone"));
                registerdDevices.Add(new Device(1, "mac"));
                registerdDevices.Add(new Device(2, "kindle"));
            }

            return registerdDevices;
        }

        public List<Group> showGroups()
        {
            if (groups.Count == 0)
            {

                groups.Add(new Group(1, "mobiles", new List<int>()));
                groups.Add(new Group(2, "computers", new List<int>()));
                groups.Add(new Group(8, "readers", new List<int>()));

            }
            return groups;
        }

        public void addGroup(Group group)
        {
            int flg1 = 0;

            foreach (Group g in groups)
            {
                if (g.GroupId == group.GroupId)
                {
                    flg1 = 1;
                    break;

                }

                if (flg1 == 0)  //nema nijedne grupe sa tim id-em
                {
                    groups.Add(group);

                }
            }
        }

        public void addDevice(Device device)
        {
            Device dev = new Device(device.GroupId, device.DeviceName);
            foreach (Group g in groups)
            {
                if (device.GroupId == g.GroupId)  //nema nijedan device sa tim id-em i postoji ta grupa
                {
                    registerdDevices.Add(dev);
                    g.DevIds.Add(dev.DeviceId);
                }
            }
        }

        public void deleteGroup(int idd)
        {
            List<Device> listD = new List<Device>();
            List<Group> listG = new List<Group>();

            foreach (Device d in registerdDevices)
            {
                if (d.GroupId == idd)
                {
                    listD.Add(d);

                }
            }

            foreach (Device d in listD)
            {
                registerdDevices.Remove(d);
            }

            foreach (Group g in groups)
            {
                if (g.GroupId == idd)
                {

                    listG.Add(g);

                }
            }

            foreach (Group g in listG)
            {
                groups.Remove(g);
            }

        }

    

    public void deleteDevice(int devId)
        {
            foreach (Device d in registerdDevices)
            {
                if (d.DeviceId == devId)
                {
                    registerdDevices.Remove(d);
                    foreach (Group g in groups)
                    {
                        if (g.GroupId == d.GroupId)
                        {

                            g.DevIds.Remove(devId);
                        }
                    }
                    break;
                }
            }
        }
    }
}
