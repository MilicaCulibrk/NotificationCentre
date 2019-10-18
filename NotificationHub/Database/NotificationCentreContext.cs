using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NotificationHub.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationHub.Database
{
    public class NotificationCentreContext : DbContext
    {
        public DbSet<Models.Group> Groups { get; set; }
        public DbSet<Models.Device> Devices { get; set; }
        public DbSet<Models.Notification> Notifications { get; set; }
        public DbSet<NotificationDevice> NotificationDevices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = "NotificationCentreConfig.json";

            using (StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                var values = JsonConvert.DeserializeObject<Dictionary<String, String>>(json);
                var server = values["server"];
                var database = values["database"];
                var user = values["user"];
                var password = values["password"];

                string connStr = "server=" + server + ";database=" + database + ";user=" + user + ";password=" + password;

                optionsBuilder.UseMySQL(connStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NotificationDevice>().HasKey(nd => new { nd.NotificationId, nd.DeviceId });

            modelBuilder.Entity<Notification>().Property(e => e.Tip).HasConversion(
            t => t.ToString(),
            t => (Enums.Type)Enum.Parse(typeof(Enums.Type), t));

            modelBuilder.Entity<Notification>().Property(e => e.Scope).HasConversion(
            t => t.ToString(),
            t => (Enums.Scope)Enum.Parse(typeof(Enums.Scope), t));

            modelBuilder.Entity<Notification>().Property(e => e.Received).HasConversion(
            t => t.ToString(),
            t => Boolean.Parse(t));

            modelBuilder.Entity<Models.Group>()
            .HasMany(c => c.Devices);

            modelBuilder.Entity<Models.Device>()
               .HasOne(c => c.Group);
        }
    }
}
