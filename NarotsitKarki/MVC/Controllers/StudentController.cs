using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;
using System.Text.Json;
using System.Web;
using AccessLayer;
using MVC.Controllers;

namespace MVC.Controllers
{
    public class StudentsController : Controller
    {
        private StudentDataAccessLayer sdal;
        public StudentsController()
        {
            sdal = new StudentDataAccessLayer();
        }   
        public void Create_Message(string msg, string msg_type)
        {
            TempData["Message"] = msg;
            TempData["MType"] = msg_type;
        }
        public IActionResult Index()
        {
            var model = sdal.GetallStudents();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create_Student(Student student)
        {
            if (ModelState.IsValid)
            {
                if (sdal.AddNewStudent(student))
                {
                    Create_Message("Student Data Added Successfully", "alert-success");
                   return RedirectToAction("");
                }
            }
            Create_Message("Student Data Creation Failed !!", "alert-danger");
            return RedirectToAction("Create");  
        }

        public IActionResult Edit(int Id)
        {

            var students = sdal.GetallStudents();
            Student model = students.Single(student => student.Id == Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit_Student(Student stu)
        {
        if (ModelState.IsValid)
        {
            if (sdal.UpdateStudent(stu))

            {
                Create_Message("Student Data Updated Successfully", "alert-success");
                return RedirectToAction("");
            }
            Create_Message("Student Data Update Failed !!", "alert-danger");
        }
            return RedirectToAction("");
        }

        public IActionResult Delete(int Id)
        {
            if (sdal.DeleteStudent(Id)) {
                Create_Message("Student Data Deleted Successfully", "alert-success");
                return RedirectToAction("");
            }
            Create_Message("Student Data Deletion Failed !!", "alert-danger");
            return RedirectToAction("");
        }
        public IActionResult Details(int Id)
        {
            var students = sdal.GetallStudents();
            Student model = students.Single(student => student.Id == Id);
            return View(model);
        }

    }
    
    [ApiController]
    [Route("api/student")]
    public class  StudentAPIController: ControllerBase
    {
    private StudentDataAccessLayer sdal;    
    public StudentAPIController()
    {
        sdal = new StudentDataAccessLayer();
    }
        public IEnumerable<Student> Get()
        {
            var model = sdal.GetallStudents();
            return model;
        }

    }
}

// clean Architectute
/*
Buisness Architecure , Entities of the application for Database in Domain Layer
Buisness Logic of the Web Application in Application layer
Infrastructure contains .dll files, cache servers, entity 
*/
