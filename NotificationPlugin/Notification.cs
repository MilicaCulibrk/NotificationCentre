using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationPlugin
{
    class Notification
    {
            public int notificationId { get; set; }           
            public Boolean Received { get; set; }
            public int tip { get; set; }
            public string message { get; set; }
            public int scope { get; set; }
            public DateTime date { get; set; }
            public List<object> notificationDevices { get; set; }
    }
}
