using Microsoft.AspNetCore.Mvc;

namespace appeal_page.Controllers
{
    public class HomeController : Controller
    {
        // localhost/
        // localhost/home
        // localhost/home/index
        public IActionResult Index()
        {
            int saat = DateTime.Now.Hour;

            //ViewBag usage
            ViewBag.Greeting = saat < 12 ? "Good Morning" : "Have a Nice Day";
            ViewBag.UserName = "Anonymus";

            //ViewData[] usage
            //ViewData["Greeting"] = saat < 12 ? "Good Morning" : "Have a Nice Day";
            //ViewData["UserName"] = "Anonymus";
            return View();
        }
    }
}