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
        IGroupBusiness groupBusiness = new GroupBusiness();
        //get groups
        [Route("api/groups/get")]
        [HttpGet]
        public ActionResult<List<Group>> GetGrupe()
        {
            return groupBusiness.getGroups();

        }

        //get group by id
        [Route("api/groups/get/{id}")]
        [HttpGet]
        public ActionResult<Group> GetGrupeById(int id)
        {
            return groupBusiness.getGroupById(id);

        }

        //add group(post)
        [Route("api/groups/addg")]
        [HttpPost]
        public void AddGroup([FromBody] Group group)
        {
            groupBusiness.addGroup(group);
        }

        //update group(put)
        [Route("api/groups/update/{id}")]
        [HttpPut]
        public void UpdateGroup([FromBody] Group group, int id)
        {
            groupBusiness.updateGroup(group, id);
        }




        //delete group
        [Route("api/groups/delete/{id}")]
        [HttpDelete]
        public void DeleteGroup(int id)
        {
            groupBusiness.deleteGroup(id);

        }

    }
}
