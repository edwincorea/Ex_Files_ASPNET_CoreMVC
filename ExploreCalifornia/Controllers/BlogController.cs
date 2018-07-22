using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return new ContentResult { Content = "Blog posts" };
        }

        public IActionResult Post(int? id)
        {
            if (id == null)
                return new ContentResult { Content = "null" };

            return new ContentResult { Content = id.ToString() };
        }
    }
}