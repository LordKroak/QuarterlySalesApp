using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuarterlySalesApp.Models;

namespace QuarterlySalesApp.Controllers
{
    public class SalesController : Controller
    {
        public EmployeeContext Context { get; set; }
        public SalesController(EmployeeContext context)
        {
            Context = context;
        }
        [HttpPost]
        public IActionResult Add(Sales Sales)
        {
            string msg = Validation.CheckSales(Context, Sales); //checks database
            if (!string.IsNullOrEmpty(msg))
            {
                ModelState.AddModelError(nameof(Sales.EmployeeID), msg);
            }
            //do the same thing for checking the manager
            //code will be the same thing except call other validation function
            if (ModelState.IsValid)
            {
                Context.Sales.Add(Sales); //adds it to entity framework
                Context.SaveChanges(); //saves it to the database
                TempData["msg"] = "Sale was added.";
                return RedirectToAction("Index", "Home"); //takes us back to the page
            }
            else //if there is a validation error, pass a list of the employees
            {
                ViewBag.Employees = Context.Employees.ToList();
                return View();
            }
        }
        public IActionResult Add()
        {
            //populate viewbag sales with a list of sales
            ViewBag.Employees = Context.Employees.ToList();
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
