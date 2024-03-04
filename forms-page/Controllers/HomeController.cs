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

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product model, IFormFile imageFile)
    {
        var allowedExtensions = new[] {".jpg",".jpeg",".png"};

        var extension = Path.GetExtension(imageFile.FileName); //x.jpg ->> gets .jpg
        var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}"); // unique name for file, because if the filenames are same, old one will be override w new

        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

        if(imageFile != null) { 
            if(!allowedExtensions.Contains(extension)) 
            {
                ModelState.AddModelError("", "Upload a valid file. (Allowed extensions: .jpg, .jpeg, .png)");
            }
        }

        if(ModelState.IsValid)
        {
            using(var stream = new FileStream(path, FileMode.Create)) // stream bilgisi structın içinde, böylece file bellekten kapsam dışına çıkıldığında kaybolacak.
            {
                await imageFile.CopyToAsync(stream);
            }

            model.Image = randomFileName;
            model.ProductId = Repository.Products.Count + 1;
            Repository.CreateProduct(model);
            // return View(); --> denilmesi, formu yenileyerek tekrar önümüze getirir. post'tan (kayıttan) sonra bunu gerçeklştirmeye gerek yok.
            return RedirectToAction("Index"); // Home sayfasına yönlendiriyoruz
        }

        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name"); // SelectList'e tekrar verinin düşmesi gerek. 
        return View(model); // If not valid, just show the create form with old model values.
    }

}
