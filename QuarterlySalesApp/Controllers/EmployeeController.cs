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
    public class EmployeeController : Controller
    {
        private Repository<Employee> Data { get; set; }
        public EmployeeController(EmployeeContext context) => Data = new Repository<Employee>(context);
        
        public ViewResult List(SalesGridDTO vals)
        {
            // get GridBuilder object, load route segment values, store in session
            string defaultSort = nameof(Employee.FirstName);
            var builder = new SalesGridBuilder(HttpContext.Session, vals, defaultSort);

            //create options for querying employees
            var options = new QueryOptions<Employee>
            {
                Includes = "Employee.EmployeeID",
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection
            };
            //OrderBy depends on value of SortField route
            if (builder.CurrentRoute.SortField.EqualsNoCase(defaultSort))
            {
                options.OrderBy = a => a.FirstName;
            }
            else
            {
                options.OrderBy = a => a.LastName;
            }

            var vm = new ViewModel
            {
                Employees = Data.List(options),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(Data.Count)
            };
            return View(vm);
            
        }
        
        [HttpPost]
        public IActionResult Add(Employee Employee)
        {
            string msg = Validation.CheckEmployee(Data, Employee); //checks database
            if (!string.IsNullOrEmpty(msg))
            {
                ModelState.AddModelError(nameof(Employee.DateOfBirth), msg);
            }
            //do the same thing for checking the manager
            msg = Validation.CheckManager(Data, Employee);
            if (!string.IsNullOrEmpty(msg))
            {
                ModelState.AddModelError(nameof(Employee.ManagerID), msg);
            }
            //code will be the same thing except call other validation function
            if (ModelState.IsValid)
            {
                Data.Insert(Employee); //adds it to entity framework
                Data.Save(); //saves it to the database
                TempData["msg"] = "Employee was added.";
                return RedirectToAction("Index", "Home"); //takes us back to the page
            }
            else //if there is a validation error, pass a list of the employees
            {
                ViewBag.Employees = Data.List(new QueryOptions<Employee> { OrderBy = e => e.FirstName });

                return View();
            }

        }
        public IActionResult Add()
        {
            //populate viewbag employees with a list of employees
            ViewBag.Employees = Data.List(new QueryOptions<Employee> { OrderBy = e => e.FirstName });
            return View();
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}