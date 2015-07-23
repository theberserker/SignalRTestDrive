using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SignalRTestDrive.MVC.Helpers;

namespace SignalRTestDrive.MVC.Infrastructure
{
    /// <summary>
    /// Will take care that persistent cookie is issued if not present yet.
    /// </summary>
    public class UniqueCookieFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Cookie name used for uniqueId
        /// </summary>
        public const string CookieName = "uid";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest() || filterContext.IsChildAction)
            {
                return;
            }

            HttpCookie cookie = filterContext.HttpContext.Request.Cookies.Get(CookieName);

            if (cookie == null)
            {
                cookie = PersistentCookieHelper.Generate(CookieName);
                filterContext.HttpContext.Response.Cookies.Add(cookie);
            }

            TrackLicense(cookie);
        }

        private void TrackLicense(HttpCookie cookie)
        {
            var id = PersistentCookieHelper.Decrypt(cookie);
            
        }
    }
}
