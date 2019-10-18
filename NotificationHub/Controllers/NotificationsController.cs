using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationHub.Interfaces;
using NotificationHub.Models;

namespace NotificationHub.Controllers
{  
    [ApiController]
    public class NotificationsController : Controller
    {
        public static INotificationBusiness notificationBusiness = new NotificationBusiness();
      
        //add notification to device
        [Route("api/notification/{id}")]
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult addNotification([FromBody] Notification notification, int id)
        {
            if (DeviceController.deviceBusiness.GetDeviceById(id) == null && notificationBusiness.GetNotificationById(notification.NotificationId) == null)
            {
                return NotFound();
            }
            else
            {
                notificationBusiness.addNotificationToDevice(notification, id);
                return Ok();
            }
        }

        //add notification to group
        [Route("api/notification/addG/{id}")]
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult addNotificationToGroup([FromBody] Notification notification, int id)
        { 
            if (DeviceController.deviceBusiness.GetDeviceById(id) == null)
            {
                return NotFound();
            }
            else
            {
                notificationBusiness.addNotificationToGroup(notification, id);
                return Ok();
            }     
        }

        //list notifications
        [Route("api/notification")]
        [HttpGet]
        public ActionResult<List<Notification>> ListNotifications()
        {
            return notificationBusiness.ListNotifications();
        }

        //get notification by id
        [Route("api/notification/{id}")]
        [HttpGet]
        public ActionResult<Notification> GetNotificationById(int id)
        {
            if (notificationBusiness.GetNotificationById(id) != null)
            {
                return Ok(notificationBusiness.GetNotificationById(id));
            }
            else
            {
                return NotFound();
            }
        }

        //update notification
        [Route("api/notification/{id}")]
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public ActionResult UpdateNotification([FromBody] Notification notification, int id)
        {
            if (notificationBusiness.GetNotificationById(id) == null)
            {
                return NotFound();
            }
            else
            {
                notificationBusiness.UpdateNotification(notification, id);
                return Ok();
            }     
        }

        //delete notification
        [Route("api/notification/{id}")]
        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteNotification(int id)
        {
            if (notificationBusiness.GetNotificationById(id) == null)
            {
                return NotFound();
            }
            else
            {
                notificationBusiness.DeleteNotification(id);
                return Ok();
            }
        }

        //delete notification FROM DEVICE
        [Route("api/notification/{idn}/{idd}")]
        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteNotificationFromDevice(int idn, int idd)
        {
            if (notificationBusiness.GetNotificationById(idn) == null && notificationBusiness.GetNotificationById(idd) == null)
            {
                return NotFound();
            }
            else
            {
                notificationBusiness.DeleteNotificationFromDevice(idn, idd);
                return Ok();
            }
        }

        //delete all notifications FROM DEVICE
        [Route("api/notification/all/{idd}")]
        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteAllNotificationFromDevice(int idd)
        {
            if (notificationBusiness.GetNotificationById(idd) == null)
            {
                return NotFound();
            }
            else
            {
                notificationBusiness.DeleteAllNotificationFromDevice(idd);
                return Ok();
            }
        }
    }
}