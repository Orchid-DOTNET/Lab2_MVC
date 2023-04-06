using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class Data
    {
        public static List<Student> model = new List<Student>()
        {
            new Student{Id = 60011, Name = "Vidit Pandey" , Section = "A"},
        
            new Student{Id = 60012, Name = "Subrat Regmi", Section = "A"},

            new Student{Id = 60013, Name = "Supriya Basnet", Section = "A"},

            new Student{Id = 60014, Name = "Alyssa Karki", Section = "A"},
            
            new Student{Id = 60015, Name = "Pristha Shrestha", Section = "B"},
       };

    }
    public class StudentsController : Controller
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

        public Student Single_data(Student student)
        {
            return Data.model.Single(s => s.Id == student.Id);
        }

        [HttpPost]
        public IActionResult Edit_Student(Student stu)
        {
            Student student = Single_data(stu);
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

// clean Architectute
/*
Buisness Architecure , Entities of the application for Database in Domain Layer
Buisness Logic of the Web Application in Application layer
Infrastructure contains .dll files, cache servers, entity 
*/
