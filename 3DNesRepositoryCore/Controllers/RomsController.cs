using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _3DNesRepositoryCore.Models;

namespace _3DNesRepositoryCore.Controllers
{
    
    [Route("api/[controller]")]
    public class RomsController : Controller
    {
        [HttpGet("{Prg}/{Chr}", Name = "GetRom")]
        [ProducesResponseType(typeof(NesRomDTO), 200)]
        [Produces("application/json")]
        public IActionResult GetById(string Prg, string Chr)
        {
            var rom = DbManager.FindRom(Prg, Chr);

            if (rom == null)
                return new NotFoundResult();

            return new ObjectResult(new NesRomDTO { Id = rom.ToString(), Name = rom.Name, PAL = rom.PAL == null ? Pal.Unknown : rom.PAL.Value ? Pal.Yes : Pal.No });

        }
    }
}