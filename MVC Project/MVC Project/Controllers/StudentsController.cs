using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
    public class Data
    {
        public static List<Student> model = new List<Student>()
        {
            new Student { Id = 01, Name = "Undertaker Khatiwada", Faculty = "CSIT" },
            new Student { Id = 02, Name = "Deepak Raj Kharbuja", Faculty = "BIM" }

        };
    }
    public class StudentsController : Controller
    {
        // GET: StudentsController
        public ActionResult Index()
        {
            var model = Data.model;
            return View(model);
        }

        // GET: StudentsController/Details/5
        public ActionResult Details(int Id)
        {
            Student model = Data.model.Single(stu => stu.Id == Id);
            return View(model);
        }
        // GET: StudentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            Data.model.Add(student);
            return RedirectToAction("");
        }

        // GET: StudentsController/Edit/5
        public ActionResult Edit(int Id)
        {
            return View();
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student stu)
        {
            Student student = Data.model.Single(s => s.Id == stu.Id);
            student.Name = stu.Name;
            student.Faculty = stu.Faculty;
            return RedirectToAction("");
        }

        // GET: StudentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Student stu)
        {
            Student delStudent = Data.model.Single(s => s.Id ==stu.Id);
            Data.model.Remove(delStudent);
             return RedirectToAction("");
            
        }
    }
}
