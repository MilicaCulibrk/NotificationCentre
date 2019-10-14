using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationHub.Models;
using NotificationHub.Services;
using NotificationHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace NotificationHub.Controllers
{
    public class GroupController : Controller
    {
       public static IGroupBusiness groupBusiness = new GroupBusiness();

        //add new group
        [Route("api/group")]
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public void CreateGroup([FromBody] Group group)
        {
            groupBusiness.addGroup(group);
        }

        //list groups
        [Route("api/group")]
        [HttpGet]

        public ActionResult<List<Group>> GetGroupsFromDb()
        {
            //DeviceDBContext deviceDBContext = new DeviceDBContext();
            return groupBusiness.GetGroups();

        }
  
         //get group by id
        [Route("api/group/{id}")]
        [HttpGet]
        public ActionResult<Group> GetGroupById(int id)
        {
            //DeviceDBContext deviceDBContext = new DeviceDBContext();
            return groupBusiness.GetGroupById(id);

        }

        //add device to group
        [Route("api/group/{idg}")]
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public void AddDeviceToGroup([FromBody] Device device, int idg)
        {
           
            groupBusiness.AddDeviceToGroup(device, idg);

        }



        //add existing device to group
        [Route("api/group/{idd}/{idg}")]
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public void addExistingDeviceToGroup(int idd, int idg)
         {
             //DeviceDBContext deviceDBContext = new DeviceDBContext();
             groupBusiness.addExistingDeviceToGroup(idd, idg);

         }

        //delete device from group
        [Route("api/group/{idd}/{idG}")]
        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public void DeleteDeviceFromGroup(int idd, int idg)
        {

            groupBusiness.DeleteDeviceFromGroup(idd, idg);

        }


        //delete group
        [Route("api/group/delete/{id}")]
        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public void DeleteGroup(int id)
        {

            groupBusiness.DeleteGroup(id);

        }

        //list devices in a group
        [Route("api/group/{id}")]
        [HttpGet]
        public ActionResult<List<Device>> ListDevices(int id)
        {

            return groupBusiness.ListDevices(id);

        }

        //update group
        [Route("api/group/{id}")]
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public void UpdateGroup([FromBody] Group group, int id)
        {
            groupBusiness.UpdateGroup(group, id);
        }

    } 
}
