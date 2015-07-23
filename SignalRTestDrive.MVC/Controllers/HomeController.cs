using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignalRTestDrive.MVC.Infrastructure;

namespace SignalRTestDrive.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ConnectedUsers()
        {
            var cuManager = new ConnectedUsersManager();
            return View(cuManager.GetConnectedUserViewModels());
        }

        public ActionResult Chat()
        {
            return View();
        }
    }
}