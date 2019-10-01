using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationHub.Interfaces;
using NotificationHub.Models;

namespace NotificationHub.Controllers
{
   
    [ApiController]
    public class NotificationsController : Controller
    {
        INotificationBusiness notificationBusiness = new NotificationBusiness();

        //get devices
        [Route("api/notifications/get")]
        [HttpGet]
        public ActionResult<List<Notification>> GetNotification()
        {

            return notificationBusiness.getNotifications();
        }

        //get devices
        [Route("api/notifications/get/{id}")]
        [HttpGet]
        public ActionResult<Notification> GetNotificationById(int id)
        {

            return notificationBusiness.getNotificationById(id);
        }

        //add notification(post)
        [Route("api/notifications/registration")]
        [HttpPost]
        public void PostNotification([FromBody] Notification notification)
        {
            notificationBusiness.addNotification(notification);
        }


        //add notification(post)
        [Route("api/notifications/registrationD/{id}")]
        [HttpPost]
        public void PostNotificationToDevice([FromBody] Notification notification, int id)
        {
            notificationBusiness.addNotificationToDevice(notification, id);
        }

        //add notification(post)
        [Route("api/notifications/registrationG/{id}")]
        [HttpPost]
        public void PostNotificationToGroup([FromBody] Notification notification, int id)
        {
            notificationBusiness.addNotificationToGroup(notification, id);
        }


        //add notification(post)
        [Route("api/notifications/registrationA")]
        [HttpPost]
        public void PostNotificationToAll([FromBody] Notification notification, int id)
        {
            notificationBusiness.addNotificationToAll(notification);
        }
    }
}