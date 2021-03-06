﻿using Nancy;
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
            Get("/", _ => MacFinder.GetAllInfo());
            Get("/test", _ => MacFinder.GetMACAddressWhenOnlineOrOffline());
            Get("/computerName", _ => SystemInfo.GetComputerName());
        }
    }
}
