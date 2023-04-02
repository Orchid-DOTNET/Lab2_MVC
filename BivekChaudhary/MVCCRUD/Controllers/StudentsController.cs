using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCCRUD.Models;

namespace MVCCRUD.Controllers
{
    public class StudentsController : Controller
    {   
        private static List<Student> _list = new List<Student>
        {
            new Student
            {
                Id = 1,
                Name = "Bivek",
                Section = "B",
                Description = "CSIT Student"
            },
            new Student
            {
                Id = 2,
                Name = "Upak",
                Section = "B",
                Description = "College Student"
            },
            new Student
            {
                Id = 3,
                Name = "Binaya",
                Section = "B",
                Description = "BscCSIT Student"
            },
            new Student
            {
                Id = 4,
                Name = "Bilish",
                Section = "B",
                Description = "Orcid College Student"
            }

        };

        // GET: StudentsController
        public ActionResult StudentList()
        {
            var student = _list;
            return View(student);
        }

        // GET: StudentsController/Create

        public ActionResult Create()
        {
            return View();
        }


        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStudent(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _list.Add(student);
                    return RedirectToAction("StudentList");
                }
                return View();
            }
            catch
            {
                return RedirectToAction("StudentList");
            }
        }

        public ActionResult Edit(int id)
        {
            var student = _list.FirstOrDefault(s => s.Id == id);
            return View(student);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingStudent = _list.FirstOrDefault(s => s.Id == student.Id);
                    existingStudent.Name = student.Name;
                    existingStudent.Section = student.Section;
                    existingStudent.Description = student.Description;
                    return RedirectToAction("StudentList");
                }
                return View(student);
            }
            catch
            {
                return RedirectToAction("StudentList");
            }
        }
        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            Student student = _list.FirstOrDefault(student => student.Id == Id);
            _list.Remove(student);

            return RedirectToAction("StudentList");
        }
    }
}
