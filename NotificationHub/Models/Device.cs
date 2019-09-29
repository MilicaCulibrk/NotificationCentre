using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationHub.Models
{
   
    public class Device
    {
        int _deviceId;
        public int DeviceId
        {
            get { return _deviceId; }
            set { _deviceId = value;  }
        }
        int _groupId;
        public int GroupId {
            get { return _groupId; }
            set { _groupId = value; }
        }
        String _deviceName;
        public String DeviceName {
            get { return _deviceName; }
            set { _deviceName = value; }
        }

         private List<Notification> notifications = new List<Notification>(); //lista primljenih notifikacija

        public Device()
        {
         
        }

        public Device(int deviceId, int groupId, string deviceName)
        {
            this._deviceId = deviceId;
            this._groupId = groupId;
            this._deviceName = deviceName;
        }


        

    }


}
