using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        [Authorize(Roles = "Administrator")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return strings;
        }

        [HttpPost("token")]
        public ActionResult GetToken()
        {
            //security key
            string securityKey = "supper_long_security_key_for_token_validation$smesk.in";
            //symmetric security key
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            //signing credentials
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            //add claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
         

            //create token
            var token = new JwtSecurityToken(
                    issuer: "smesk.in",
                    audience: "readers",
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredentials
                   , claims: claims
                );

            //return token
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
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