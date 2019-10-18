using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationHub.Models
{
    [Table("DeviceGroups")]
    public class Group
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GroupId { get; set; }
        public String GroupName { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public virtual  List<Device> Devices { get; } = new List<Device>();
    }
}
