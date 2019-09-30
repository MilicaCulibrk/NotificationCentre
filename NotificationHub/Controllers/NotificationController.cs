using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationHub.Models;


namespace NotificationHub.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class NotificationController : Controller
    {
        public static List<Notification> registerdNotifications = new List<Notification>();

        //izlistaj notifikacije
        [Route("api/notification")]
        [HttpGet]
        public ActionResult<List<Notification>> GetNotification()
        {
            if (registerdNotifications.Count == 0)
            {

                /*registerdNotifications.Add(new Notification(1, "phone"));
                registerdNotifications.Add(new Notification(1, "mac"));
                registerdNotifications.Add(new Notification(2, "kindle")); */
            }
            return registerdNotifications;
        }

    }
}