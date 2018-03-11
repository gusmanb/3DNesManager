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
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }
        public bool Official { get; set; }
        public bool Exact { get; set; }
    }
    public class _3DNCreateDTO
    {
        public string PRGSHA { get; set; }
        public string CHRSHA { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public IFormFile File { get; set; }
    }
}


//public class _3DNFile
//{
//    public ObjectId Id { get; set; }
//    public ObjectId RomId { get; set; }
//    public string TypeVersion { get; set; }
//    public string Name { get; set; }
//    public DateTime CreationDate { get; set; }
//    public string Notes { get; set; }
//    public bool Official { get; set; }
//    public byte[] Content { get; set; }
//}