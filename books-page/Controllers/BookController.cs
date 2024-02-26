using Microsoft.AspNetCore.Mvc; // Add using directive for Controller and IActionResult
using books_page.Models; // Add using directive for your Book and BookViewModel classes

namespace books_page.Controllers;

public class BookController : Controller {

    // url sonunda olan {id} key alınıyor
    public IActionResult Details(int? id)
    {
        if(id==null) {
            return Redirect("/book/list");
        } 
        var book = Repository.GetById(id);
        return View(book);
    }

     public IActionResult List()
     {
        return View("BookList",Repository.Books);
    }
}