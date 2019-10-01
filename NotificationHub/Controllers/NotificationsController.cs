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

        //get notifications
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

        //add existing notification to Device(post)
        [Route("api/notificationsED/registration/{idn}/{idd}")]
        [HttpPost]
        public void PostExistingNotificationToDevice(int idn, int idd)
        {
            notificationBusiness.addExistingNotificationToDevice(idn, idd);
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

        //delete notification(delete)
        [Route("api/notifications/delete/{id}")]
        [HttpDelete]
        public void DeleteNotification(int id)
        {
            notificationBusiness.deleteNotificaton(id);
        }

        //update notification(put)
        [Route("api/notifications/update/{id}")]
        [HttpPut]
        public void UpdateNotification([FromBody] Notification notification, int id)
        {
            notificationBusiness.updateNotificaton(notification, id);
        }


    }
}