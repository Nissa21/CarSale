 
using System.Web;
using System.Web.Mvc;

namespace CarSale.Controllers
{
    public class HelloCarController : Controller
    {
        //
        // GET: /HelloCar/


        public ActionResult Index()
        {
            return View();
        }


        // 
        // GET: /HelloCar/Welcome/ 

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }
    }
}
