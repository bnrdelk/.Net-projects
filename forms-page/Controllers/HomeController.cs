using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using forms_page.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace forms_page.Controllers;

public class HomeController : Controller
{

    public IActionResult Index(string searchString, string category) // if url has SearchString it gets that
    {
        var products = Repository.Products; // get all products from repo
        var categories = Repository.Categories; 
        
        if(!String.IsNullOrEmpty(searchString)) // check we get that string or not
        {
            // if we get,
            // filter the all products which they include the desired key string as list, we will send that to View.
            products = products.Where(p => p.Name.ToLower().Contains(searchString)).ToList(); 
            ViewBag.SearchString = searchString;
        }

        if(!String.IsNullOrEmpty(category) && category!="0") 
        {
            products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();
        }

        // add to viewbag for displaying a filtering select list on view
        // ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name", category); // when we add "category" as a 4th parameter, 
                                                                                                       // filtering form stay display that info 

        // with ProductViewModel, we package the info that all we need in app 
        var model = new ProductViewModel
        {
            Products = products,
            Categories = categories,
            SelectedCategory = category // came from url
        };

        // so, all we need is in that model
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
