using Microsoft.AspNetCore.Mvc;
using appeal_page.Models;

namespace appeal_page.Controllers
{
    public class ApplicationController : Controller
    {
        [HttpGet]
         public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
         public IActionResult Apply(FormInfo model)
        {

            if(ModelState.IsValid)
            {
                Repository.CreateUser(model);
                ViewBag.UserCount = Repository.Users.Where(u => u.IsAttending == true ).Count();
                return View("Thanks", model);
            } else 
            {
                return View(model);
            }
        }

        [HttpGet]
         public IActionResult List()
        {
            return View(Repository.Users);
        }

        // application/details/{id}
        [HttpGet]
         public IActionResult Details(int id)
        {
            return View(Repository.GetById(id));
        }
    }
}