using C42_G01_MVC01_Demo.Classes;
using Microsoft.AspNetCore.Mvc;
using System;

namespace C42_G01_MVC01_Demo.Controllers
{
    public class MoviesController : Controller
    {
        public void GetMovie() 
        {
        
        }

        public IActionResult Index(int id)
        {
            //ContentResult result = new ContentResult();
            //result.ContentType = "text/html";
            //result.Content = $"Hello, First MVC {id}";
            //return result;
            return Content($"Hello, First Index with {id}", "text/html");
        }

        public IActionResult GetEmployee(int id, Employee employee) 
        {
            return Content($"Hello, I am {employee.name} with id :: {employee.id} \n The Basic Id is :: {id}", "text/html");

        }

        public IActionResult Test()
        {
            //var request = HttpContext.Request;
            //var baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";
            //RedirectResult result = new RedirectResult($"{baseUrl}/Movies/Index/555");
            //return result;

            //return RedirectToAction(nameof(Index));

            return RedirectToRoute(new { controller = "Movies", action = "Index", id = "666" });
        }
    }
}
