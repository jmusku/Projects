using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeePortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Features of the Application";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Reach us at";

            return View();
        }
    }
}