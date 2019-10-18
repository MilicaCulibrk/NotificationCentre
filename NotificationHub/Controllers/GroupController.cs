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
        public ActionResult CreateGroup([FromBody] Group group)
        {
            if (groupBusiness.GetGroupById(group.GroupId) != null)
            {
                return Forbid();
            }
            else
            {
                groupBusiness.addGroup(group);
                return Ok();
            }
        }
   
        //list groups
        [Route("api/group")]
        [HttpGet]
        public ActionResult<List<Group>> GetGroupsFromDb()
        {
            return groupBusiness.GetGroups();
        }

        //get group by id
        [Route("api/group/{id}")]
        [HttpGet]
        public ActionResult<Group> GetGroupById(int id)
        {
            if (groupBusiness.GetGroupById(id) != null)
            {
                return Ok(groupBusiness.GetGroupById(id));
            }
            else
            {
                return NotFound();
            }
        }

        //add device to group
        [Route("api/group/{idg}")]
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddDeviceToGroup([FromBody] Device device, int idg)
        {
            if (groupBusiness.GetGroupById(idg) != null && DeviceController.deviceBusiness.GetDeviceById(device.DeviceId) == null) 
            {
                groupBusiness.AddDeviceToGroup(device, idg);
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        //add existing device to group
        [Route("api/group/{idd}/{idg}")]
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult addExistingDeviceToGroup(int idd, int idg)
         {
            if (groupBusiness.GetGroupById(idg) != null && groupBusiness.GetGroupById(idd) != null)
            {
                groupBusiness.addExistingDeviceToGroup(idd, idg);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        //delete device from group
        [Route("api/group/{idd}/{idG}")]
        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteDeviceFromGroup(int idd, int idg)
        {
            if (groupBusiness.GetGroupById(idg) != null && groupBusiness.GetGroupById(idd) != null)
            {
                groupBusiness.DeleteDeviceFromGroup(idd, idg);
                return Ok();
            }
            else
            {
                return NotFound();
            }    
        }

        //delete group
        [Route("api/group/{id}")]
        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteGroup(int id)
        {
            if (groupBusiness.GetGroupById(id) == null)
            {
                return NotFound();
            }
            else
            {
                groupBusiness.DeleteGroup(id);
                return Ok();
            }
        }

        //list devices in a group
        [Route("api/group/devices/{id}")]
        [HttpGet]
        public ActionResult<List<Device>> ListDevices(int id)
        {
            if (groupBusiness.GetGroupById(id) != null)
            {
                return Ok(groupBusiness.ListDevices(id));
            }
            else
            {
                return NotFound();
            }
        }

        //update group
        [Route("api/group/{id}")]
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public ActionResult UpdateGroup([FromBody] Group group, int id)
        {
            if (groupBusiness.GetGroupById(id) == null)
            {
                return NotFound();          
            }
            else
            {
                groupBusiness.UpdateGroup(group, id);
                return Ok();
            }
        }
    } 
}
