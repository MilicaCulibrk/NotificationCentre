using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Models;

namespace NotificationHub.Interfaces
{
    public interface IDeviceBusiness
    {
        //register new device
        void RegisterDevice(Device device);
        //list available devices
        List<Device> ListDevices();
        //get device by id
        Device GetDeviceById(int DeviceId);
        //delete device
        void DeleteDevice(int id);
        //delete device
        void UpdateDevice(Device device, int id);
        //list notifications from device
        List<Notification> ListNotificationsFromDevice(int id);
    }
}
