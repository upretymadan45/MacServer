using Nancy;

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
