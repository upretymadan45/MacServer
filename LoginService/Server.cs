using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService
{
    public class Server
    {
        private NancyHost _host;
        public void StartServer()
        {
            HostConfiguration hostConfigs = new HostConfiguration()
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true }
            };

            _host = new NancyHost(new Uri("http://localhost:1234"),new NancyBootstrapper(), hostConfigs);

            _host.Start();
        }

        public void StopServer()
        {
            _host.Stop();
        }
    }
}
