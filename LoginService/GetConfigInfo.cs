using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService
{
    public class GetConfigInfo: NancyModule
    {
        public GetConfigInfo()
        {
            Get("/", _ => MacFinder.GetMACAddress());
        }
    }
}
