using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DNesRepositoryCore.Models
{
    public class _3DNInfoDTO
    {
        public string Id { get; set; }
        public string TypeVersion { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }
        public bool Official { get; set; }
        public bool Exact { get; set; }
    }

    public class _3DNCreateUpdateDTO
    {
        public string Prg { get; set; }
        public string Chr { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public IFormFile Content { get; set; }
    }
}