using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DNesRepositoryCore.Controllers
{
    [Produces("application/json")]
    [Route("api/3DN")]
    public class _3DNController : Controller
    {
        [HttpGet("/{Prg}/{Chr}", Name = "ListFiles")]
        [ProducesResponseType(200)]
        public IActionResult ListFiles(string Prg, string Chr)
        {

        }
    }
}
