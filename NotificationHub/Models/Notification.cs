using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationHub.Models
{
    public enum Type {
           URGENT, WARNING, INFO
    }

    public enum Scope {
          GLOBAL, GROUP, DEVICE
    }


    public class Notification
    {
        private Type type { get; set; }
        private String message { get; set; }
        private Scope scope { get; set; }
        private DateTime date { get; set; }


    }
}
