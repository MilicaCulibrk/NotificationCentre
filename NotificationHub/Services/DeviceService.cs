using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Models;

namespace NotificationHub.Services
{
    public class DeviceService
    {
        public  List<Device> registerdDevices = new List<Device>();  //u ovu listu cu smestati registrovane uredjaje
        public  List<Group> groups = new List<Group>();

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
    }
}
