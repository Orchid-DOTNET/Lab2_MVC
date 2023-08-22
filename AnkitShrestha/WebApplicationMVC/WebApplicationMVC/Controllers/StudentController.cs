using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;
using WebApplicationMVC.Models;

namespace MVC.Controllers
{
    public class Data
    {
        public static List<Student> model = new List<Student>()
        {
            new Student{Id = 40011, Name = "ABC", Section = "A"},

            new Student{Id = 40012, Name = "DEF", Section = "A"},

            new Student{Id = 40013, Name = "HIJ", Section = "A"},

       };

    }
    public class StudentController : Controller
    {
        StudentDataAccessLayer studentDataAcessLayer = null;

        public StudentController()
        {
            studentDataAcessLayer = new StudentDataAccessLayer();
        }
        public IActionResult Index()
        {
            var model = studentDataAcessLayer.GetAllStudent();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create_Student(Student student)
        {
            studentDataAcessLayer.addStudent(student);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit_Student(Student stu)
        {
            studentDataAcessLayer.editStudent(stu);;
            return RedirectToAction("");
        }

        public IActionResult Edit(int Id)
        {
            Student student = studentDataAcessLayer.getStudentsById(Id);
            return View(student);
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