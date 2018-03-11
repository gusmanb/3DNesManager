using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DNesRepositoryCore.Models
{
    public class NesRomDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Pal PAL { get; set; }
    }

    public enum Pal
    {
        Yes,
        No,
        Unknown
    }
}
