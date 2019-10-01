using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Interfaces;
using NotificationHub.Models;
using NotificationHub.Services;

namespace NotificationHub
{
    public class DeviceBusiness : IDeviceBusiness
    {
        public  static List<Device> registerdDevices = new List<Device>();  //u ovu listu cu smestati registrovane uredjaje
                                                                            // public  static List<Group> groups = new List<Group>();
        public List<Device> getDevices()
        {
            if (registerdDevices.Count == 0)
            {

                registerdDevices.Add(new Device(1, "phone", new List<Notification>()));
                registerdDevices.Add(new Device(1, "mac", new List<Notification>()));
                registerdDevices.Add(new Device(2, "kindle", new List<Notification>()));
            }

            return registerdDevices;
        }

        public Device getDeviceById(int id)
        {
            foreach (Device d in registerdDevices)
            {
                if (d.DeviceId == id)
                {
                    return d;
                }
            }

            return null;
            
        }




        public void addDevice(Device device)
        {
            int flg = 0;
            Device dev = new Device(device.GroupId, device.DeviceName);
            registerdDevices.Add(dev);

            foreach (Group g in GroupBusiness.groups)
            {
                if (device.GroupId == g.GroupId)  // postoji ta grupa
                {
                    g.Devices.Add(dev);
                    flg = 1;
                    break;
                }
            }

            if (flg == 0)
            {
                List<Device> temp = new List<Device>();
                temp.Add(dev);
                GroupBusiness.groups.Add(new Group(device.GroupId, device.DeviceName, temp));
            }
        }

        public void updateDevice(Device device, int id)
        {
          
            foreach (Device d in registerdDevices)
            {
                if (d.DeviceId == id)
                {
                    foreach (Group g in GroupBusiness.groups)
                    {
                        foreach (Device dev in g.Devices)
                        {
                            if (d.Equals(dev))
                            {
                                g.Devices.Remove(d);
                                break;
                            }
                        }
                    }

                    d.DeviceName = device.DeviceName;
                    d.GroupId = device.GroupId;

                    foreach (Group g in GroupBusiness.groups)
                    {
                        if (g.GroupId == d.GroupId)
                        {
                            g.Devices.Add(d);
                            break;
                        }
                        else
                        {
                           
                            List<Device> temp = new List<Device>();
                            temp.Add(d);
                            GroupBusiness.groups.Add(new Group(d.GroupId, d.DeviceName, temp));
                            break;
                        }
                    }
                  
                    break;
                }
             

            }
          
          
        }    
    

    public void deleteDevice(int devId)
        {
            foreach (Device d in registerdDevices)
            {
                if (d.DeviceId == devId)
                {
                    registerdDevices.Remove(d);
                    foreach (Group g in GroupBusiness.groups)
                    {
                        if (g.GroupId == d.GroupId)
                        {

                            g.Devices.Remove(d);
                        }
                    }
                    break;
                }
            }
        }

        public void deleteDeviceFromGroup(int idd, int idg)
        {
            foreach (Group g in GroupBusiness.groups)
            {
                if (g.GroupId == idg)
                {
                    foreach (Device d in g.Devices)
                    {
                        if (d.DeviceId == idd)
                        {
                            g.Devices.Remove(d);
                            break;
                        }
                    }
                }
            }
        }
    }
}
