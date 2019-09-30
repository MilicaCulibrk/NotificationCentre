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

        static int _i = 0;
        public  int I
        {
            get { return _i; }
            set { _i = value; }
        }

        /*List<int> _notId;
        public List<int> NotId
        {
            get { return _notId; }
            set { NotId = value; }
        } */

        //public Random a = new Random(DateTime.Now.Ticks.GetHashCode());

        public Device()
        {
         
        }

       /* public Device(int deviceId, int groupId, string deviceName)
        {
            this._deviceId = deviceId;
            this._groupId = groupId;
            this._deviceName = deviceName;
        }*/

        public Device(int groupId, string deviceName)
        {

            this._deviceId = ++_i;
            this._groupId = groupId;
            this._deviceName = deviceName;
        }

    }


}
