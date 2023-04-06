using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class Data
    {
        public static List<Student> model = new List<Student>()
        {
            new Student{Id = 40011, Name = "ABC", Section = "A"},

            new Student{Id = 40012, Name = "DEF", Section = "A"},

            new Student{Id = 40013, Name = "HIJ", Section = "A"},

            new Student{Id = 40014, Name = "KLM", Section = "B"},

            new Student{Id = 40015, Name = "NOP", Section = "B"},
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