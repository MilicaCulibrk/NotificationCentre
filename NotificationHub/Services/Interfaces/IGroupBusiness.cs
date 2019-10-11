using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Models;

namespace NotificationHub.Services.Interfaces
{
    public interface IGroupBusiness
    {
        //create new group
        void addGroup(Group group);
        //list groups
        List<Group> GetGroups();
        //get group by id
        Group GetGroupById(int GroupId);

        //add device to group
        void addDeviceToGroup(Device device, int GroupId);
        //delete device from group
        void DeleteDeviceFromGroup(int idd, int idg);


    }
    }
