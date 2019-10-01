using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Models;

namespace NotificationHub.Interfaces
{
    public interface IDeviceBusiness
    {
        List<Device> getDevices();
        Device getDeviceById(int id);
        void addDevice(Device device);
        void updateDevice(Device device, int id);
        void deleteDevice(int devId);
        void deleteDeviceFromGroup(int idd, int idg);
    }
}
