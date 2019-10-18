using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationHub.Models
{
    public class NotificationDevice
    {
        public int NotificationId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Notification notification { get; set; }
        public int DeviceId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Device device { get; set; }
    }
}
