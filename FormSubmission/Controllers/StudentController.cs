using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FormSubmission.Data;
using FormSubmission.Models.Entities;

namespace FormSubmission.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // method for students page shows all students
        public async Task<IActionResult> Index()
        {
            return View(await _context.students.ToListAsync());
        }

        // method for show details of a student
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // method for showing student create form
        // Create with Tag helper

        public IActionResult Create()
        {
            return View();
        }



        // method for showing student create form
        public IActionResult CreateWithHtmlHelper()
        {
            ModelState.Clear();
            return View();
        }


        // method for showing student create form
        // Create with Ajax Beginform

        public IActionResult CreateWithAjaxBeginForm()
        {
            ModelState.Clear();
            return View();
        }

        // method for showing student create form
        // Create with JqueryAjax

        public IActionResult CreateWithJqueryAjax()
        {
            ModelState.Clear();
            return View();
        }

        // method for showing student create form
        // Create with CreateWithJqueryAjaxSerializeFormJson

        public IActionResult CreateWithJqueryAjaxSerializeFormJson()
        {
            ModelState.Clear();
            return View();
        }

        // method for showing student create form
        // Create with CreateWithHtmlFormAction&FormMethod

        public IActionResult CreateWithHtmlFormActionFormMethod()
        {
            ModelState.Clear();
            return View();
        }

        // this action method was created for testing
        // Create with CreateWithHtmlSerializeFromData

        public IActionResult Create2()
        {
            ModelState.Clear();
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {

            var req = Request;
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }



        // this action method was created for testing
         
        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create2(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Student created successfully!" });
            }
            return BadRequest(new { message = "Invalid data provided.", errors = ModelState.Values });
        }









        // method for showing student edit form
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Phone,Major,Cgpa")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }



        // delete view

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }




        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.students.FindAsync(id);
            if (student != null)
            {
                _context.students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.students.Any(e => e.Id == id);
        }
    }
}






















//                             [Actions]