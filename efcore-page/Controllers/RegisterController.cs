using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using efcore_page.Data;

namespace efcore_page.Controllers
{
    public class RegisterController: Controller
    {
        public readonly DataContext _context;

        public RegisterController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Students = new SelectList(await _context.Students.ToListAsync(), "StudentId", "StudentFullName"); // data, dataId, görünen value
            ViewBag.Places = new SelectList(await _context.Places.ToListAsync(), "InternshipPlaceId", "Title");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InternshipRegister model)
        {
            model.RecordDate = DateTime.Now;
            _context.Registers.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("List");
        }

        public async Task<IActionResult> List()
        {
            var registers = await _context.Registers.Include(s => s.Student).Include(p => p.InternshipPlace).ToListAsync(); // bana navigation prop'ları da getir
            return View(registers);
        }
    }
}