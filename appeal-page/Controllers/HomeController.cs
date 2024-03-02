using Microsoft.AspNetCore.Mvc;
using appeal_page.Models;

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
            //ViewBag.UserName = "Anonymus";

            //ViewData[] usage
            //ViewData["Greeting"] = saat < 12 ? "Good Morning" : "Have a Nice Day";
            //ViewData["UserName"] = "Anonymus";

            int UserCount = Repository.Users.Where(u => u.IsAttending == true).Count();

            var info = new Info()
            {
                Id = 1,
                Location = "Ankara, X Building",
                Date = new DateTime(2024,06,30,20,0,0),
                NumberOfPeople = UserCount
            };

            return View(info);
        }
    }
}