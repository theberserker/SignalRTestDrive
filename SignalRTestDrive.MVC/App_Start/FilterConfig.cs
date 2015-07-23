using System.Web;
using System.Web.Mvc;
using SignalRTestDrive.MVC.Infrastructure;

namespace SignalRTestDrive.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new UniqueCookieFilterAttribute());
        }
    }
}
