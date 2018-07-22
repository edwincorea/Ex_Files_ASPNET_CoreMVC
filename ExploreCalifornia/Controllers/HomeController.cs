using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.Controllers
{
    public class HomeController
    {
        //public string Index()
        public IActionResult Index()
        {
            // return "Hello, ASP.Net Core MVC!";
            return new ContentResult { Content = "Hello, ASP.Net Core MVC!" };
        }
    }
}