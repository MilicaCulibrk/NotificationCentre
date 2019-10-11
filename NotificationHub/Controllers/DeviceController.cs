using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotificationHub.Models;
using NotificationHub.Interfaces;


namespace NotificationHub.Controllers
{

   
    [ApiController]
    public class DeviceController : Controller
    {
        
        public static IDeviceBusiness deviceBusiness = new DeviceBusiness();

        //register new device
        [Route("api/device/register")]
        [HttpPost]
        public void RegisterDevice([FromBody] Device device)
        {
            deviceBusiness.RegisterDevice(device);
        }


        //list available devices
        [Route("api/device/list")]
        [HttpGet]
        public ActionResult<List<Device>> ListDevices()
        {
     
            return deviceBusiness.ListDevices();
            
        }

        //delete device
        [Route("api/device/delete/{id}")]
        [HttpDelete]
        public void DeleteDevice(int id)
        {
     
            deviceBusiness.DeleteDevice(id);

        }

        //get device by id
        [Route("api/device/getId/{id}")]
        [HttpGet]
        public ActionResult<Device> GetDeviceById(int id)
        {
            //DeviceDBContext deviceDBContext = new DeviceDBContext();
            return deviceBusiness.GetDeviceById(id);

        }


     

    }
}