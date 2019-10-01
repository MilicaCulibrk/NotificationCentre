using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Services.Interfaces;
using NotificationHub.Models;

namespace NotificationHub.Services
{
    public class GroupBusiness : IGroupBusiness
    {
        public static List<Group> groups = new List<Group>();
        public List<Group> getGroups()
        {
            if (groups.Count == 0)
            {

                groups.Add(new Group("mobiles", new List<Device>()));
                groups.Add(new Group("computers", new List<Device>()));
                groups.Add(new Group("readers", new List<Device>()));

            }
            return groups;
        }

        public Group getGroupById(int id)
        {
            foreach (Group g in groups)
            {
                if (g.GroupId == id)
                {
                    return g;
                }
            }
            return null;
        }

        public void addGroup(Group group)
        {
            Group g = new Group(group.GroupName, group.Devices);
            groups.Add(g);

        }

        public void updateGroup(Group group, int id)
        {
            foreach (Group g in groups)
            {
                if (g.GroupId == id)
                {
                    g.GroupName = group.GroupName;
                }
            }
        }

        public void deleteGroup(int id)
        {
            foreach (Group g in groups)
            {
                if (g.GroupId == id)
                {
                    groups.Remove(g);
                    break;
                }
            }

            foreach (Device d in DeviceBusiness.registerdDevices)
            {
                if (d.GroupId == id)
                {
                    d.GroupId = 0;
                }
            }


        }
    }
}
