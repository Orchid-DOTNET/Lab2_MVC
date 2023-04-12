using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;


namespace MVC.Controllers
{
    public class StudentInfo
    {
        public static List<Student> studentlist = new List<Student>()
        {
            new Student{ Id = 1, Name = "Nischal Wagle", Address= "Kapan"},
        };
    }
    public class StudentsController : Controller
    {

        public IActionResult Index()
        {
            return View(StudentInfo.studentlist);
        }

        public IActionResult StudentDetail(int Id)
        {
            Student student = StudentInfo.studentlist.Single(stu => stu.Id == Id);
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            StudentInfo.studentlist.Add(student);
            return RedirectToAction("");
        }

        public IActionResult Edit(int Id)
        {
            Student student = StudentInfo.studentlist.Single(stu => stu.Id == Id);
            return View(student);
        }


        [HttpPost]
        public IActionResult Edit(Student stud)
        {
            Student student = StudentInfo.studentlist.Single(student => student.Id == stud.Id);
            student.Name = stud.Name;
            student.Address = stud.Address;
            return View();

        }

         public IActionResult Delete(int Id)
        {
            Student del_student = StudentInfo.studentlist.Single(stu => stu.Id == Id);
            StudentInfo.studentlist.Remove(del_student);

            return RedirectToAction("");
        }

    }
}