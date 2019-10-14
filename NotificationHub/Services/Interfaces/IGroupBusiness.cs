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
        void AddDeviceToGroup(Device device, int id);

        //add existing to the group
        void addExistingDeviceToGroup(int DeviceId, int GroupId);
        //delete device from group
        void DeleteGroup(int id);
        //delete device from group
        void DeleteDeviceFromGroup(int idd, int idg);
        //list devices in a group
        List<Device> ListDevices(int id);
        //update group
        void UpdateGroup(Group group, int id);

    }
 }
