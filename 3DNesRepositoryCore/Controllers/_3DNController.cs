using _3DNesRepositoryCore.Classes;
using _3DNesRepositoryCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _3DNesRepositoryCore.Controllers
{
    [Route("api/3DN")]
    public class _3DNController : Controller
    {
        [HttpGet("{Prg}/{Chr}", Name = "ListFiles")]
        [ProducesResponseType(200, Type = typeof(_3DNInfoDTO[]))]
        [Produces("application/json")]
        public IActionResult ListFiles(string Prg, string Chr)
        {
            var files = DbManager.ListFiles(Prg);
            List<_3DNInfoDTO> infos = new List<_3DNInfoDTO>();

            foreach (var file in files)
                infos.Add(new _3DNInfoDTO { Id = file.Id.ToString(), CreationDate = file.CreationDate, Exact = file.Rom.CHRSHA == Chr, Name = file.Name, Notes = file.Notes, Official = file.Official, TypeVersion = file.TypeVersion, UserName = file.Creator.UserName });

            return Ok(infos.ToArray());
        }

        [HttpGet("{Id}", Name = "GetFile")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/octet-stream")]
        public IActionResult GetFile(string Id)
        {
            var file = DbManager.GetFile(Id);

            if (file == null)
                return NotFound();

            return File(file.Content, "application/octet-stream");
        }

        [HttpPut(Name = "CreateFile")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(409)]
        [Consumes("multipart/form-data")]
        public IActionResult CreateFile([FromForm]_3DNCreateUpdateDTO Data)
        {
            if (Data.Content == null)
                return BadRequest();

            var name = HttpContext.Request.Headers["LoginName"];
            var user = HttpContext.Request.Headers["UserName"];

            MemoryStream ms = new MemoryStream();
            Data.Content.CopyTo(ms);

            var ok = DbManager.CreateFile(name, Data.Prg, Data.Chr, Data.Name, Data.Notes, Helpers.IsAdmin(user), ms.ToArray());

            ms.Dispose();

            if (ok)
                return NoContent();

            return new StatusCodeResult(409);
        }

        [HttpPost(Name = "UpdateFile")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [Consumes("multipart/form-data")]
        public IActionResult UpdateFile([FromForm]_3DNCreateUpdateDTO Data)
        {
            var name = HttpContext.Request.Headers["LoginName"];
            var user = HttpContext.Request.Headers["UserName"];

            byte[] data = null;

            if (Data.Content != null)
            {
                MemoryStream ms = new MemoryStream();
                Data.Content.CopyTo(ms);
                data = ms.ToArray();
                ms.Dispose();
            }

            var ok = DbManager.UpdateFile(name, Data.Prg, Data.Chr, Data.Name, Data.Notes, Helpers.IsAdmin(user), data);

            if (ok)
                return NoContent();

            return new StatusCodeResult(404);
        }
    }
}
