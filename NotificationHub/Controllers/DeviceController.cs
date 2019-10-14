using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotificationHub.Models;
using NotificationHub.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace NotificationHub.Controllers
{

   
    [ApiController]
    public class DeviceController : Controller
    {
        
        public static IDeviceBusiness deviceBusiness = new DeviceBusiness();

        //register new device
        [Route("api/device")]
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public void RegisterDevice([FromBody] Device device)
        {
            deviceBusiness.RegisterDevice(device);
        }


        //list available devices
        [Route("api/device")]
        [HttpGet]
        public ActionResult<List<Device>> ListDevices()
        {
     
            return deviceBusiness.ListDevices();
            
        }

        //delete device
        [Route("api/device/{id}")]
        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public void DeleteDevice(int id)
        {
     
            deviceBusiness.DeleteDevice(id);

        }

        //get device by id
        [Route("api/device/{id}")]
        [HttpGet]
        public ActionResult<Device> GetDeviceById(int id)
        {
            return deviceBusiness.GetDeviceById(id);
          
        }

        //update device
        [Route("api/device/{id}")]
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public void UpdateDevice([FromBody] Device device, [FromHeader] int id)
        {
            deviceBusiness.UpdateDevice(device, id);
        }




    }
}