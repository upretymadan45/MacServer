using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService
{
    public class SystemInfo
    {
        public static string GetComputerName()
        {
            return System.Environment.MachineName;
        }
    }
}
