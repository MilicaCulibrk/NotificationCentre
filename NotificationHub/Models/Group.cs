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
    
     

        List<int> _devIds;
        public List<int> DevIds
        {
            get { return _devIds; }
            set { _devIds = value; }
        }




        public Group()
        {

        }

        public Group(int groupId, string groupName)
        {
            this._groupId = groupId;
            this._groupName = groupName;
        }

   

        public Group(int groupId, string groupName, List<int> devIds)
        {
            this._groupId = groupId;
            this._groupName = groupName;
            this._devIds = devIds;
        }
    }
}
