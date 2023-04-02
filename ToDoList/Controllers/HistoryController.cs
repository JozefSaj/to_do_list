﻿using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HistoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HistoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<History> historys = _db.Historys;
            return View(historys);
        }
    }
}
