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
        public static INotificationBusiness notificationBusiness = new NotificationBusiness();
        
        //add notification
        [Route("api/notification/add/{id}")]
        [HttpPost]
        public void addNotification([FromBody] Notification notification, [FromHeader] int id)
        {
            notificationBusiness.addNotification(notification, id);
        }
      

    }
}