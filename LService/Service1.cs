using LoginService;
using Nancy.Hosting.Self;
using System;
using System.ServiceProcess;

namespace LService
{
    public partial class LoginService : ServiceBase
    {
        private NancyHost _host;
        public LoginService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            HostConfiguration hostConfigs = new HostConfiguration()
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true }
            };

            _host = new NancyHost(new Uri("http://localhost:56650"), new NancyBootstrapper(), hostConfigs);

            _host.Start();
        }

        protected override void OnStop()
        {
            _host.Stop();
        }
    }
}
