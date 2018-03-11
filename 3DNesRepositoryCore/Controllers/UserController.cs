using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DNesRepositoryCore.Controllers
{
    [Produces("text/plain")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet(Name = "GetUserName")]
        [ProducesResponseType(209)]
        [ProducesResponseType(404)]
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
        public IActionResult CreateUser(string UserName, string LoginName, string Password)
        {

            bool isAdmin = LoginName == "geniwab@gmail.com" || UserName == "geod";

            if (!DbManager.AddUser(UserName, LoginName, Password))
                return new StatusCodeResult(409);

            return new NoContentResult();
        }

        [HttpDelete(Name = "Deleteuser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
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
