using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationHub.Models
{


    [Table("TableDevice")]
    public class Device
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DeviceId { get; set; }
        public String DeviceName { get; set; }
        public Group Group { get; set; }
        public List<Notification> Notifications { get; } = new List<Notification>();

        public Device(int deviceId, string deviceName)
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
        }

    
    }
        
  }