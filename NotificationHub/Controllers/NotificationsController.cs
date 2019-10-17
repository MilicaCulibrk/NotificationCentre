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
        //[Authorize(Roles = "Administrator")]
        public void addNotification([FromBody] Notification notification, int id)
        {
            notificationBusiness.addNotificationToDevice(notification, id);
        }

       //add notification to group
        [Route("api/notification/addG/{id}")]
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public void addNotificationToGroup([FromBody] Notification notification, int id)
        {
            notificationBusiness.addNotificationToGroup(notification, id);
        }


        //list notifications
        [Route("api/notification")]
        [HttpGet]
        public ActionResult<List<Notification>> ListNotifications()
        {
            //DeviceDBContext deviceDBContext = new DeviceDBContext();
            return notificationBusiness.ListNotifications();

        }

        //get notification by id
        [Route("api/notification/{id}")]
        [HttpGet]
        public ActionResult<Notification> GetGroupById(int id)
        {
            //DeviceDBContext deviceDBContext = new DeviceDBContext();
            return notificationBusiness.GetNotificationById(id);

        }

        //update notification
        [Route("api/notification/{id}")]
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public void UpdateNotification([FromBody] Notification notification, int id)
        {
            notificationBusiness.UpdateNotification(notification, id);
        }

        //delete notification
        [Route("api/notification/{id}")]
        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public void DeleteDevice(int id)
        {

            notificationBusiness.DeleteNotification(id);

        }

        //delete notification FROM DEVICE
        [Route("api/notification/{idn}/{idd}")]
        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public void DeleteNotificationFromDevice(int idn, int idd)
        {

            notificationBusiness.DeleteNotificationFromDevice(idn, idd);

        }

        //delete all notifications FROM DEVICE
        [Route("api/notification/{idd}")]
        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public void DeleteAllNotificationFromDevice(int idd)
        {

            notificationBusiness.DeleteAllNotificationFromDevice(idd);

        }

    }
}