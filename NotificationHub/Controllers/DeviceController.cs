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
        
        IDeviceBusiness deviceBusiness = new DeviceBusiness();

        //get devices
        [Route("api/device/get")]
        [HttpGet]
        public ActionResult<List<Device>> GetDevices()
        {

            return deviceBusiness.getDevices(); 
        }

        //get device by id
        [Route("api/device/get/{id}")]
        [HttpGet]
        public ActionResult<Device> GetDeviceById(int id)
        {

            return deviceBusiness.getDeviceById(id);
        }


        //add device(post)
        [Route("api/device/registration")]
        [HttpPost]
        public void PostDevice([FromBody] Device device)
        {
            deviceBusiness.addDevice(device);      
        }

        //update device(put)
        [Route("api/device/update/{id}")]
        [HttpPut]
        public void PutDevice([FromBody] Device device, int id)
        {
            deviceBusiness.updateDevice(device, id);
        }


        //delete device
        [Route("api/device/delete/{id}")]
        [HttpDelete]
        public void DeleteDevice(int id)
        {
            deviceBusiness.deleteDevice(id);           
        }


        //delete device from group
        [Route("api/device/deleteDFG/{idd}/{idg}")]
        [HttpDelete]
        public void DeleteDeviceFropmGroup(int idd, int idg)
        {
            deviceBusiness.deleteDeviceFromGroup(idd, idg);
        }


    }
}