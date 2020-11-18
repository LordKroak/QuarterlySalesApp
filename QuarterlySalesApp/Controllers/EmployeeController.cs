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
            Context = context;
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
