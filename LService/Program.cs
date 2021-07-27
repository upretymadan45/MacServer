using System.ServiceProcess;

namespace LService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new LoginService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
