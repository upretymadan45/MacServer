using Nancy.Hosting.Self;
using System;

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

            _host = new NancyHost(new Uri("http://localhost:56650"),new NancyBootstrapper(), hostConfigs);

            _host.Start();
        }

        public void StopServer()
        {
            _host.Stop();
        }
    }
}
