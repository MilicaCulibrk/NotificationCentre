using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotificationHub.Models;
using NotificationHub.Services;
using NotificationHub.Interfaces;

namespace NotificationHub.Controllers
{

    //[Route("api/[controller]")]
    [ApiController]
    public class DeviceController : Controller
    {
        
        IDeviceBusiness deviceBusiness = new DeviceBusiness();

        //izlistaj uredjaje
        [Route("api/device")]
        [HttpGet]
        public ActionResult<List<Device>> GetDevices()
        {

            return deviceBusiness.showDevices(); 
        }

        //izlistaj grupe
        [Route("api/device/groups")]
        [HttpGet]
        public ActionResult<List<Group>> GetGrupe()
        {
            return deviceBusiness.showGroups();

        }

        //dodaj grupu
        [Route("api/device/addg")]
        [HttpPost]
        public void DodajGrupu([FromBody] Group group)
        {
             deviceBusiness.addGroup(group);
        }
       
        // POST api/device  ---> registruj uredjaj
        [Route("api/device/registration")]
        [HttpPost]
        public void RegistrujUredjaj([FromBody] Device device)
        {
            deviceBusiness.addDevice(device);      
        }

        //obrisi device
        [Route("api/device/delete/{id}")]
        [HttpDelete]
        public void DeleteDevice(int id)
        {
            deviceBusiness.deleteDevice(id);           
        }

        //obrisi grupu
        [Route("api/device/deleteG/{idd}")]
        [HttpDelete]
        public void DeleteGroup(int idd)
        {
            deviceBusiness.deleteGroup(idd);

        }
    }
}