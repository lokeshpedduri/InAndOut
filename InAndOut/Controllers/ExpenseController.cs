using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db ;

        public ExpenseController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> expenseList = _db.Expenses;
            return View(expenseList);
        }

        //CREATE
        public IActionResult Create()
        {
            return View();
        }
        //CREATE_POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense exp)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(exp);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(exp);
            }
            
        }

        //Delete get details page
        public IActionResult DeleteGet(int? id)
        {
            if (id == null|| id==0)
            {
                return NotFound();
            }
            Expense expObj = _db.Expenses.Find(id);

            if (expObj == null)
            {
                return NotFound();
            }
            return View(expObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            Expense expObj = _db.Expenses.Find(id);

            if (expObj == null)
            {
                return NotFound();
            }
            _db.Expenses.Remove(expObj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Update get details page
        public IActionResult UpdateGet(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Expense expObj = _db.Expenses.Find(id);

            if (expObj == null)
            {
                return NotFound();
            }
            return View(expObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense expObj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(expObj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else{
                return View(expObj);
            }
        }


    }
}
