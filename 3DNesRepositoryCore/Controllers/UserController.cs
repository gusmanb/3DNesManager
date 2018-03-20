using _3DNesRepositoryCore.Classes;
using _3DNesRepositoryCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DNesRepositoryCore.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet(Name = "GetUserName")]
        [ProducesResponseType(209)]
        [ProducesResponseType(404)]
        [Produces("text/plain")]
        public IActionResult GetUserName()
        {
            var name = HttpContext.Request.Headers["LoginName"];
            var password = HttpContext.Request.Headers["Password"];
            var user = DbManager.FindUser(name, password);
            if (user == null)
                return new NotFoundResult();

            return new ContentResult { Content = user.UserName, ContentType = "text/plain", StatusCode = 200 };
        }


        [HttpPut(Name = "CreateUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(409)]
        [Produces("text/plain")]
        public IActionResult CreateUser([FromBody]UserCreateDTO Data)
        {
            if (!DbManager.AddUser(Data.UserName, Data.LoginName, Data.Password, Helpers.IsAdmin(Data.UserName)))
                return new StatusCodeResult(409);

            return new NoContentResult();
        }

        [HttpDelete(Name = "Deleteuser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [Produces("text/plain")]
        public IActionResult DeleteUser()
        {
            
            var name = HttpContext.Request.Headers["LoginName"];
            var password = HttpContext.Request.Headers["Password"];

            if (DbManager.FindUser(name, password) == null)
                return new NotFoundResult();

            if(!DbManager.DeleteUser(name))
                return new StatusCodeResult(500);

            return new NoContentResult();
        }
    }
}
