using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using forms_page.Models;

namespace forms_page.Controllers;

public class HomeController : Controller
{

    public IActionResult Index(string searchString) // if url has SearchString it gets that
    {
        var products = Repository.Products; // get all products from repo
        
        if(!String.IsNullOrEmpty(searchString)) // check we get that string or not
        {
            // if we get,
            // filter the all products which they include the desired key string as list, we will send that to View.
            products = products.Where(p => p.Name.ToLower().Contains(searchString)).ToList(); 
            ViewBag.SearchString = searchString;
        }

        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
