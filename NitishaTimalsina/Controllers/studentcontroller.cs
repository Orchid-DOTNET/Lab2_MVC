using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using MVC.Models;


namespace MVC.Controllers
{
    public class Data
    {
        public static List<Student> model = new List<Student>()
        {
             new  Student {Id = 101,Name="Nitisha Timalsina",Section="A"},
             new  Student {Id = 102,Name="Supriya Shree Basnyat",Section="A"},
             new  Student {Id = 103,Name="Sudip Raj Shrestha",Section="B"},
             new  Student {Id = 104,Name="Madhu Ghimire",Section="B"},
             new  Student {Id = 105,Name="Raj Koirala",Section="A"}
        };
    }
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var model = Data.model;
            return View(model);
        }

        //get student details
        public IActionResult Details(int Id)
        {
            Student model = Data.model.Single(stu => stu.Id == Id);
            return View(model);
        }


        public IActionResult Create()
        {

            return View();
        }
        public IActionResult Create_Student(Student student)
        {
            Data.model.Add(student);
            return View();
        }

        public IActionResult Edit_Student(Student stu)
        {
            Student student = Data.model.Single(s => s.Id == stu.Id);
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
            Student delete = Data.model.Single(stu => stu.Id == Id);
            Data.model.Remove(delete);
            return View();
        }


    }
}
