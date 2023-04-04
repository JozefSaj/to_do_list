using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AssignmentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Assignment> tasks = _db.Assignments;
            IEnumerable<History> historys = _db.Historys;
            if (historys.ToList().Count == 0 || historys.Last().HistoryId != DateTime.Now.ToString("m-d-yyyy"))
            {
                return RedirectToAction("TodayHistory");
            }
            return View(tasks);
        }

        public IActionResult TodayHistory()
        {
           return View();
        }

        //GET
        public IActionResult CreateHistory()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        //I forget this and it took me a long time figuring this out
        public IActionResult CreateHistory(History obj)
        {
            if (obj.HistoryId != DateTime.Now.ToString("d-M-yyyy"))
            {
                ModelState.AddModelError("CustomError", "The history date is not corresponding with today's date!");
            }
            if(ModelState.IsValid)
            {
                _db.Historys.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }


    }
}
