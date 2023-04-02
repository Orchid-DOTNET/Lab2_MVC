using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupriyaShreeBasnyat.Models;

namespace SupriyaShreeBasnyat.Controllers
{
    public class Input
    {
        public static List<Student> sample = new List<Student>()
        {
        new Student{ Id = 1, Name = "Supriya Shree Basnyat", Address= "Basundhara"},
        new Student{ Id = 2, Name = "Nitisha Timalsina", Address= "Chabahil"},
        new Student{ Id = 3, Name = "Subrat Regmi", Address= "Boudha"},
        new Student{ Id = 4, Name = "Sanjita Tiwari", Address= "Bhaktapur"},
        };
    }
    public class Students : Controller
    {

        // GET: Students
        public ActionResult Index()
        {
            var sample = Input.sample;
            return View(sample);
        }

        // GET: Students/Details/5
        public ActionResult Details(int Id)
        {
            Student sample = Input.sample.Single(stu => stu.Id == Id);
            return View(sample);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            Input.sample.Add(student);
            return View();
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int Id)
        {
            Student sample = Input.sample.Single(stu => stu.Id == Id);
            return View(sample);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student stud)
        {
            Student student = Input.sample.Single(student => student.Id == stud.Id);
            student.Name = stud.Name;
            student.Address = stud.Address;
            return View();

        }

        // GET: Students/Delete/5
        public ActionResult Delete(int Id)
        {
            Student sample = Input.sample.Single(stu => stu.Id == Id);
            Input.sample.Remove(sample);
            return View();
        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
