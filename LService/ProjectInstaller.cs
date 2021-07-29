using System.ComponentModel;
using System.Configuration.Install;

namespace LService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            //InitializeComponent();
            serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller1
            // 
            serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalService;
            serviceProcessInstaller1.Password = null;
            serviceProcessInstaller1.Username = null;
            // 
            // serviceInstaller1
            // 
            serviceInstaller1.ServiceName = "LoginService";
            serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;

            serviceInstaller1.AfterInstall += new InstallEventHandler(this.serviceInstaller1_AfterInstall);
            // 
            // ProjectInstaller
            // 
            Installers.AddRange(new Installer[] {
            serviceProcessInstaller1,
            serviceInstaller1});
        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
            //"C:\Windows\System32\netsh.exe" http add urlacl url=http://+:56650/ user=Everyone
            System.Diagnostics.Process.Start("netsh.exe", "http add urlacl url=http://+:56650/ user=Everyone");

            using (System.ServiceProcess.ServiceController serviceController = new System.ServiceProcess.ServiceController(serviceInstaller1.ServiceName))
            {
                serviceController.Start();
            }
        }
    }
}
