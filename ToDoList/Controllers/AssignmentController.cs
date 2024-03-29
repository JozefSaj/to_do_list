﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading.Channels;
using System;
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
            string date = DateTime.Now.ToString("d.M.yyyy");
            if (historys.ToList().Count == 0 || string.Compare(historys.Last().HistoryId, date) != 0)
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
            string date = DateTime.Now.ToString("d.M.yyyy");
            if (string.Compare(date, obj.HistoryId) != 0)
            {
                ModelState.AddModelError("CustomError", @"The history date is not corresponding with today's date!
                                                          The format should be 'day.month.year' without leading zeros.
                                                          ");
            }
            if(ModelState.IsValid)
            {
                _db.Historys.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

   

        //GET

        public IActionResult CreateAssignment()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAssignment(Assignment obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Details == null)
                {
                    obj.Details = "";
                }
                _db.Assignments.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj) ;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, bool done)
        {
            var assignment = _db.Assignments.Find(id);
            if (assignment == null)
            {
                return NotFound();
            }
            assignment.Checked = done;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        //GET
        public IActionResult Edit(int? id)
        {
            var assignment = _db.Assignments.Find(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }

        //POST
        [HttpPost] //if it is a pasto action we need to write attribute httppost
        [ValidateAntiForgeryToken] //this aswell
        public IActionResult Edit(Assignment obj)
        {
            if (ModelState.IsValid)
            {
                _db.Assignments.Update(obj);
                _db.SaveChanges(); //goes to the database and save the changes
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {

            var assignment = _db.Assignments.Find(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }

        //POST
        [HttpPost] //if it is a post action we need to write attribute httppost
        [ValidateAntiForgeryToken] //this aswell
        public IActionResult Delete(Assignment obj)
        {
            _db.Assignments.Remove(obj);
            _db.SaveChanges(); //goes to the database and save the changes
            return RedirectToAction("Index");
        }
    }


}

