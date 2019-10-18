using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationPlugin
{
    class Device
    {
        public int deviceId { get; set; }
        public string deviceName { get; set; }
        public Group group { get; set; }
        public List<NotificationDevice> notificationDevices { get; set; }
   
    public class Group
        {
            public int groupId { get; set; }
            public string groupName { get; set; }
        }
        
        public class NotificationDevice
        {
            public int notificationId { get; set; }
            public int deviceId { get; set; }
        }
    }
}
