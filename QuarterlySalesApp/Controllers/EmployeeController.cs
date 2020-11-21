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
        public EmployeeContext Context { get; set; }
        public EmployeeController(EmployeeContext context)
        {
            data = new Repository<Employee>(context);
            Context = context;
        }
        public ViewResult List(GridDTO vals)
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
            //OrderByy depends on value of SortField route
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
                Employees = data.List(options),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Count)
            };
            return View(vm);
            
        }
        private Repository<Employee> data { get; set; }
        
        [HttpPost]
        public IActionResult Add(Employee Employee)
        {
            string msg = Validation.CheckEmployee(Context, Employee.FirstName, Employee.LastName, Employee.DateOfBirth); //checks database
            if (!string.IsNullOrEmpty(msg))
            {
                ModelState.AddModelError(nameof(Employee.DateOfBirth), msg);
            }
            //do the same thing for checking the manager
            msg = Validation.CheckManager(Context, Employee.FirstName, Employee.LastName, Employee.DateOfBirth, Employee.ManagerID);
            if (!string.IsNullOrEmpty(msg))
            {
                ModelState.AddModelError(nameof(Employee.ManagerID), msg);
            }
            //code will be the same thing except call other validation function
            if (ModelState.IsValid)
            {
                Context.Employees.Add(Employee); //adds it to entity framework
                Context.SaveChanges(); //saves it to the database
                TempData["msg"] = "Employee was added.";
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
            //populate viewbag employees with a list of employees
            ViewBag.Employees = Context.Employees.ToList();
            return View();
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
