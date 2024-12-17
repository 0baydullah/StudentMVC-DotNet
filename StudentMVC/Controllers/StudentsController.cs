using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentMVC.Data;
using StudentMVC.Models;
using StudentMVC.Models.Entities;

namespace StudentMVC.Controllers
{
    
    public class StudentsController : Controller
    {
        
        private readonly ApplicationDbContext context;

        


        public StudentsController(ApplicationDbContext context )
        {
            this.context = context;
        }
        
        public IActionResult Index()
        {
            var students = context.Students.ToList();
            return View(students);
        }

        [HttpPost]
        public IActionResult Create(StudentCreateViewModel stu)
        {
            var std = new Student();
            std.Phone = stu.Phone;
            std.Email = stu.Email;
            std.FirstName = stu.FirstName;
            std.LastName = stu.LastName;
            std.Cgpa = stu.Cgpa;
            std.Dob = new DateOnly(2024, 12, 11);
            std.Address = new Address() { City = stu.City, Region = stu.Region , Country = stu.Country, ZipCode = stu.ZipCode };

            context.Students.Add(std);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(StudentDetailsViewModel stu)
        {


          //  var std = stdList.FirstOrDefault(s => s.AId == stu.SId);

            var std = context.Students
    .Include(s => s.Address)
    .FirstOrDefault(s => s.SId == stu.SId);



            std.Phone = stu.Phone;
            std.Email = stu.Email;
            std.FirstName = stu.FirstName;
            std.LastName = stu.LastName;
            std.Cgpa = stu.Cgpa;
            std.Dob = new DateOnly(2024, 12, 11);

            //std.Address = new Address() { City = stu.City, Region = stu.Region, Country = stu.Country, ZipCode = stu.ZipCode };



            std.Address.City = stu.City;
            std.Address.Region = stu.Region;
            std.Address.Country = stu.Country;
            std.Address.ZipCode = stu.ZipCode;


            context.Update(std);
            context.SaveChanges();

            context.Addresses.Remove(std.Address);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {

            var stu = context.Students.ToList().FirstOrDefault(m => m.SId == id);
            var add = context.Addresses.ToList().FirstOrDefault(m => m.AId == stu.AId); ;

            var std = new StudentDetailsViewModel();

            std.SId = stu.SId;
            std.Phone = stu.Phone.ToString();
            std.Email = stu.Email;
            std.FirstName = stu.FirstName;
            std.LastName = stu.LastName;
            std.Cgpa = stu.Cgpa;
            std.Dob = stu.Dob;


            std.AId = add.AId;
            std.Region = add.Region;
            std.Country = add.Country;
            std.City = add.City;
            std.ZipCode = add.ZipCode;
            return View(std);
        }

        public IActionResult Show(int id)
        {
            var stu = context.Students.ToList().FirstOrDefault(m => m.SId == id);
            var add = context.Addresses.ToList().FirstOrDefault(m => m.AId == stu.Address.AId);

            var std = new StudentDetailsViewModel();

            std.SId = stu.SId;
            std.Phone = stu.Phone.ToString();
            std.Email = stu.Email;
            std.FirstName = stu.FirstName;
            std.LastName= stu.LastName;
            std.Cgpa = stu.Cgpa;
            std.Dob = stu.Dob;
            

            
            std.Region = add.Region;
            std.Country = add.Country;
            std.City = add.City;
            std.ZipCode= add.ZipCode;


            return View(std);
        }
        [HttpPost]
        public IActionResult Delete(StudentDetailsViewModel std)
        {
            var stu = context.Students.ToList().FirstOrDefault(m => m.SId == std.SId);
            var add = context.Addresses.ToList().FirstOrDefault(m => m.AId == stu.Address.AId);

            if(stu != null)
            {
                context.Students.Remove(stu);
                context.SaveChanges();
            }
            if (add != null)
            {
                context.Addresses.Remove(add);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var stu = context.Students.ToList().FirstOrDefault(m => m.SId == id);
            var add = context.Addresses.ToList().FirstOrDefault(m => m.AId == stu.Address.AId);

            var std = new StudentDetailsViewModel();

            std.SId = stu.SId;
            std.Phone = stu.Phone.ToString();
            std.Email = stu.Email;
            std.FirstName = stu.FirstName;
            std.LastName = stu.LastName;
            std.Cgpa = stu.Cgpa;
            std.Dob = stu.Dob;



            std.Region = add.Region;
            std.Country = add.Country;
            std.City = add.City;
            std.ZipCode = add.ZipCode;


            return View(std);
        }
    }
}
