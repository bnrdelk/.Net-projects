using Microsoft.AspNetCore.Mvc;

namespace appeal_page.Controllers
{
    public class ApplicationController : Controller
    {
        // localhost/application
        // localhost/application/index
        public IActionResult Index()
        {
            return View();
        }

         public IActionResult Apply()
        {
            return View();
        }

         public IActionResult List()
        {
            return View();
        }
    }
}