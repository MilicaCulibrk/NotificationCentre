using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotificationHub.Models;

namespace NotificationHub.Controllers
{

    //[Route("api/[controller]")]
    [ApiController]
    public class DeviceController : Controller
    {
        public static List<Device> registerdDevices = new List<Device>();  //u ovu listu cu smestati registrovane uredjaje
        public static List<Group> groups = new List<Group>();

        //izlistaj uredjaje
        [Route("api/device")]
        [HttpGet]
        public ActionResult<List<Device>> Get()
        {
            if (registerdDevices.Count == 0)
            {

                registerdDevices.Add(new Device(1, 1, "phone"));
                registerdDevices.Add(new Device(2, 1, "mac"));
                registerdDevices.Add(new Device(8, 2, "kindle"));
            }
            return registerdDevices;
        }


        //izlistaj grupe
        [Route("api/device/groups")]
        [HttpGet("{id}")]
        public ActionResult<List<Group>> Get(int id)
        {
            if (groups.Count == 0)
            {

                groups.Add(new Group(1, "mobiles", new List<Device>()));
                groups.Add(new Group(2, "computers", new List<Device>()));
                groups.Add(new Group(8, "readers", new List<Device>()));
            }
            return groups;
        }

        //dodaj grupu
        [Route("api/device/addg")]
        [HttpPost]
        public void Post([FromBody] Group group)
        {
            int flg1 = 0;

            foreach (Group g in groups)
            {
                if (g.GroupId == group.GroupId)
                {
                    flg1 = 1;
                    break;

                }

                if (flg1 == 0)  //nema nijedne grupe sa tim id-em
                {
                    groups.Add(group);
                   
                }
            }
        }
        // POST api/device  ---> registruj uredjaj

        [Route("api/device/registration")]
        [HttpPost]
        public void Post([FromBody] Device device)
        {
            int flg1 = 0;

            foreach (Device d in registerdDevices)
            {
                if (d.DeviceId == device.DeviceId)
                {
                    flg1 = 1;
                    break;
                   
                }         
            }

            foreach (Group g in groups)
            {
                if ((device.GroupId == g.GroupId) && flg1 == 0)  //nema nijedan device sa tim id-em i postoji ta grupa
                {
                    registerdDevices.Add(device);
                    g.Devices.Add(device);
                }
            } 
        }

        //obrisi device
        [Route("api/device/delete/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            foreach (Device d in registerdDevices)
            {
                if (d.DeviceId == id)
                {
                    registerdDevices.Remove(d);
                    foreach (Group g in groups)
                    {
                        if (g.GroupId == d.GroupId)
                        {
                            g.Devices.Remove(d);
                        }
                    }
                    break;
                }
            }
                    
        }

        //obrisi grupu
        [Route("api/device/deleteG/{idd}")]
        [HttpDelete]
        public void DeleteGroup(int idd)
        {
            List<Device> listD = new List<Device>();
            List<Group> listG = new List<Group>();

            foreach (Device d in registerdDevices)
            {
                if (d.GroupId == idd)
                {
                    listD.Add(d);

                }
            }

            foreach (Device d in listD)
            {
                registerdDevices.Remove(d);
            }

            foreach (Group g in groups)
            {
                if (g.GroupId == idd)
                {

                    listG.Add(g);

                }
            }

            foreach (Group g in listG)
            {
                groups.Remove(g);
            }

        }



    }
}