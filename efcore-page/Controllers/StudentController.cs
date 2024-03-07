using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using efcore_page.Data;

namespace efcore_page.Controllers
{
    public class StudentController: Controller
    {
        // var context = new DataContext(); yerine injection kullanılmalı.
        private readonly DataContext _context;
        
        public StudentController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student model)// asenkron tercih sebebi, neden: talepleri bloklamamak-daha efficient
        {
            _context.Students.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("List"); 
        
        }

        public async Task<IActionResult> List()
        {
            return View("List", await _context.Students.ToListAsync());
           
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);    // id'ye göre arama yapar

            if(student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Student model)
        {
            if(id!=model.StudentId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(model); // güncellenilecek olarak İŞARETLEMEK
                    await _context.SaveChangesAsync(); // güncellemeyi yap
                }
                catch (DbUpdateConcurrencyException) // kaydın aynı zamanda başkası tarafından silinmesi gibi durumlarda, catch
                {
                    if(_context.Students.Any(stu => stu.StudentId == model.StudentId)) //veritabanında any (1 veya daha fazla) kayıt var mı kontrol
                    {
                        return NotFound();
                    } else
                    {
                        throw;
                    }
                }

                return RedirectToAction("List");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id==null)
                return NotFound();
        
             return View(await _context.Students.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            var found = await _context.Students.FindAsync(id);
            _context.Students.Remove(found);
           await _context.SaveChangesAsync();
           return RedirectToAction("List");
        }
    }


}