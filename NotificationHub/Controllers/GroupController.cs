using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Models;
using NotificationHub.Services;
using NotificationHub.Services.Interfaces;

namespace NotificationHub.Controllers
{
    public class GroupController : Controller
    {
       public static IGroupBusiness groupBusiness = new GroupBusiness();

        //create new group
        [Route("api/group/create")]
        [HttpPost]
        public void CreateGroup([FromBody] Group group)
        {
            groupBusiness.addGroup(group);
        }

        //list groups
        [Route("api/group/list")]
        [HttpGet]
        public ActionResult<List<Group>> GetGroupsFromDb()
        {
            //DeviceDBContext deviceDBContext = new DeviceDBContext();
            return groupBusiness.GetGroups();

        }
  
         //get group by id
        [Route("api/group/getId/{id}")]
        [HttpGet]
        public ActionResult<Group> GetGroupById(int id)
        {
            //DeviceDBContext deviceDBContext = new DeviceDBContext();
            return groupBusiness.GetGroupById(id);

        }

        //add device to group
        [Route("api/group/addD/{id}")]
        [HttpPost]
        public void addDeviceToGroup([FromBody] Device device, [FromHeader] int id)
        {
            //DeviceDBContext deviceDBContext = new DeviceDBContext();
            groupBusiness.addDeviceToGroup(device, id);

        }

        //delete device from group
        [Route("api/group/deleteD/{idd}/{idG}")]
        [HttpDelete]
        public void DeleteDeviceFromGroup(int idd, int idg)
        {

            groupBusiness.DeleteDeviceFromGroup(idd, idg);

        }

    

    } 
}
