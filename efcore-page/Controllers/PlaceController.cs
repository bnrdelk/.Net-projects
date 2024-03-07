using Microsoft.AspNetCore.Mvc;
using efcore_page.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace efcore_page.Controllers
{
    public class PlaceController: Controller    
    {

        // const injection ile datayı aldık
        private readonly DataContext _context;
        public PlaceController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InternshipPlace model)
        {
            _context.Places.Add(model); // eklemek için işaretlemek
            await _context.SaveChangesAsync(); // eklemek 
            return RedirectToAction("List"); 
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(_context.Places);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var found = await _context.Places.FindAsync(id);

            if(found == null)
            {
                return NotFound();
            }
            return View(found);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InternshipPlace model)
        {
            if(id != model.InternshipPlaceId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!_context.Places.Any(p => p.InternshipPlaceId == model.InternshipPlaceId))
                    {
                        return NotFound();
                    } else
                    {
                         throw;
                    }
                }
                return RedirectToAction("List");
            }

            return View(model); // edit yapılamadı - girilen veriler invalid
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
if(id==null)
return NotFound();
           return View(await _context.Places.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            var found = await _context.Places.FindAsync(id);
            _context.Places.Remove(found);
           await _context.SaveChangesAsync();
           return RedirectToAction("List");
        }
    }
} 