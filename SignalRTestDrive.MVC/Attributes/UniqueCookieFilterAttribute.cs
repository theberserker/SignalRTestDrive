using System.Web;
using System.Web.Mvc;
using SignalRTestDrive.MVC.Helpers;
using SignalRTestDrive.MVC.Infrastructure;

namespace SignalRTestDrive.MVC.Attributes
{
    /// <summary>
    /// Will take care that persistent cookie is issued if not present yet.
    /// </summary>
    public class UniqueCookieFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest() || filterContext.IsChildAction)
            {
                return;
            }

            HttpCookie cookie = filterContext.HttpContext.Request.Cookies.Get(Consts.UniqieIdCookieName);

            if (cookie == null)
            {
                cookie = PersistentCookieHelper.Generate(Consts.UniqieIdCookieName);
                filterContext.HttpContext.Response.Cookies.Add(cookie);
            }
        }
    }
}
