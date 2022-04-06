
using MVC.Models;
using Microsoft.AspNetCore.Mvc;
using AppDbContext.data;
using Microsoft.EntityFrameworkCore;



namespace MVC.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ApplicationDBContext _db;

        public SubjectController(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var subjects = from t in _db.Subject
                           select t;
            if (!String.IsNullOrEmpty(searchString))
            {
                subjects = subjects.Where(s => s.Subject_name.Contains(searchString));
            }

            return View(await subjects.ToListAsync());

        }

        [HttpGet]
        public IActionResult Edit(int Subject_id)
        {
            var subobj = _db.Subject.Find(Subject_id);
            return View(subobj);

        }

        [HttpPost]
        public IActionResult Edit(Subject updatedvaluesobj)
        {
            _db.Subject.Update(updatedvaluesobj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int Subject_id)
        {

            var subobj = _db.Subject.Find(Subject_id);
            return View(subobj);
        }


        [HttpPost]
        public IActionResult DeletePost(int Subject_id)
        {
            var Subobj = _db.Subject.Find(Subject_id);

            if (ModelState.IsValid)
            {

                _db.Subject.Remove(Subobj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Subobj);
        }

    }
}