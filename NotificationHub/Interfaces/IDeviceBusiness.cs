using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Models;

namespace NotificationHub.Interfaces
{
    public interface IDeviceBusiness
    {
        List<Device> showDevices();
        List<Group> showGroups();
        void addGroup(Group group);
        void addDevice(Device device);
        void deleteGroup(int gId);
        void deleteDevice(int devId);
    }
}
