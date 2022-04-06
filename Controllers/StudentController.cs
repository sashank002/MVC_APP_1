
using MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppDbContext.data;

namespace MVC.Controllers
{
    public class StudentController : Controller
    {

        public readonly ApplicationDBContext _db;

        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }

        private void PopulateSubjectsDropDownList(object selectedSubject = null)
        {
            var subjectsQuery = from s in _db.Subject
                                orderby s.Subject_name
                                select new { SubjectId = s.Subject_id, s.Subject_name };

            ViewBag.SubjectId = new SelectList(subjectsQuery.AsNoTracking(), "SubjectId", "SubjectName", selectedSubject);

        }

        public IActionResult Index()
        {

            IEnumerable<Student> objList = _db.Student;
            return View(objList);
        }

        //Get Create
        public IActionResult Create()
        {
            PopulateSubjectsDropDownList();
            return View();
        }


        [HttpPost]
        public IActionResult Create([Bind("Student_name,Student_class,Subject_id")] Student studobj)
        {
            if (ModelState.IsValid)
            {
                _db.Student.Add(studobj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studobj);
        }

        //Get Create
        public IActionResult Edit(int id)
        {

            var studobj = _db.Student.Find(id);
            return View(studobj);
        }


        [HttpPost]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Student.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get Delete
        public IActionResult Delete(int id)
        {

            var studobj = _db.Student.Find(id);
            return View(studobj);
        }


        [HttpPost]
        public IActionResult DeletePost(int studentid)
        {
            var studobj = _db.Student.Find(studentid);

            if (ModelState.IsValid)
            {

                _db.Student.Remove(studobj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studobj);
        }
    }
}