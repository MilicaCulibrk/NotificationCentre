using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Models;

namespace NotificationHub.Services.Interfaces
{
    public interface IGroupBusiness
    {
        List<Group> getGroups();
        Group getGroupById(int id);
        void addGroup(Group group);
        void updateGroup(Group group, int id);
        void deleteGroup(int id);

    }
}
