
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class Data
    {
        public static List<Student> model = new List<Student>()
        {
            new Student{Id = 01, Name = "Sudip Raj Shrestha", Section = "B"},

            new Student{Id = 02, Name = "Suvrat Regmi", Section = "A"},

            new Student{Id = 03, Name = "Shital Gurung", Section = "B"},

            new Student{Id = 04, Name = "Upak man Tuladhar", Section = "B"},

            new Student{Id = 05, Name = "Saroj Bhandari", Section = "A"},
       };

    }
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var model = Data.model.OrderBy(stu => stu.Id);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create_Student(Student student)
        {
            Data.model.Add(student);
            return RedirectToAction("");
        }

        [HttpPost]
        public IActionResult Edit_Student(Student stu)
        {
            Student student = Data.model.Single(stud => stud.Id == stu.Id);
            student.Name = stu.Name;
            student.Section = stu.Section;
            return RedirectToAction("");
        }

        public IActionResult Edit(int Id)
        {
            Student model = Data.model.Single(stu => stu.Id == Id);
            return View(model);
        }

        public IActionResult Delete(int Id)
        {
            Student delete_student = Data.model.Single(stu => stu.Id == Id);
            Data.model.Remove(delete_student);

            return RedirectToAction("");
        }
        public IActionResult Details(int Id)
        {
            Student model = Data.model.Single(stu => stu.Id == Id);
            return View(model);
        }

    }
}