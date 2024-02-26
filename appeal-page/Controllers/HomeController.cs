using Microsoft.AspNetCore.Mvc;

namespace appeal_page.Controllers
{
    public class HomeController : Controller
    {
        // localhost/
        // localhost/home
        // localhost/home/index
        public string Index()
        {
            return "home/index";
        }
    }
}