using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C42_G01_MVC01_Demo.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Privacy()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
    }
}
