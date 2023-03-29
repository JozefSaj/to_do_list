using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
