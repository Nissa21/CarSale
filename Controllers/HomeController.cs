using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarSale.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "     Buy Your Dream Car / Van at CarSale Sri Lanka.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "     New and used Cars for sale in Sri Lanka";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "     Contact us";

            return View();
        }
    }
}
