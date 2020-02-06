using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace LoginService
{
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>                                   
            {
                x.Service<Server>(s =>                                   
                {
                    s.ConstructUsing(name => new Server());                
                    s.WhenStarted(tc => tc.StartServer());
                    s.WhenStopped(tc=>tc.StopServer());
                });
                x.RunAsLocalSystem();                                       

                x.SetDescription("Login Service Provider");                   
                x.SetDisplayName("Login Service");                                  
                x.SetServiceName("Login Service");                                  
            });      
            

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  
            Environment.ExitCode = exitCode;
        }
    }
}
