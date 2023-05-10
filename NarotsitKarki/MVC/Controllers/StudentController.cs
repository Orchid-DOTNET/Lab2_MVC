
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    // static Student model data
    public class Data
    {
        public static List<Student> model = new List<Student>()
        {
            new Student{Id = 40011, Name = "Narotsit Karki", Section = "A"},

            new Student{Id = 40012, Name = "Subrat Regmi", Section = "A"},

            new Student{Id = 40013, Name = "Ankit Rai", Section = "A"},

            new Student{Id = 40014, Name = "Suman Khatiwada", Section = "B"},

            new Student{Id = 40015, Name = "Madhu Ghimire", Section = "B"},
       };

    }
    
    public class StudentController : Controller
    {
        // /Student
        // return student data list above to student view
        public IActionResult Index()
        {
            var model = Data.model.OrderBy(stu => stu.Id);
            return View(model);
        }

       // /Student/Create
       // a view for creating new student data
        public IActionResult Create()
        {
            return View();
        }

        // /Student/Create_Student
        // view to retreive data via "form" from "create" view above and store it in our student static data list
        [HttpPost]
        public IActionResult Create_Student(Student student)
        {
            Data.model.Add(student);
            // Redirects back to "/Student"
            return RedirectToAction("");
        }

        // /Student/Edit_Student
        // view to retrive student information for a specific ID for editing and updating the current information of the particular student Id
        [HttpPost]
        public IActionResult Edit_Student(Student stu)
        {   // retreiving the (single) student whose id stu.ID from the form match with our current static student list data
            Student student = Data.model.Single(stud => stud.Id == stu.Id);
            student.Name = stu.Name;
            student.Section = stu.Section;
            return RedirectToAction("");
        }
        // /Student/Edit/{int:Id}
        // view for showing information to edit for a particular student ID
        public IActionResult Edit(int Id)
        {
            Student model = Data.model.Single(stu => stu.Id == Id);
            return View(model);
        }
        // /Student/Delete/{int:ID}
        // view to delete the information from the student static list for the id passed as an argument to the function
        public IActionResult Delete(int Id)
        {
            Student delete_student = Data.model.Single(stu => stu.Id == Id);
            Data.model.Remove(delete_student);

            return RedirectToAction("");
        }
        
        // /Student/Details/{int:Id}
        // show detailed information for a particular student Id
        public IActionResult Details(int Id)
        {
            Student model = Data.model.Single(stu => stu.Id == Id);
            return View(model);
        }

    }
}
