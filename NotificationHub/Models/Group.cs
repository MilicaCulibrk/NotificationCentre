using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationHub.Models
{
    public class Group
    {
        int _groupId;
        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }
        String _groupName;
        public String GroupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }
       // private List<Notification> notifications = new List<Notification>(); //lista primljenih notifikacija

        List<Device> _devices;
        public List<Device> Devices {
            get { return _devices;  }
            set { _devices = value;  }
        }




        public Group()
        {

        }

        public Group(int groupId, string groupName)
        {
            this._groupId = groupId;
            this._groupName = groupName;
        }

        public Group(int groupId, string groupName, List<Device> devices)
        {
            this._groupId = groupId;
            this._groupName = groupName;
            this._devices = devices;
        }
    }
}
