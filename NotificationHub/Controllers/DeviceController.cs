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
        public ActionResult RegisterDevice([FromBody] Device device)
        {
            if (deviceBusiness.GetDeviceById(device.DeviceId) != null)
            {
                return Forbid();
            }
            else
            {
                deviceBusiness.RegisterDevice(device);
                return Ok();
            }         
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
        public ActionResult DeleteDevice(int id)
        {
            if (deviceBusiness.GetDeviceById(id) == null)
            {
                return NotFound();

            }
            else
            {
                deviceBusiness.DeleteDevice(id);
                return Ok();
            }
        }

        //get device by id
        [Route("api/device/{id}")]
        [HttpGet]
        public ActionResult<Device> GetDeviceById(int id)
        {
            if (deviceBusiness.GetDeviceById(id) != null)
            {
                
                return Ok(deviceBusiness.GetDeviceById(id));
            }
            else
            {
                return NotFound();
            }
        }

        //update device
        [Route("api/device/{id}")]
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public ActionResult UpdateDevice([FromBody] Device device, int id)
        {
            if (deviceBusiness.GetDeviceById(id) == null)
            {
                return NotFound();

            }
            else
            {
                deviceBusiness.UpdateDevice(device, id);
                return Ok();
            }
        }

        //list notifications in a device
        [Route("api/device/notifications/{id}")]
        [HttpGet]
        public ActionResult<List<Notification>> ListNotificationsFromDevice(int id)
        {
            if (deviceBusiness.GetDeviceById(id) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(deviceBusiness.ListNotificationsFromDevice(id));
            }
        }
    }
}