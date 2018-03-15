using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DNesRepositoryCore.Classes
{
    public class Helpers
    {
        public static bool IsAdmin(string UserName)
        {
            if (UserName == "Gusman" || UserName == "geod")
                return true;

            return false;
        }
    }
}
