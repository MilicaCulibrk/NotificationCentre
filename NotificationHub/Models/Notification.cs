using NotificationHub.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationHub.Models
{
    [Table("TableNotification")]
    public class Notification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int NotificationId { get; set; }

        public Enums.Type Tip{ get; set; }
        public String Message { get; set; }
        public Scope Scope { get; set; }

        public DateTime  date{ get; set; } = DateTime.Now;

        public List<NotificationDevice> NotificationDevices { get; } = new List<NotificationDevice>();


    }
}
