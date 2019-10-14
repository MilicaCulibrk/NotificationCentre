using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationHub.Models
{
    public class NotificationDevice
    {
        public int NotificationId { get; set; }
        public Notification notification { get; set; }

        public int DeviceId { get; set; }
        public Device device { get; set; }
    }
}
