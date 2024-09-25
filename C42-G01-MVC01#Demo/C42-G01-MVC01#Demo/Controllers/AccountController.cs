using Microsoft.AspNetCore.Mvc;

namespace C42_G01_MVC01_Demo.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
