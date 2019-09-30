using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NotificationHub.Controllers
{
    [Route("api/[controller]")]   //default route
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static List<string> strings = new List<string>()
        {
            "milica", "masa", "ana"

        };

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
         {
             return strings;
         }





        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return strings[id];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            strings.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [Microsoft.AspNetCore.Mvc.FromBody] string value)
        {
            strings[id] = value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            strings.RemoveAt(id);
        }
    }
}
